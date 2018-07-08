using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NAD_Final
{
    public partial class TextbookTrader : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Browse_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BrowsePage.aspx", true);
        }

        protected void Post_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StuPostTextbook.aspx", true);
        }

        protected void FAQ_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/FAQ.aspx", true);
        }

        protected void Logic_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LoginPage.aspx", true);
        }
        protected void Logo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainPage.aspx", true);
        }
    }
}