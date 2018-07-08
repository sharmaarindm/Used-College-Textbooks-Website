/*
* FILE : StuPostTextbook.aspx.cs
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin,Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This file is the class for studen post asp page.
*/

using NAD_Final.Model;
using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;

namespace NAD_Final
{
    public partial class PostTextbooks : System.Web.UI.Page
    {
        private int selectedPost = 0;

        // DataTable currentPosts = new DataTable();
        private DAL myDal = new DAL();
        Logger log = new Logger();


        /*
        * FUNCTION : Page_Load
        *
        * DESCRIPTION : Authenticates user identity.
        *
        * PARAMETERS : 
        *
        * RETURNS : 
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page Authentication 1
            if (Request.IsAuthenticated)
            {
                if (!IsPostBack)
                {
                    string useremail = User.Identity.Name;
                    // Get User Data from FormsAuthenticationTicket and show it in WelcomeBackMessage
                    FormsIdentity ident = User.Identity as FormsIdentity;

                    if (ident != null)
                    {
                        FormsAuthenticationTicket ticket = ident.Ticket;
                        log.AddEventToLog("User Authenticated", "Audit", "PostTextbooks");
                        string[] buffer = ticket.UserData.Split('|');
                        string GroupID = buffer[0];
                        string UserID = buffer[1];

                        if (Int32.Parse(GroupID) < 3)
                        {
                            Button14.Visible = true;
                        }

                        //DataTable result = new DataTable();

                        //result = myDal.retrieveUserIDByEmail(useremail);

                        //object[] id = result.Rows[0].ItemArray;

                        postListView.DataSource = myDal.returnUserPosts(Convert.ToInt32(UserID));
                        postListView.DataBind();
                    }
                    else
                    {

                        Response.Redirect("~/LoginPage.aspx", true);
                        log.AddEventToLog("User Could Not Be Authenticated", "Audit", "PostTextbooks");

                    }
                }
            }
            else
            {
                Response.Redirect("~/LoginPage.aspx", true);
                log.AddEventToLog("User Authenticated", "Audit", "PostTextbooks");
            }
        }

        /*
        * FUNCTION : RetrievePostID
        *
        * DESCRIPTION : 
        *
        * PARAMETERS : string buttonName - name of selected button
        *              int userID - user ID
        *
        * RETURNS : int postID - ID used to identify the post
        */
        public int RetrievePostID(string buttonname, int userID)
        {
            int postID = 0;
            string whereToSplit = "";

            //var userIDFromIndex;
            int selectedIndex = 0;

            if (buttonname.Contains("editPostbutton_"))
            {
                whereToSplit = "editPostbutton_";
            }
            else if (buttonname.Contains("deletePostButton_"))
            {
                whereToSplit = "deletePostButton_";
            }

            var userIDFromIndex = buttonname.Split(new[] { whereToSplit }, StringSplitOptions.None);
            selectedIndex = Int32.Parse(userIDFromIndex[1]);
            object[] selectedRow = myDal.returnUserPosts(userID).Rows[selectedIndex].ItemArray;
            postID = Convert.ToInt32(selectedRow[0]);

            return postID;
        }

        // "editPostbutton_";
        // 3

        /*
        * FUNCTION : Add_Post_Clicked
        *
        * DESCRIPTION : Takes user input and the database with a new post. Then calls page to be updated showign the new post. 
        */
        protected void Add_Post_Clicked(object sender, EventArgs e)
        {
            if (checkIfEmpty())
            {
                newTitle.ForeColor = System.Drawing.Color.Black;
                Author.ForeColor = System.Drawing.Color.Black;
                ISBN.ForeColor = System.Drawing.Color.Black;
                Edition.ForeColor = System.Drawing.Color.Black;
                Publisher.ForeColor = System.Drawing.Color.Black;

                //InvalidCredentialsMessage.Text = "";
                //InvalidCredentialsMessage.Visible = false;

                int results = 0;
                PostForm myPost = new PostForm();

                myPost.Title = newTitle.Text;
                myPost.Author = Author.Text;
                myPost.ISBN = ISBN.Text;
                myPost.Edition = Edition.Text;
                myPost.Publisher = Publisher.Text;
                myPost.Price = Price.Text;

                FormsIdentity ident = User.Identity as FormsIdentity;
                FormsAuthenticationTicket ticket = ident.Ticket;
                string[] buffer = ticket.UserData.Split('|');
                string UserID = buffer[1];

                if (AddPost.Text.Equals("Add Post"))
                {
                    DateTime postDate = DateTime.Today;
                    DateTime expireDate = postDate.AddMonths(1);

                    results = myDal.CreatePosting(myPost.Title, myPost.Author, myPost.ISBN, Convert.ToInt32(myPost.Edition), myPost.Publisher, Convert.ToDouble(myPost.Price), expireDate, Convert.ToInt32(UserID), postDate);

                    if (results > 0)
                    {
                        postListView.DataSource = myDal.returnUserPosts(Convert.ToInt32(UserID));
                        postListView.DataBind();

                        newTitle.Text = "";
                        Author.Text = "";
                        ISBN.Text = "";
                        Edition.Text = "";
                        Publisher.Text = "";
                        Price.Text = "";
                    }
                    else
                    {
                        //error message
                        log.AddEventToLog("Incorrect Query Results", "Audit", "PostTextbooks");
                    }
                }
                else if (AddPost.Text.Equals("Edit Post"))
                {
                    string objectSenderInf = (sender as Control).ClientID;

                    // int postID = RetrievePostID(objectSenderInf, 3);

                    double price = Convert.ToDouble(myPost.Price);

                    results = myDal.updatePost(Convert.ToInt32(ViewState["selectedPost"]), myPost.Title, myPost.Author, myPost.ISBN, Convert.ToInt32(myPost.Edition), myPost.Publisher, (float)price);
                    //retrieve current user
                    if (results > 0)
                    {
                        postListView.DataSource = myDal.returnUserPosts(Convert.ToInt32(UserID));
                        postListView.DataBind();

                        newTitle.Text = "";
                        Author.Text = "";
                        ISBN.Text = "";
                        Edition.Text = "";
                        Publisher.Text = "";
                        Price.Text = "";
                    }
                    else
                    {
                        //update failed
                        log.AddEventToLog("Update Query Failed", "Audit", "PostTextbooks");
                    }
                    AddPost.Text = "Add Post";
                }
            }
        }

        /*
        * FUNCTION : EditPost_Click
        *
        * DESCRIPTION : Edit post already in the DB
        *
        */
        protected void EditPost_Click(object sender, EventArgs e)
        {
            DataTable currentPosts = new DataTable();

            if (AddPost.Text.Equals("Add Post"))
            {
                AddPost.Text = "Edit Post";
            }

            FormsIdentity ident = User.Identity as FormsIdentity;
            FormsAuthenticationTicket ticket = ident.Ticket;
            string[] buffer = ticket.UserData.Split('|');
            string UserID = buffer[1];

            string objectSenderInf = (sender as Control).ClientID;

            int postID = RetrievePostID(objectSenderInf, Convert.ToInt32(UserID));

            object[] myResults = myDal.retrievePostByPostID(postID).Rows[0].ItemArray;

            newTitle.Text = myResults[3].ToString();
            Author.Text = myResults[4].ToString();
            ISBN.Text = myResults[5].ToString();
            Edition.Text = myResults[6].ToString();
            Publisher.Text = myResults[7].ToString();
            Price.Text = myResults[2].ToString();

            ViewState.Add("selectedPost", postID);
        }

        /*
        * FUNCTION : DeletePost_Click
        *
        * DESCRIPTION : Delete user post from DB and UI
        */
        protected void DeletePost_Click(object sender, EventArgs e)
        {
            //string win2 = "did we get in?";
            int result = 0;

            FormsIdentity ident = User.Identity as FormsIdentity;
            FormsAuthenticationTicket ticket = ident.Ticket;
            string[] buffer = ticket.UserData.Split('|');
            string UserID = buffer[1];

            string objectSenderInf = (sender as Control).ClientID;
            int postID = RetrievePostID(objectSenderInf, Convert.ToInt32(UserID));

            result = myDal.deletePost(postID);

            if (result > 0)
            {
                postListView.DataSource = myDal.returnUserPosts(Convert.ToInt32(UserID));
                postListView.DataBind();
                //delete failed
                log.AddEventToLog("Delete Post Success", "Audit", "PostTextbooks");
            }
            else
            {
                log.AddEventToLog("Delete Post Failed", "Audit", "PostTextbooks");
                //delete failed
            }
        }



        protected void postListView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /*
        * FUNCTION : checkIfEmpty
        *
        * DESCRIPTION : Validate post form.
        *
        */
        private bool checkIfEmpty()
        {
            bool retval = true;
            string toDisplay = "*required field";

            if ((newTitle.Text == "") || (newTitle.Text == toDisplay))
            {
                newTitle.Text = toDisplay;
                newTitle.ForeColor = System.Drawing.Color.Red;
                retval = false;
            }
            if ((Author.Text == "") || (Author.Text == toDisplay))
            {
                Author.Text = toDisplay;
                Author.ForeColor = System.Drawing.Color.Red;
                retval = false;
            }
            if ((ISBN.Text == "") || (ISBN.Text == toDisplay))
            {
                ISBN.Text = toDisplay;
                ISBN.ForeColor = System.Drawing.Color.Red;
                retval = false;
            }
            if ((Edition.Text == "") || (Edition.Text == toDisplay))
            {
                Edition.Text = toDisplay;
                Edition.ForeColor = System.Drawing.Color.Red;
                retval = false;
            }
            if ((Publisher.Text == "") || (Publisher.Text == toDisplay))
            {
                Publisher.Text = toDisplay;
                Publisher.ForeColor = System.Drawing.Color.Red;
                retval = false;
            }

            //InvalidCredentialsMessage.Text = toDisplay;
            //InvalidCredentialsMessage.Visible = true;

            return retval;
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