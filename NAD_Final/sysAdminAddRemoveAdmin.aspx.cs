/*
* FILE : sysAdminAddRemoveAdmin.aspx.cs
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin,Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This file is class for the system admin add or remove admin page
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NAD_Final
{
    public partial class sysAdminAddRemoveAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Logo_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx", true);
        }
    }
}