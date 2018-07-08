/*
* FILE : FAQ.aspx.cs
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin, Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This is the class for the FAQ asp page. 
* questions.
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
    public partial class FAQ : System.Web.UI.Page
    {
        /*
        * FUNCTION : Page_Load
        *
        * DESCRIPTION : Authenticates user credentials.
        *
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            //does not require authentication
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