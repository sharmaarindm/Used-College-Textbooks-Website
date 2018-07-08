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

namespace NAD_Final
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Browse_Click(object sender, EventArgs e)
        {
            Response.Redirect("BrowsePage.aspx", true);
        }

        protected void Post_Click(object sender, EventArgs e)
        {
            Response.Redirect("StuPostTextbook.aspx", true);
        }

        protected void FAQ_Click(object sender, EventArgs e)
        {
            Response.Redirect("FAQ.aspx", true);
        }

        protected void Logic_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx", true);
        }
        protected void Logo_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx", true);
        }
    }
}