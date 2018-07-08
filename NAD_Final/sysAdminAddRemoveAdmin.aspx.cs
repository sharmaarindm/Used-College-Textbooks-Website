/*
* FILE : sysAdminAddRemoveAdmin.aspx.cs
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin,Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This file is class for the system admin add or remove admin page
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NAD_Final.Model;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace NAD_Final
{
    public partial class sysAdminAddRemoveAdmin : System.Web.UI.Page
    {
        DAL myDAL = new DAL();
        int userID;
        static string adminUserName;
        int flagg = 0;

        /*
        * FUNCTION : Page_Load
        *
        * DESCRIPTION : Authenticate user identity.
        *
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                if (!IsPostBack)
                {

                    FormsIdentity ident = User.Identity as FormsIdentity;
                    FormsAuthenticationTicket ticket = ident.Ticket;
                    string[] buffer = ticket.UserData.Split('|');
                    string GroupID = buffer[0];

                    if (Convert.ToInt32(GroupID) == 1)
                    {
                        Button14.Visible = true;

                        displayAllInstAdmins();
                        InstitutionName2.DataTextField = "_institution_name";
                        InstitutionName2.DataSource = myDAL.getStoredProcData("GetInstitutes");
                        InstitutionName2.DataBind();
                    }
                    else
                    {
                        Response.Redirect("~/LoginPage.aspx", true);
                    }
                }

            }
            else
            {
                Response.Redirect("~/LoginPage.aspx", true);
            }
        }

        /*FunctionHeader
        * FUNCTION : SetUserId
        *
        * DESCRIPTION : Accessor for UserID
        *
        */
        public void SetUserId(int id)
        {
            userID = id;
        }

        /*FunctionHeader
        * FUNCTION : displayAllInstAdmins
        *
        * DESCRIPTION : binds list of sys admins to list view.
        * 
        */
        private void displayAllInstAdmins()
        {
            sysAdminListView.DataSource = myDAL.displayAllInstAmins();
            sysAdminListView.DataBind();
        }

        /*FunctionHeader
        * FUNCTION : EditAdmin_Click
        *
        * DESCRIPTION : Edit what institution an Admin is associated with.
        *
        */
        protected void EditAdmin_Click(object sender, EventArgs e)
        {
            //Username.ReadOnly = true;
            //InstitutionName.ReadOnly = true;
            //AdminFname.ReadOnly = true;
            //AdminLName.ReadOnly = true;
            //Password.ReadOnly = true;


            string whereToSplit = "editInstitutebutton_";
            int rowIndex;

            if (AddAdmin.Text == "Add Admin")
            {
                AddAdmin.Text = "Edit Admin";
            }

            string objectSenderInf = (sender as Control).ClientID;
            var userIDFromIndex = objectSenderInf.Split(new[] { whereToSplit }, StringSplitOptions.None);
            rowIndex = Int32.Parse(userIDFromIndex[1]);
            object[] myObj = myDAL.displayAllInstAmins().Rows[rowIndex].ItemArray;
            adminUserName = (myObj[0]).ToString();
            string fname = (myObj[1]).ToString();
            string lname = (myObj[2]).ToString();
            string isntID = (myObj[3]).ToString();

            AdminFname.Text = fname;
            AdminLName.Text = lname;
            InstitutionName2.SelectedIndex = Int32.Parse(isntID) - 1;

            Username.Text = adminUserName;
            Username.Enabled = false;

            displayAllInstAdmins();

        }


        /*FunctionHeader
        * FUNCTION : DeleteAdmin_Click
        *
        * DESCRIPTION : determins what admin is to be deleted and called deleteAdmin
        *
        */
        protected void DeleteAdmin_Click(object sender, EventArgs e)
        {
            string whereToSplit = "deleteInstituteButton_";
            int rowIndex;

            string objectSenderInf = (sender as Control).ClientID;
            var userIDFromIndex = objectSenderInf.Split(new[] { whereToSplit }, StringSplitOptions.None);
            rowIndex = Int32.Parse(userIDFromIndex[1]);
            object[] myObj = myDAL.displayAllInstAmins().Rows[rowIndex].ItemArray;
            adminUserName = (myObj[0]).ToString();
            deleteAdmin(adminUserName);

            displayAllInstAdmins();
        }

        /*FunctionHeader
        * FUNCTION : deleteAdmin
        *
        * DESCRIPTION : Executed when page is loaded. Authenticates current user. Redirects them to login page if no go.
        *
        * PARAMETERS : string adminName = string containing admin to delete.
        */
        private void deleteAdmin(string adminName)
        {
            //alerts.Visible = false;
            //alerts2.Visible = false;
            int retVal = myDAL.DeleteInstAdmin(adminName);

            if (retVal > 0)
            {
                flagg = 3;
                hasAdded(flagg);
                displayAllInstAdmins();
                //Response.Redirect("sysAdminAddRemoveAdmin.aspx", true);
                //success
                //alerts2.Visible = true;
                //alerts2.Text = adminName+" succesfully deleted";
                //alerts2.ForeColor = System.Drawing.Color.Green;

                //displayAllInstAdmins();
                //InstitutionName2.DataTextField = "_institution_name";
                //InstitutionName2.DataSource = myDAL.getStoredProcData("GetInstitutes");
                //InstitutionName2.DataBind();
                //emptyalltextboxes();
            }
            else
            {
                displayAllInstAdmins();
                flagg = 0;
                hasAdded(flagg);
                //notify user 
                //alerts2.Visible = true;
                //alerts2.Text = "error while trying to insert the user";
                //alerts2.ForeColor = System.Drawing.Color.Red;
            }
        }


        /*
        * FUNCTION : editAdmin
        *
        * DESCRIPTION : Edit admin entry in database.
        *
        * PARAMETERS: string instName - institute name
        *             string fName - user first name
        *             string lName - user last name
        *             string userName - email
        *             string pass - password
        *             string salty - salt
        *   
        */
        private void editAdmin(string instName, string fName, string lName, string userName, string pass, string salty)
        {
            //alerts.Visible = false;
            //alerts2.Visible = false;
            int retVal = myDAL.editAdmin(instName, fName, lName, userName, pass, salty);

            if (retVal > 0)
            {

                
                //success
                //alerts2.Visible = true;
                //alerts2.Text = "succesfully updated";
                //alerts2.ForeColor = System.Drawing.Color.Green;

                //displayAllInstAdmins();
                //InstitutionName2.DataTextField = "_institution_name";
                //InstitutionName2.DataSource = myDAL.getStoredProcData("GetInstitutes");
                //InstitutionName2.DataBind();
                //emptyalltextboxes();
            }
            else
            {
                //did not edit 
                //alerts.Visible = true;
                //alerts.Text = "error while trying to insert the user";
                //alerts.ForeColor = System.Drawing.Color.Red;
            }
        }


        protected void sysAdminListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        /*
        * FUNCTION : addAdmin
        *
        * DESCRIPTION : Adds admin to database 
        *
        * PARAMETERS: string instName - institute name they are associated with
        *             string fName - user first name
        *             string lName - user last name
        *             string userName - email
        *             string pass - password
        *             string salty - salt
        *   
        */
        private int addAdmin(string instName, string fName, string lName, string userName, string Password, string Salty)
        {
            int retVal = myDAL.AddInstituteAdmin(instName, fName, lName, userName, Password, Salty);

            if (retVal > 0)
            {
                //inserted
                alerts.Visible = true;
                alerts.Text = userName + " succesfully inserted to " + instName;
                alerts.ForeColor = System.Drawing.Color.Green;

                displayAllInstAdmins();
                InstitutionName2.DataTextField = "_institution_name";
                InstitutionName2.DataSource = myDAL.getStoredProcData("GetInstitutes");
                InstitutionName2.DataBind();
                emptyalltextboxes();
            }
            else
            {
               
                //did not insert admin
                //alerts.Visible = true;
                //alerts.Text = "error while trying to insert the user";
                //alerts.ForeColor = System.Drawing.Color.Red;
            }

            return retVal;
        }



        /*FunctionHeader
        * FUNCTION : hasAdded
        *
        * DESCRIPTION : Executed when page is loaded. Authenticates current user. Redirects them to login page if no go.
        *
        * PARAMETER: int flag - contains flag
        */
        private void hasAdded(int flag)
        {

            if (flag == 1)
            {
                alerts.Text = "Successfully added the admin";
                alerts.ForeColor = System.Drawing.Color.LimeGreen;
            }
            else if (flag == 2)
            {
                alerts.Text = "Successfully edited the admin";
                alerts.ForeColor = System.Drawing.Color.LimeGreen;
            }
            else if (flag == 3)
            {
                alerts.Text = "Successfully deleted the admin";
                alerts.ForeColor = System.Drawing.Color.LimeGreen;
            }
            else if (flag == 4)
            {
                alerts.Text = "Failed to add the user!";
                alerts.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                alerts.Enabled = false;
            }
        }

        /*FunctionHeader
        * FUNCTION : AddAdmin_Click1
        *
        * DESCRIPTION : Executed when page is loaded. Authenticates current user. Redirects them to login page if no go.
        *
        */
        protected void AddAdmin_Click1(object sender, EventArgs e)
        {
            //alerts2.Visible = false;
            if (AddAdmin.Text == "Add Admin")
            {

                string institute = InstitutionName2.SelectedItem.Text;

                if (Password.Text != "" && Username.Text != "" && institute != "" && AdminFname.Text != ""
                    && AdminLName.Text != "")
                {
                    string salt = CreateSalt(10);
                    string hash = CreatePasswordHash(Password.Text, salt);
                    string instName = institute;
                    string firstName = AdminFname.Text;
                    string lastName = AdminLName.Text;
                    string userName = Username.Text;


                    int retVal = addAdmin(instName, firstName, lastName, userName, hash, salt);
                    if (retVal == 1)
                    {
                        flagg = 1;
                        hasAdded(flagg); 
                    }
                    else
                    {
                        flagg = 4;
                        hasAdded(flagg);
                    }
                    displayAllInstAdmins();
                    // Response.Redirect("sysAdminAddRemoveAdmin.aspx", true);


                }
                else
                {
                    flagg = 0;
                    hasAdded(flagg);

                    alerts.Text = "Fields can't be left empty";
                    alerts.ForeColor = System.Drawing.Color.Red;
                    displayAllInstAdmins();
                }


            }

            if (AddAdmin.Text == "Edit Admin")
            {
                string institute = InstitutionName2.SelectedItem.Text;
                if (Username.Text != "" && institute != "" && AdminFname.Text != "" && AdminLName.Text != "")
                {
                    string salt = CreateSalt(10);
                    string pass = CreatePasswordHash(Password.Text, salt);
                    string instName = institute;
                    string adminFirstName = AdminFname.Text;
                    string adminLastName = AdminLName.Text;
                    editAdmin(instName, adminFirstName, adminLastName, adminUserName, pass, salt);
                    AddAdmin.Text = "Add Admin";
                    Username.Enabled = true;
                    flagg = 2;
                    hasAdded(flagg);
                    displayAllInstAdmins();
                    emptyalltextboxes();
                    //Response.Redirect("sysAdminAddRemoveAdmin.aspx", true);
                }
                else
                {
                    flagg = 0;
                    hasAdded(flagg);
                    alerts.Text = "Fields can't be left empty";
                    alerts.ForeColor = System.Drawing.Color.Red;
                    displayAllInstAdmins();
                }
            }

            //Response.Redirect("sysAdminAddRemoveAdmin.aspx", true);

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



        /*FunctionHeader
        * FUNCTION : emptyalltextboxes
        *
        * DESCRIPTION : Emptys all form text boxes on page.
        *
        */
        void emptyalltextboxes()
        {
            Username.Text = "";
            AdminFname.Text = "";
            AdminLName.Text = "";
            Password.Text = "";
        }


        /*FunctionHeader
        * FUNCTION : Admin_Click
        *
        * 
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

        /*FunctionHeader
        * FUNCTION : checkIfEmpty
        *
        * DESCRIPTION : Executed when page is loaded. Authenticates current user. Redirects them to login page if no go.
        * 
        * PARAMETER: TextBox txt - TextBox to check if empty.
        *
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

    }
}