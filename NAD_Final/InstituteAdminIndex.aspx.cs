/*
* FILE : InstituteAdminIndex.aspx.cs
* PROJECT : NAD 
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin, Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This is the class for the Institute Admin Index page.
*/

using NAD_Final.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NAD_Final
{
    public partial class InstituteAdminIndex : System.Web.UI.Page
    {
        DAL myDal = new DAL();
        Logger log = new Logger();
        User user = new User();


        /*
        * FUNCTION : Page_Load
        *
        * DESCRIPTION : Authenticates user identity
        *
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                //redirect to login
                //string useremail = User.Identity.Name;
                // Get User Data from FormsAuthenticationTicket and show it in WelcomeBackMessage
                FormsIdentity ident = User.Identity as FormsIdentity;

                if (ident != null)
                {
                    log.AddEventToLog("Identity Verified", "Audit", "InstituteAdminIndex");
                    FormsAuthenticationTicket ticket = ident.Ticket;

                    string[] buffer = ticket.UserData.Split('|');
                    string GroupID = buffer[0];

                    if (Int32.Parse(GroupID) <= 2)
                    {
                        Button14.Visible = true;
                    }
                    else
                    {
                        Response.Redirect("~/LoginPage.aspx", true);
                        log.AddEventToLog("Incorrect Permissions", "Audit", "Forgot Password");
                    }
                }
            }
            else
            {
                Response.Redirect("~/LoginPage.aspx", true);
                log.AddEventToLog("Identity couldn't be verified", "Audit", "InstituteAdminIndex");
            }
        }

        /*
        * FUNCTION : ManageCourses_click
        *
        * DESCRIPTION : Redirects user to sysAdminAddRemoveAdmin page.
        */
        protected void ManageCourses_click(object sender, EventArgs e)
        {
            //still need this page
           // Response.Redirect("sysAdminAddRemoveAdmin.aspx", true);
        }

        /*
        * FUNCTION : ManageTextbooks_Click
        *
        * DESCRIPTION : Redirects user to AdminSetCourseBooks
        *
        */
        protected void ManageTextbooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminSetCourseBooks.aspx", true);
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