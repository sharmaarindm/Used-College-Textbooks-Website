/*
* FILE : LoginPage.aspx.cs
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin, Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This is the class file for the login page.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NAD_Final
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Register_Click(object sender, EventArgs e)
        {
            Server.Transfer("RegisterAccount.aspx", true);
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Server.Transfer("ManageAccounts.aspx", true);
        }
        protected void Logo_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx", true);
        }
    }
}