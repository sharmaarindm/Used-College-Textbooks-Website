/*
* FILE : RegisterAccount.aspx.cs
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin, Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This interface is to allow the user to use the system and create an account depending on their institution.
* The user will be requried to specify some information in order to be able to create the account.
*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Web.Security;
using System.Text;
using NAD_Final.Model;
using System.Drawing;


namespace NAD_Final
{

    public partial class RegisterAccount : System.Web.UI.Page
    {
        int saltSIZE = 10;
        User UsertoInsert = new User();
        DAL myDal = new DAL();
        List<string> items = new List<string> {"2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027" };
        Logger log = new Logger();


        /*
        * FUNCTION : Page_Load
        *
        * DESCRIPTION : 
        *
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
                log.AddEventToLog("User Authenticated", "Audit", "RegisterAccounts");
                if (Int32.Parse(GroupID) < 3)
                {
                    Button14.Visible = true;
                }
            }

            //Does not require validation
            if (!IsPostBack)
            {
                CollegeUniversity.DataTextField = "_institution_name";
                CollegeUniversity.DataSource = myDal.getStoredProcData("GetInstitutes");
                CollegeUniversity.DataBind();
                YearOfGraduation.DataSource = items;
                YearOfGraduation.DataBind();
            }

        }

        /*
        * FUNCTION : ResponseError
        *
        * DESCRIPTION : Creates error message dynamically based on string provided
        *
        * PARAMETERS: string errorMessage - string containing the error details.
        */
        public void ResponseError(string errorMessage)
        {
            errorLabel.Visible = true;
            errorLabel.Text = "Failed to register account, it appears " + errorMessage;
            errorLabel.ForeColor = System.Drawing.Color.Red;
            log.AddEventToLog(errorMessage, "Error", "RegisterAccounts");
        }

        /*
        * FUNCTION : Create_Click
        *
        * DESCRIPTION : Create account based on form details filled out.
        * Performs validation and will provide system updates in the UI based on success or fail.
        */
        protected void Create_Click(object sender, EventArgs e)
        {
            checkIfEmpty(UserName);
            checkIfEmpty(password);
            checkIfEmpty(ConfirmPassword);
            checkIfEmpty(fName);
            checkIfEmpty(lName);
            IsValidEmail(UserName);

            if ((checkIfEmpty(UserName)) && (checkIfEmpty(password)) && (checkIfEmpty(ConfirmPassword)) &&
                (checkIfEmpty(fName)) && (checkIfEmpty(lName)) &&
                 (IsValidEmail(UserName)))
            {
                //should check that passwords are equal.
                int retval = 0;

                //password.Text
                if (password.Text.Equals(ConfirmPassword.Text))
                {
                    string salt = CreateSalt(saltSIZE);
                    UsertoInsert.userSalt = salt;
                    string PassSalt = CreatePasswordHash(password.Text, salt);
                    UsertoInsert.hashpass = PassSalt;
                    UsertoInsert.UserName = UserName.Text;
                    UsertoInsert.yearOfGraduation = YearOfGraduation.SelectedItem.Text;
                    UsertoInsert.lname = lName.Text;
                    UsertoInsert.fname = fName.Text;
                    UsertoInsert.institute = CollegeUniversity.SelectedItem.Text;


                    retval = myDal.CreateStudentUser(UsertoInsert);
                    if (retval == 1)
                    {
                        errorLabel.Visible = true;
                        errorLabel.ForeColor = Color.LimeGreen;
                        errorLabel.Text = "Successfully Registered! Please Login.";
                    }
                }
                else
                {
                    string scrub = "sauce";
                    ResponseError("that your passwords do not match!");
                    //passwords are not valid
                    log.AddEventToLog("Password not valid", "Audit", "RegisterAccounts");
                }


                //int retval = myDal.CreateStudentUser(UsertoInsert);

                if (retval == -1)
                {
                    string scrub2 = "sauce";
                    ResponseError("a user with that username already exists!");
                    // probably that user already exists
                }
            }
            else
            {
                ResponseError("not all fields were filled in!");
                //a field was not filled in.
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
        * FUNCTION : checkIfEmpty
        *
        * DESCRIPTION : Validates if field is empty
        *
        * PARAMETERS : TextBox txt - TextBox to be validated.
        * 
        * RETURN : bool retval - success or fail.
        */
        bool checkIfEmpty(TextBox txt)
        {
            bool retval = true;
            string toDisplay = "*required field";
            string toComp = "*invalid Field";
            if ((txt.Text == "") || (txt.Text == toDisplay) || (txt.Text ==toComp))
            {
                if(txt.Text==toComp)
                {
                    txt.Text = toComp;
                }
                else
                {
                    txt.Text = toDisplay;
                }
                
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
        * DESCRIPTION : Validate email
        *
        * PARAMETERS : TextBox text - TextBox onject to validate
        *
        * RETURNS : bool - success or fail.
        */
        bool IsValidEmail(TextBox text)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(text.Text);
                text.ForeColor = System.Drawing.Color.Black;
                return addr.Address == text.Text;
            }
            catch
            {
                text.Text = "*invalid Field";
                text.ForeColor = System.Drawing.Color.Red;
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