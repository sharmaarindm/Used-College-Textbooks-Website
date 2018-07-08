using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NAD_Final.Model;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

/*
* FILE : ForgotPassword.aspx.cs
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin, Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This is the class for the ForgotPassword page. 
* questions.
*/


namespace NAD_Final
{
    public partial class ForgotPassword : System.Web.UI.Page
    {


        Logger log = new Logger();
        DAL myDAl = new DAL();

        /*
        * FUNCTION : Page_Load
        *
        * DESCRIPTION : Authenicate user when page is loaded.
        *
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                //retrieve user and group_id
                FormsIdentity ident = User.Identity as FormsIdentity;

                if (ident != null)
                {
                    FormsAuthenticationTicket ticket = ident.Ticket;

                    string[] buffer = ticket.UserData.Split('|');
                    string GroupID = buffer[0];
                    string UserID = buffer[1];
                    log.AddEventToLog("Identity Authenticated", "Audit", "Forgot Password");

                    if (Int32.Parse(GroupID) < 3)
                    {
                        Button14.Visible = true;
                    }
                }

            }
        }

        /*
        * FUNCTION : send_Click
        *
        * DESCRIPTION : Validates user input and sends reset password email to user if correct.
        * Otherwise informs user of incorrect input
        *
        */
        protected void send_Click(object sender, EventArgs e)
        {
            if (SendMail.Text.Equals("Submit Code"))
            {
                //check code and resubmit
                string original = ViewState["confirmCode"].ToString();

                if (original.Equals(UserName.Text))
                {
                    //got a match
                    string redirectTo = "~/ResetPassword.aspx?useremail=" + ViewState["useremail"].ToString();
                    Response.Redirect(redirectTo, true);
                }
                else
                {
                    //the scrub wrote something in wrong...

                    UserName.Text = "";
                    confirmationlabel.Text = "Get Confirmation Code";
                    usernameLabel.Text = "Username ";
                    SendMail.Text = "  Send Email  ";

                    failedAttempt.Visible = true;
                    failedAttempt.Text = "Invalid code, if you didn't recieve a code try resending!";
                    failedAttempt.ForeColor = System.Drawing.Color.Red;
                    //perhaps offer to resend code?
                    log.AddEventToLog("Failed Password Retrieval Attempt", "Audit", "Forgot Password");
                }

            }
            else
            {
                if (UserName.Text == "")
                {
                    failedAttempt.Visible = true;
                    failedAttempt.Text = "Please provide a vaild email!";
                    failedAttempt.ForeColor = System.Drawing.Color.Red;
                    log.AddEventToLog("Failed Password Retrieval Attempt", "Audit", "Forgot Password");
                }
                else
                {
                    if (IsValidEmail(UserName.Text))
                    {
                        //retrieve the username, prepare for sending it during redirect

                        string code = "";
                        int retval = myDAl.CheckifUserExists(UserName.Text);
                        if (retval == 0)
                        {
                            code = CreateSalt(10);
                            string salt = CreateSalt(10);
                            string hash = CreatePasswordHash(code, salt);
                            //myDAl.updatehashsalt(UserName.Text, hash, salt);
                            SendEmail(UserName.Text, code);

                            //ViewState the hash
                            ViewState["confirmCode"] = code;
                            ViewState["useremail"] = UserName.Text;

                            //after this change the button functionality
                            //change the textbox label

                            UserName.Text = "";
                            confirmationlabel.Text = "Enter Confirmation Code";
                            usernameLabel.Text = "Confirmation Code ";
                            SendMail.Text = "Submit Code";

                            failedAttempt.Visible = true;
                            failedAttempt.Text = "Please check your email for further instructions!";
                            failedAttempt.ForeColor = System.Drawing.Color.LimeGreen;
                            log.AddEventToLog("Successful Password Retrieval Attempt", "Audit", "Forgot Password");
                        }
                        else
                        {
                            failedAttempt.Visible = true;
                            failedAttempt.Text = "The username provided is invalid!";
                            failedAttempt.ForeColor = System.Drawing.Color.Red;
                            log.AddEventToLog("Invalid Credentials", "Audit", "Forgot Passwords");
                            log.AddEventToLog("Failed Password Retrieval Attempt", "Audit", "Forgot Password");
                        }
                   
                    }
                    else
                    {
                        failedAttempt.Visible = true;
                        failedAttempt.Text = "The username provided is invalid!";
                        failedAttempt.ForeColor = System.Drawing.Color.Red;
                        log.AddEventToLog("Failed Password Retrieval Attempt", "Audit", "Forgot Password");
                    }
                }
            }
        }

        /*
        * FUNCTION : SendEmail
        *
        * DESCRIPTION : Function is called to send Password reset email to user. 
        * It builds the smtp call populates with email and sends message.
        * 
        * PARAMETERS: string toEmail - string containing email address of user.
        *             string code - string containing security code user must input to reset password.
        *
        */
        protected void SendEmail(string toEmail,string code)
        {

            using (MailMessage mm = new MailMessage("donotreply.studenttextbook@gmail.com", toEmail))
            {
                mm.Subject = "Forgot your password?";
                mm.Body = "Please enter this code into the forgot password page:\n\n"+code;

                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("donotreply.studenttextbook@gmail.com", "buyandsell");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);

                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
                log.AddEventToLog("Password Retrieval Email Sent to User", "Audit", "Forgot Password");
            }
        }

        /*
        * FUNCTION : CreateSalt
        * DESCRIPTION : Encoding function to create salt.
        * PARAMETERS : int size -
        * RETURNS : byte[] buff - Base64 encoded byte array containing the salted password.
        */
        private static string CreateSalt(int size)
        {
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return Convert.ToBase64String(buff);
        }


        /*
        * FUNCTION : CreatePasswordHash
        * DESCRIPTION : hashes password using sale and password. 
        *               using SHA it encodes the combined password and salt strings.
        *               
        * PARAMETERS : string pwd - password
        *              string salt - salt
        * RETURNS : string retval - hashed password
        */
        private static string CreatePasswordHash(string pwd, string salt)
        {
            string saltAndPwd = String.Concat(pwd, salt);
            SHA1 sha = new SHA1CryptoServiceProvider();
            // This is one implementation of the abstract class SHA1.
            byte[] toBytes = Encoding.ASCII.GetBytes(saltAndPwd);
            byte[] hashedPwd = sha.ComputeHash(toBytes);


            string retval = System.Text.Encoding.Default.GetString(hashedPwd);

            return retval;
        }

        /*
        * FUNCTION : IsValidEmail
        * DESCRIPTION : Validates email
        * PARAMETERS : string email - email to validate
        * RETURNS : bool - true or false
        */
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                UserName.ForeColor = System.Drawing.Color.Black;
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        /*
        * FUNCTION : Admin_Click
        * DESCRIPTION : Authenticates user credentials and redirects to appropriate Admin user page.
        */
        protected void Admin_Click(object sender, EventArgs e)
        {
            FormsIdentity ident = User.Identity as FormsIdentity;

            if (ident != null)
            {
                FormsAuthenticationTicket ticket = ident.Ticket;

                string[] buffer = ticket.UserData.Split('|');
                string GroupID = buffer[0];
                string UserID = buffer[1];

                if (Int32.Parse(GroupID) == 1)
                {
                    Response.Redirect("~/ManageAccounts.aspx");
                    //for system admin
                }
                else if (Int32.Parse(GroupID) == 2)
                {
                    Response.Redirect("~/InstituteAdminIndex.aspx");
                    //for instute admin
                }
            }
        }
    }
}