/*
* FILE : LoginPage.aspx.cs
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin, Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This is the class file for the login page.
*/

using System;
using System.Web;
using NAD_Final.Model;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using System.Data;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

namespace NAD_Final
{

    public partial class LoginPage : System.Web.UI.Page
    {
        User CurrentUser = new User();
        DAL myDAL = new DAL();
        Logger log = new Logger();

        /*
        * FUNCTION : Page_Load
        *
        * DESCRIPTION : Authenticates user identity. 
        * Also provides provides status up when password is updated.
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                //retrieve user and group_id
                FormsIdentity ident = User.Identity as FormsIdentity;

                if (ident != null)
                {
                    log.AddEventToLog("Identity Verified", "Audit", "LoginPage");
                    FormsAuthenticationTicket ticket = ident.Ticket;

                    string[] buffer = ticket.UserData.Split('|');
                    string GroupID = buffer[0];
                    string UserID = buffer[1];

                    if (Int32.Parse(GroupID) < 3)
                    {
                        Button14.Visible = true;
                    }
                }
            }
            

            if (Request.QueryString.Count > 0)
            {
                if (!String.IsNullOrWhiteSpace(Request.QueryString["passwordUpdated"].ToString()))
                {
                    string result = Request.QueryString["passwordUpdated"].ToString();

                    if (result.Equals("true"))
                    {
                        failedLogin.Visible = true;
                        failedLogin.ForeColor = System.Drawing.Color.LimeGreen;
                        failedLogin.Text = "Your Password Was Updated!";
                        log.AddEventToLog("Password was updated", "Audit", "LoginPage");
                    }
                }
            }
        }

        /*
        * FUNCTION : Forgot_click
        *
        * DESCRIPTION : Redirects to Forgot Password Page
        *
        */
        protected void Forgot_click(object sender, EventArgs e)
        {
            Response.Redirect("~/ForgotPassword.aspx", true);
        }

        /*
        * FUNCTION : Register_Click
        *
        * DESCRIPTION : Redirects to Register Account
        */
        protected void Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RegisterAccount.aspx", true);
        }

        /*
        * FUNCTION : Login_Click
        *
        * DESCRIPTION : Validates form against database. If all conform then user is logged in and redirected to corresponding page:
        * 1. System Admin ->
        * 2. Institute Admin ->
        * 3. Basic User -> Mainpage
        */
        protected void Login_Click(object sender, EventArgs e)
        {
            checkIfEmpty(password);
            checkIfEmpty(UserName);
            if ((checkIfEmpty(password)) && (checkIfEmpty(UserName)))
            {
                if (IsValidEmail(UserName.Text))
                {
                    CurrentUser.UserName = UserName.Text;
                    string input = password.Text;
                    DataTable dt = new DataTable();
                    dt = myDAL.returnUserForUsername(CurrentUser.UserName);

                    if (dt.Rows.Count != 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            int temp;
                            bool retval = Int32.TryParse(row["_user_id"].ToString(), out temp);
                            if (retval)
                            {
                                CurrentUser.UserID = temp;
                                CurrentUser.hashpass = row["_hash"].ToString();
                                CurrentUser.userSalt = row["_salt"].ToString();
                                CurrentUser.fname = row["_first_name"].ToString();
                                CurrentUser.lname = row["_last_name"].ToString();
                                CurrentUser.userGroupId = row["_user_group_id"].ToString();
                                CurrentUser.yearOfGraduation = row["_estimated_year_of_graduation"].ToString();
                            }
                        }
                    }

                    string thishash = CreatePasswordHash(password.Text, CurrentUser.userSalt);

                    if (thishash == CurrentUser.hashpass)//user validated
                    {
                        // ViewState.Add("UserGroup", CurrentUser.userGroupId);
                        string userDataString = string.Concat(CurrentUser.userGroupId, "|", CurrentUser.UserID);
                        // Create the cookie that contains the forms authentication ticket
                        HttpCookie authCookie = FormsAuthentication.GetAuthCookie(UserName.Text, true);
                        // Get the FormsAuthenticationTicket out of the encrypted cookie
                        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                        // Create a new FormsAuthenticationTicket that includes our custom User Data
                        FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, userDataString);
                        // Update the authCookie's Value to use the encrypted version of newTicket
                        authCookie.Value = FormsAuthentication.Encrypt(newTicket);
                        // Manually add the authCookie to the Cookies collection
                        Response.Cookies.Add(authCookie);
                        // Determine redirect URL and send user there
                        string redirUrl = FormsAuthentication.GetRedirectUrl(UserName.Text, true);

                        if (CurrentUser.userGroupId == "1") //system admin
                        {
                            Response.Redirect("~/ManageAccounts.aspx", true);
                        }
                        else if (CurrentUser.userGroupId == "2") //institute admin
                        {
                            Response.Redirect("~/AdminSetCourseBooks.aspx");
                            log.AddEventToLog("System Admin Verified - Redirecting to Manage Accounts", "Audit", "LoginPage");
                        }
                        else if (CurrentUser.userGroupId == "3") //student user
                        {
                            log.AddEventToLog("Basic User Identity Verified", "Audit", "LoginPage");
                            //int val = Int32.Parse(ViewState["UserGroup"].ToString());
                            Response.Redirect("~/MainPage.aspx");
                        }
                    }
                    else
                    {
                        log.AddEventToLog("Failed Login - Incorrect Password", "Audit", "LoginPage");
                        failedLogin.Visible = true;
                        failedLogin.ForeColor = System.Drawing.Color.Red;
                        failedLogin.Text = "Failed to Login";
                        //invalid password
                    }
                }
                else
                {
                    log.AddEventToLog("Failed Login - Incorrect Username", "Audit", "LoginPage");
                    failedLogin.Visible = true;
                    failedLogin.ForeColor = System.Drawing.Color.Red;
                    failedLogin.Text = "Failed to Login";
                    //wrong username format
                }
            }
            else
            {
                log.AddEventToLog("Failed Login - Empty Field", "Audit", "LoginPage");
                failedLogin.Visible = true;
                failedLogin.ForeColor = System.Drawing.Color.Red;
                failedLogin.Text = "Failed to Login";
                //empty field scenario
            }

          
            
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
        * FUNCTION : checkIfEmpty
        *
        * DESCRIPTION : Validate is Textbox is empty
        *
        * PARAMETERS : TextBox txt -> TextBox to be validated
        *
        * RETURNS : bool - success or fail.
        */
        bool checkIfEmpty(TextBox txt)
        {
            bool retval = true;
            string toDisplay = "*required field";

            if ((txt.Text == "") || (txt.Text == toDisplay))
            {
                txt.Text = toDisplay;
                txt.ForeColor = System.Drawing.Color.Red;
                retval = false;
            }
            else
            {
                txt.ForeColor = System.Drawing.Color.Black;
            }

            return retval;
        }

        /*
        * FUNCTION : IsValidEmail
        *
        * DESCRIPTION : Validates email
        *
        * PARAMETERS : string email - email to be validated.
        *
        * RETURNS : bool - success or fail.
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
                UserName.Text = "*invalid username";
                UserName.ForeColor = System.Drawing.Color.Red;
                return false;
            }
        }
        /*
        * FUNCTION : Admin_Click
        *
        * DESCRIPTION : Authenticates user credentials and redirects to appropriate Admin user page.
        *
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