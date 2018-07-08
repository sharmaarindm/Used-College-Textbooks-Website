/*
* FILE : sysAdminAddRemoveInstitution.aspx
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin,Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This file is class for the system admin user in order to be able to add or remove an institution.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NAD_Final.Model;
using System.Web.Security;

namespace NAD_Final
{
    public partial class sysAdminAddRemoveInstitute : System.Web.UI.Page
    {

        User myUser = new User();
        DAL myDal = new DAL();
        static string instName;
        int flagg = 0;

        /*
        * FUNCTION : Page_Load
        *
        * DESCRIPTION : Executed when page is loaded. Authenticates current user. Redirects them to login page if no go.
        *
        */
        protected void Page_Load(object sender, EventArgs e)
        {

            //Page Authentication 3
            if (Request.IsAuthenticated)
            {
                FormsIdentity ident = User.Identity as FormsIdentity;
                FormsAuthenticationTicket ticket = ident.Ticket;
                string[] buffer = ticket.UserData.Split('|');
                string GroupID = buffer[0];

                if (Convert.ToInt32(GroupID) == 1)
                {

                    Button14.Visible = true;

                    if (!IsPostBack)
                    {
                        DisplayInstitutions();
                    }
                }
                else
                {
                    Response.Redirect("~/LoginPage.aspx", true);
                }
            }
            else
            {
                Response.Redirect("~/LoginPage.aspx", true);
            }
        }


        /*
        * FUNCTION : AddInstituteButton_Click
        *
        * DESCRIPTION : Add Institute to Institute Table.
        *
        */
        protected void AddInstituteButton_Click(object sender, EventArgs e)
        {
            Institute.ForeColor = System.Drawing.Color.Black;
            string instiName = Institute.Text;

            if (AddInstitute.Text == "Add Institute")
            {
                if (instiName != "")
                {
                    bool retVal = myDal.addInstitute(instiName);
                    if (retVal == true)
                    {
                        flagg = 1;
                        hasAdded(flagg); 
                    }
                    else
                    {
                        flagg = 5;
                        hasAdded(flagg);
                    }
                    DisplayInstitutions();
                }
                else
                {
                    //flagg = 0;
                    //hasAdded(flagg);
                    //alerts.Text = "Fields can't be left empty";
                    //alerts.ForeColor = System.Drawing.Color.Red;
                    //Model.User.flaggarion = 0;
                }

            }
            if (AddInstitute.Text == "Edit Institution")
            {

                //alert user that the input cant be zero

                if (instiName != "")
                {
                    editInst(instName, instiName);
                    flagg = 2;
                    hasAdded(flagg);
                    DisplayInstitutions();
                }
                else
                {
                    //flagg = 0;
                    //hasAdded(flagg);
                    //alerts.Text = "Fields can't be left empty";
                    //alerts.ForeColor = System.Drawing.Color.Red;
                }
            }

             // Response.Redirect("sysAdminAddRemoveInstitute.aspx", true);

            
        }

        /*
        * FUNCTION : hasAdded
        *
        * DESCRIPTION : Debug function
        *
        */
        private void hasAdded(int flag)
        {

            //if (flag == 1)
            //{
            //    alerts.Text = "Successfully added the institution";
            //    alerts.ForeColor = System.Drawing.Color.LimeGreen;
            //}
            //else if (flag == 2)
            //{
            //    alerts.Text = "Successfully edited the institution";
            //    alerts.ForeColor = System.Drawing.Color.LimeGreen;
            //}
            //else if (flag == 3)
            //{
            //    alerts.Text = "Successfully deleted the institution";
            //    alerts.ForeColor = System.Drawing.Color.LimeGreen;
            //}
            //else if (flag == 4)
            //{
            //    alerts.Text = "Cannot delete an institution that contains users";
            //    alerts.ForeColor = System.Drawing.Color.Red;
            //}
            //else if (flag == 5)
            //{
            //    alerts.Text = "Failed to add institution";
            //    alerts.ForeColor = System.Drawing.Color.Red;
            //}
            //else
            //{
            //    alerts.Enabled = false;
            //}
        }



        /*FunctionHeader
        * FUNCTION : instituteListView_SelectedIndexChanged
        *
        * DESCRIPTION : Executed when page is loaded. Authenticates current user. Redirects them to login page if no go.
        *
        */
        protected void instituteListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        /*FunctionHeader
        * FUNCTION : editInstitute_Click
        *
        * DESCRIPTION : Change name of institution in DB. 
        *
        */
        protected void editInstitute_Click(object sender, EventArgs e)
        {

            string whereToSplit = "editInstitutebutton_";
            int rowIndex;

            if (AddInstitute.Text == "Add Institute")
            {
                AddInstitute.Text = "Edit Institution";
            }

            EditInstName.Text = "Edit Institution";
            NewInstName.Text = "New Institution name";

            string objectSenderInf = (sender as Control).ClientID;
            var userIDFromIndex = objectSenderInf.Split(new[] { whereToSplit }, StringSplitOptions.None);
            rowIndex = Int32.Parse(userIDFromIndex[1]);

            object[] myObj = myDal.displayInstitutions().Rows[rowIndex].ItemArray;
            instName = (myObj[0]).ToString();

            Institute.Text = instName;

        }

        /*FunctionHeader
        * FUNCTION : DeleteInstitute_Click
        *
        * DESCRIPTION : Delete institution from DB. If attached to records it will crash.
        *
        */
        protected void DeleteInstitute_Click(object sender, EventArgs e)
        {
            string whereToSplit = "deleteInstituteButton_";
            int rowIndex;

            string objectSenderInf = (sender as Control).ClientID;
            var userIDFromIndex = objectSenderInf.Split(new[] { whereToSplit }, StringSplitOptions.None);
            rowIndex = Int32.Parse(userIDFromIndex[1]);
            object[] myObj = myDal.displayInstitutions().Rows[rowIndex].ItemArray;
            instName = (myObj[0]).ToString();
             int retVal = deleteInstitution(instName);
            if (retVal == 1)
            {
                flagg = 1;
                hasAdded(flagg);
            }
           
        }

        /*FunctionHeader
        * FUNCTION : DisplayInstitutions
        *
        * DESCRIPTION : Accessor for Institution Table. Binds to Listview.
        *
        */
        private void DisplayInstitutions()
        {
            instituteListView.DataSource = myDal.displayInstitutions();
            instituteListView.DataBind();

        }

        /*FunctionHeader
        * FUNCTION : editInst
        *
        * DESCRIPTION : Executed when page is loaded. Authenticates current user. Redirects them to login page if no go.
        *
        * PARAMETERS: string currInstName - current institution name
        *             string newInstName - name to change institution to.
        * 
        * 
        */
        private void editInst(string currInstName, string newInstName)
        {
            myDal.editInstitution(currInstName, newInstName);
        }

        /*
        * FUNCTION : deleteInstitution
        *
        * DESCRIPTION : Executed when page is loaded. Authenticates current user. Redirects them to login page if no go.
        *
        * PARAMETER : string instToDelete - name of institute to delete.
        * 
        * RETURN: Bool retval - success or fail
        */
        private int deleteInstitution(string instToDelete)
        {
            int listCountInitial = (instituteListView.Items.Count);
            
            int retVal = myDal.deleteInstitution(instToDelete);

            int listCountAfter = (instituteListView.Items.Count);
            if (retVal > 0)
            {
                //succeess
                
                DisplayInstitutions();
            }
            else if (listCountInitial == listCountAfter)
            {
                flagg = 4;
                hasAdded(flagg);
                DisplayInstitutions();
            }

            return retVal;
        }

        /*
        * FUNCTION : Admin_Click
        *
        * DESCRIPTION : Executed when page is loaded. Authenticates current user. Redirects them to login page if no go.
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