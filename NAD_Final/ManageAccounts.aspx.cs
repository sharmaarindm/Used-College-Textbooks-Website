/*
* FILE : ManageAccounts.aspx.cs
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This is the class for the manage accounts asp page.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NAD_Final
{

    public partial class ManageAccounts : System.Web.UI.Page
    {
        Logger log = new Logger();

        /*
        * FUNCTION : Page_Load
        *
        * DESCRIPTION : Authenticates user identity
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page Authentication 3
            if (Request.IsAuthenticated)
            {
                log.AddEventToLog("Request Authenticated", "Audit", "ManageAccounts");
                //redirect to login
                //string useremail = User.Identity.Name;
                // Get User Data from FormsAuthenticationTicket and show it in WelcomeBackMessage
                FormsIdentity ident = User.Identity as FormsIdentity;

                if (ident != null)
                {
                    FormsAuthenticationTicket ticket = ident.Ticket;

                    string[] buffer = ticket.UserData.Split('|');
                    string GroupID = buffer[0];

                    if (Int32.Parse(GroupID) < 3)
                    {
                        Button14.Visible = true;
                    }


                    if (Convert.ToInt32(GroupID) != 1)
                    {
                        Response.Redirect("~/LoginPage.aspx", true);
                    }
                }
            }
            else
            {

                Response.Redirect("~/LoginPage.aspx", true);
                log.AddEventToLog("Identity Could not be Authenticated", "Audit", "ManageAccounts");
            }
        }

        /*
        * FUNCTION : ARSysAdmin_Click
        *
        * DESCRIPTION : Redirects user to sysAdminAddRemoveAdmin page
        *
        */
        protected void ARSysAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/sysAdminAddRemoveAdmin.aspx", true);
        }

        /*
        * FUNCTION : ARInstitution_click
        *
        * DESCRIPTION : Redirects user to sysAdminAddRemoveInstitute
        *
        */
        protected void ARInstitution_click(object sender, EventArgs e)
        {
            Response.Redirect("~/sysAdminAddRemoveInstitute.aspx", true);
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
                    log.AddEventToLog("Validated System Admin", "Audit", "Manage Accounts");
                }
                else if (Int32.Parse(GroupID) == 2)
                {
                    Response.Redirect("~/InstituteAdminIndex.aspx");
                    //for instute admin
                    log.AddEventToLog("Validated Institute Admin", "Audit", "Manage Accounts");
                }
            }
        }
    }
}