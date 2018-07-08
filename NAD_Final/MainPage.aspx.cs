/*
* FILE : MainPage.aspx.cs
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin, Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This interface is to allow the user to either browse the posts, access the FAQ page, or create a post. From this page the user can
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
    public partial class MainPage : System.Web.UI.Page
    {

        Logger log = new Logger();
        DAL myDal = new DAL();

        /*
        * FUNCTION : Page_Load
        *
        * DESCRIPTION : Authenticates user identity.
        *
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            //authentication not required
            if (Request.IsAuthenticated)
            {
                //retrieve user and group_id
                FormsIdentity ident = User.Identity as FormsIdentity;

                if (ident != null)
                {
                    FormsAuthenticationTicket ticket = ident.Ticket;
                    log.AddEventToLog("User Authenticated", "Audit", "MainPage");
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
        * FUNCTION : Search_Click
        *
        * DESCRIPTION : Search using keyword provided in search textbox against records in the DB.
        * Redirects and provides results on Browse page
        *
        */
        protected void Search_Click(object sender, EventArgs e)
        {
            // string toRedirect = "ViewPost.aspx?PostID=" + val;
            // string value = Request.QueryString["search"];
            // Response.Redirect(toRedirect, true);

            if (TextBox2.Text != "")
            {
                string searchfield = TextBox2.Text;
                string toRedirect = "~/BrowsePage.aspx?search=" + searchfield;
                Response.Redirect(toRedirect, true);
                TextBox2.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                TextBox2.Text = "*Required Field";
                TextBox2.ForeColor = System.Drawing.Color.Red;
            }
        }

        /*
        * FUNCTION : Browse_Click
        *
        * DESCRIPTION : Redirect user to Browse Page
        *
        */
        protected void Browse_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BrowsePage.aspx", true);
        }

        /*
        * FUNCTION : Post_Click
        *
        * DESCRIPTION : Redirect user to PostTextBooks page
        *
        */
        protected void Post_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PostTextbooks.aspx", true);
        }

        /*
        * FUNCTION : FAQ_Click
        *
        * DESCRIPTION : Redirect user to FAQ page
        * 
        */
        protected void FAQ_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/FAQ.aspx", true);
        }

        /*
        * FUNCTION : Logic_Click
        *
        * DESCRIPTION : Ridirect user to LoginPage
        *
        */
        protected void Logic_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LoginPage.aspx", true);
        }

        /*
        * FUNCTION : Logo_Click
        *
        * DESCRIPTION : Redirect user to Main Page
        *
        */
        protected void Logo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainPage.aspx", true);
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