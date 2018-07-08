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
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NAD_Final
{
    public partial class ManageAccounts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ARSysAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("sysAdminAddRemoveAdmin.aspx", true);
        }

        protected void ARInstitution_click(object sender, EventArgs e)
        {
            Response.Redirect("sysAdminAddRemoveInstitute.aspx", true);
        }
        protected void Logo_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx", true);
        }
    }
}