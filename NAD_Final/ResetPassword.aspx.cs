/*
* FILE : ResetPassword.aspx.cs
* PROJECT : NAD -
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin, Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NAD_Final.Model;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace NAD_Final
{
    public partial class ResetPassword : System.Web.UI.Page
    {

        DAL myDal = new DAL();
        Logger log = new Logger();

        /*
        * FUNCTION : Page_Load
        *
        * DESCRIPTION : Authenticate user identity
        *
        * PARAMETERS : 
        *
        * RETURNS : 
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            FormsIdentity ident = User.Identity as FormsIdentity;

            if (ident != null)
            {
                FormsAuthenticationTicket ticket = ident.Ticket;

                string[] buffer = ticket.UserData.Split('|');
                string GroupID = buffer[0];
                string UserID = buffer[1];
                log.AddEventToLog("Identity Authenticated", "Audit", "ResetPassword");
                if (Int32.Parse(GroupID) < 3)
                {
                    Button14.Visible = true;
                }
            }

            string useremail = Request.QueryString["useremail"];

            ViewState["useremail"] = useremail;
            //myDAl.updatehashsalt(UserName.Text, hash, salt);
        }

        /*
        * FUNCTION : ResetPass_Click
        *
        * DESCRIPTION : Resets user password by comparing user input vs hashed password in the database.
        *
        */
        protected void ResetPass_Click(object sender, EventArgs e)
        {
            string pass = UserName.Text;
            string confirmPass = password.Text;

            if (pass.Equals(confirmPass))
            {
                //need to hash and salt results
                string salt = CreateSalt(10);
                string hash = CreatePasswordHash(UserName.Text, salt);

                myDal.updatehashsalt(ViewState["useremail"].ToString(), hash, salt);

                failedAttempt.Visible = false;
                //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Password Successfully Reset!');", true);
                string toRedirect = "~/LoginPage.aspx?passwordUpdated=true";
                Response.Redirect(toRedirect, true);
            }
            else
            {
                failedAttempt.Visible = true;
                failedAttempt.ForeColor = System.Drawing.Color.Red;
                failedAttempt.Text = "Ensure your password are identical!";
                //message indicating to ensure that the passwords are the name
                log.AddEventToLog("Password Incorrect", "Audit", "ResetPassword");
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