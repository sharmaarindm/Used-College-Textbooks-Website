/*
* FILE : AdminBrowseApprove.aspx.cs
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin, Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This file is the class for the AdminBrowseApprove aspx page.
* 
*/

//THIS FILE IS GETTING CHANGED/ REPLACED WITH SEAN'S PART.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NAD_Final
{

    public partial class AdminBrowseApprove : System.Web.UI.Page
    {
        Logger log = new Logger();

        /*FunctionHeader
        * FUNCTION : Page_Load
        *
        * DESCRIPTION : Executed when page is loaded. Authenticates current user. Redirects them to login page if no go.
        *
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page Authentication 2

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

                    if (Int32.Parse(GroupID) < 3)
                    {
                        Button14.Visible = true;
                    }
                }
                //if (!IsPostBack)
                //{
                //    //currentPosts = myDal.returnUserPosts(3);
                //    postListView.DataSource = myDal.returnUserPosts(3);// myDal.returnUserPosts(3);
                //    postListView.DataBind();
                //}
            }
            else
            {

                Response.Redirect("~/LoginPage.aspx", true);

                log.AddEventToLog("Couldn't verify user permissions", "Error", "AdminBrowseApprove");

                //redirect this user in all cases
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
                    log.AddEventToLog("Validated System Admin", "Audit", "AdminBrowseApprove");
                    //for system admin
                }
                else if (Int32.Parse(GroupID) == 2)
                {
                    log.AddEventToLog("Validated Institute Admin", "Audit", "AdminBrowseApprove Accounts");
                    //for instute admin
                }
            }
        }
    }
}