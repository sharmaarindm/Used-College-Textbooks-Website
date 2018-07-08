/*
* FILE : BrowsePage.aspx.cs
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin, Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This file is class for the browse posts asp page.
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NAD_Final.Model;
using System.Data;
using System.Web.Security;

namespace NAD_Final
{
    public partial class BrowsePage : System.Web.UI.Page
    {

        DAL myDal = new DAL();
        sysAdminAddRemoveAdmin mySysAdmin = new sysAdminAddRemoveAdmin();
        ViewPost myPost = new ViewPost();
        DataTable myDataTable = new DataTable();
        Logger log = new Logger();

        /*
        * FUNCTION : Page_Load
        *
        * DESCRIPTION : Authenicates user on page load. And if not postback will display results of search.
        *
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                log.AddEventToLog("Request Authenticated", "Audit", "BrowsePage");
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

            if (!IsPostBack)
            {
                DropDownList1.DataTextField = "_institution_name";
                DropDownList1.DataSource = myDal.getStoredProcData("GetInstitutes");
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "All Institutes");

                string value = Request.QueryString["search"];
                if (!String.IsNullOrEmpty(value))
                {
                    //run query search
                    DataTable myResults = new DataTable();
                    DataTable queryResults = new DataTable();

                    queryResults = myDal.returnTitleResults(value);
                    myResults.Merge(queryResults);
                    queryResults = myDal.returnAuthorResults(value);
                    myResults.Merge(queryResults);
                    queryResults = myDal.returnISBNResults(value);
                    myResults.Merge(queryResults);

                    browseResultsListView.DataSource = myResults;
                    browseResultsListView.DataBind();
                    ViewState["Result"] = myResults;


                    //may need for feedback that query results came up empty.
                }
            }
        }
        /*
        * FUNCTION : ViewPost_Click
        *
        * DESCRIPTION : Opens post to view details. 
        *
        */
        protected void ViewPost_Click(object sender, EventArgs e)
        {
            try
            {


                int userID;
                var wheteToSplit = "Button13_";
                string objectSenderInf = (sender as Control).ClientID;
                int rowIndex = 0;
                var userIDFromIndex = objectSenderInf.Split(new[] { wheteToSplit }, StringSplitOptions.None);
                rowIndex = Int32.Parse(userIDFromIndex[1]);

                DataTable myResults = (DataTable)ViewState["Result"];

                //DataTable myTable = (DataTable)browseResultsListView.DataSource;
                object[] resultSet = myResults.Rows[rowIndex].ItemArray;
                int postID = Convert.ToInt32(resultSet[3]);

                string redirect = "ViewPost.aspx?PostID=" + postID;
                Response.Redirect(redirect, true);
                log.AddEventToLog("Post Viewed", "Success", "Browse Page");
            }
            catch (Exception ex)
            {
                log.AddEventToLog(ex.ToString(), "Exception", "ManageAccounts");
            }

            // object [] myObj = myDal.returnTitleResults("scrub").Rows[rowIndex].ItemArray;
            // postID = Convert.ToInt32(myObj[3]);
            //DataTable myDataTable = (DataTable)browseResultsListView.DataSource;
            // myPost.SetUserIDFromPost(userID);

            //   string val = "";

            //   myDataTable.Rows.Equals

            //  foreach (DataRow row in myDataTable.Rows)
            //  {
            //      if(row["_post_id"].ToString() == )
            //      val = row["_post_id"].ToString();
            //   }

            //string toRedirect = "ViewPost.aspx?PostID="+val;

            // string value = Request.QueryString["PostID"];
            // Response.Redirect(toRedirect, true);
        }

        /*
        * FUNCTION : Logo_Click
        *
        * DESCRIPTION : Redirects to main page.
        *
        */
        protected void Logo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainPage.aspx", true);


        }
        /*
        * FUNCTION : Browse_Click
        *
        * DESCRIPTION : Uses form selection to browse database for corresponding data.
        * Displays results in a listview.
        *
        */
        protected void Browse_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                TextBox1.ForeColor = System.Drawing.Color.Black;
                DataTable myResults = new DataTable();
                DataTable queryResults = new DataTable();

                //around here we can check for dropdown selection to help narrow
                string whichOption = DropDownList1.SelectedValue.ToString();
                if (whichOption.Equals("All Institutes"))
                {
                    queryResults = myDal.returnTitleResults(TextBox1.Text);
                    myResults.Merge(queryResults);
                    queryResults = myDal.returnAuthorResults(TextBox1.Text);
                    myResults.Merge(queryResults);
                    queryResults = myDal.returnISBNResults(TextBox1.Text);
                    myResults.Merge(queryResults);
                }
                else
                {
                    queryResults = myDal.returnTitleResults(TextBox1.Text, whichOption);
                    myResults.Merge(queryResults);
                    queryResults = myDal.returnAuthorResults(TextBox1.Text, whichOption);
                    myResults.Merge(queryResults);
                    queryResults = myDal.returnISBNResults(TextBox1.Text, whichOption);
                    myResults.Merge(queryResults);
                    //run specific queries
                }

                if (myResults.Rows.Count <= 0)
                {
                    postResultsLabel.Visible = true;
                    postResultsLabel.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    postResultsLabel.Visible = false;
                }

                browseResultsListView.DataSource = myResults;
                browseResultsListView.DataBind();
                ViewState["Result"] = myResults;
            }
            else
            {

                TextBox1.Text = "*Required Field";
                TextBox1.ForeColor = System.Drawing.Color.Red;
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