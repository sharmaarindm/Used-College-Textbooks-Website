using NAD_Final.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NAD_Final
{
    public partial class ManageCourses : System.Web.UI.Page
    {
        private DAL myDal = new DAL();
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (Request.IsAuthenticated)
        //    {
        //        //redirect to login
        //        //string useremail = User.Identity.Name;
        //        // Get User Data from FormsAuthenticationTicket and show it in WelcomeBackMessage
        //        FormsIdentity ident = User.Identity as FormsIdentity;

        //        if (ident != null)
        //        {
        //            FormsAuthenticationTicket ticket = ident.Ticket;

        //            string[] buffer = ticket.UserData.Split('|');
        //            string GroupID = buffer[0];

        //            ViewState["UserID"] = buffer[1];

        //            if (Int32.Parse(GroupID) <= 2)
        //            {
        //                Button14.Visible = true;

        //                DataTable myDataTable = new DataTable();

        //                myDataTable = myDal.GetInstituteIDByUserID(Int32.Parse(ViewState["UserID"].ToString()));
        //                int institution_id = Int32.Parse(myDataTable.Rows[0].ItemArray[0].ToString());


        //                postListView.DataSource = myDal.GetAllCourse(Convert.ToInt32(institution_id));
        //                postListView.DataBind();
        //            }
        //            else
        //            {
        //                Response.Redirect("LoginPage.aspx", true);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Response.Redirect("LoginPage.aspx", true);
        //    }
        //}

        //protected void Add_Post_Clicked(object sender, EventArgs e)
        //{
        //    if (checkIfEmpty())
        //    {
        //        CourseSemester.ForeColor = System.Drawing.Color.Black;
        //        CourseName.ForeColor = System.Drawing.Color.Black;
        //        CourseDescription.ForeColor = System.Drawing.Color.Black;


        //        //InvalidCredentialsMessage.Text = "";
        //        //InvalidCredentialsMessage.Visible = false;
        //        DataTable myDataTable = new DataTable();

        //        int results = 0;
        //        PostForm myPost = new PostForm();

        //        //need to make a query to retrieve instituteID with userID
        //        myDataTable = myDal.GetInstituteIDByUserID(Int32.Parse(ViewState["UserID"].ToString()));
        //        int institution_id = Int32.Parse(myDataTable.Rows[0].ItemArray[0].ToString());

        //        //Int32.TryParse(InstituteName.Text, out )
        //        int coursesemester = 0;
        //        if(Int32.TryParse(CourseSemester.Text, out coursesemester))
        //        {

        //        }
        //        else
        //        {
        //            //bad things
        //        }

        //        string coursename = CourseName.Text;
        //        string coursedescription = CourseDescription.Text;

        //        FormsIdentity ident = User.Identity as FormsIdentity;
        //        FormsAuthenticationTicket ticket = ident.Ticket;
        //        string[] buffer = ticket.UserData.Split('|');
        //        string UserID = buffer[1];

        //        if (AddCourse.Text.Equals("Add Course"))
        //        {
        //            DateTime postDate = DateTime.Today;
        //            DateTime expireDate = postDate.AddMonths(1);

        //            results = myDal.CreateCourse(institution_id, coursesemester, coursename, coursedescription);

        //            if (results > 0)
        //            {
        //                postListView.DataSource = myDal.GetAllCourse(Convert.ToInt32(UserID));
        //                postListView.DataBind();

        //                CourseSemester.Text = "";
        //                CourseName.Text = "";
        //                CourseDescription.Text = "";
        //            }
        //            else
        //            {
        //                //error message
        //            }
        //        }
        //        else if (AddCourse.Text.Equals("Edit Course"))
        //        {
        //            string objectSenderInf = (sender as Control).ClientID;

        //            // int postID = RetrievePostID(objectSenderInf, 3);

        //            double price = Convert.ToDouble(myPost.Price);

        //            results = myDal.EditCourse(Convert.ToInt32(ViewState["selectedPost"]), myPost.Title, myPost.Author, myPost.ISBN, Convert.ToInt32(myPost.Edition), myPost.Publisher, (float)price);
        //            //retrieve current user
        //            if (results > 0)
        //            {
        //                postListView.DataSource = myDal.returnUserPosts(Convert.ToInt32(UserID));
        //                postListView.DataBind();

        //                newTitle.Text = "";
        //                Author.Text = "";
        //                ISBN.Text = "";
        //                Edition.Text = "";
        //                Publisher.Text = "";
        //                Price.Text = "";
        //            }
        //            else
        //            {
        //                //update failed
        //            }
        //            AddPost.Text = "Add Post";
        //        }
        //    }
        //}


        //public int RetrievePostID(string buttonname, int userID)
        //{
        //    int postID = 0;
        //    string whereToSplit = "";

        //    //var userIDFromIndex;
        //    int selectedIndex = 0;

        //    if (buttonname.Contains("editPostbutton_"))
        //    {
        //        whereToSplit = "editPostbutton_";
        //    }
        //    else if (buttonname.Contains("deletePostButton_"))
        //    {
        //        whereToSplit = "deletePostButton_";
        //    }

        //    var userIDFromIndex = buttonname.Split(new[] { whereToSplit }, StringSplitOptions.None);
        //    selectedIndex = Int32.Parse(userIDFromIndex[1]);
        //    object[] selectedRow = myDal.returnUserPosts(userID).Rows[selectedIndex].ItemArray;
        //    postID = Convert.ToInt32(selectedRow[0]);

        //    return postID;
        //}





        //protected void EditPost_Click(object sender, EventArgs e)
        //{
        //    DataTable currentPosts = new DataTable();

        //    if (AddPost.Text.Equals("Add Post"))
        //    {
        //        AddPost.Text = "Edit Post";
        //    }

        //    FormsIdentity ident = User.Identity as FormsIdentity;
        //    FormsAuthenticationTicket ticket = ident.Ticket;
        //    string[] buffer = ticket.UserData.Split('|');
        //    string UserID = buffer[1];

        //    string objectSenderInf = (sender as Control).ClientID;

        //    int postID = RetrievePostID(objectSenderInf, Convert.ToInt32(UserID));

        //    object[] myResults = myDal.retrievePostByPostID(postID).Rows[0].ItemArray;

        //    newTitle.Text = myResults[3].ToString();
        //    Author.Text = myResults[4].ToString();
        //    ISBN.Text = myResults[5].ToString();
        //    Edition.Text = myResults[6].ToString();
        //    Publisher.Text = myResults[7].ToString();
        //    Price.Text = myResults[2].ToString();

        //    ViewState.Add("selectedPost", postID);
        //}

        //protected void DeletePost_Click(object sender, EventArgs e)
        //{
        //    //string win2 = "did we get in?";
        //    int result = 0;

        //    FormsIdentity ident = User.Identity as FormsIdentity;
        //    FormsAuthenticationTicket ticket = ident.Ticket;
        //    string[] buffer = ticket.UserData.Split('|');
        //    string UserID = buffer[1];

        //    string objectSenderInf = (sender as Control).ClientID;
        //    int postID = RetrievePostID(objectSenderInf, Convert.ToInt32(UserID));

        //    result = myDal.deletePost(postID);

        //    if (result > 0)
        //    {
        //        postListView.DataSource = myDal.returnUserPosts(Convert.ToInt32(UserID));
        //        postListView.DataBind();
        //        //delete failed
        //    }
        //    else
        //    {
        //        //delete failed
        //    }
        //}

        //private bool checkIfEmpty()
        //{
        //    bool retval = true;
        //    string toDisplay = "*required field";

        //    if ((newTitle.Text == "") || (newTitle.Text == toDisplay))
        //    {
        //        newTitle.Text = toDisplay;
        //        newTitle.ForeColor = System.Drawing.Color.Red;
        //        retval = false;
        //    }
        //    if ((Author.Text == "") || (Author.Text == toDisplay))
        //    {
        //        Author.Text = toDisplay;
        //        Author.ForeColor = System.Drawing.Color.Red;
        //        retval = false;
        //    }
        //    if ((ISBN.Text == "") || (ISBN.Text == toDisplay))
        //    {
        //        ISBN.Text = toDisplay;
        //        ISBN.ForeColor = System.Drawing.Color.Red;
        //        retval = false;
        //    }
        //    if ((Edition.Text == "") || (Edition.Text == toDisplay))
        //    {
        //        Edition.Text = toDisplay;
        //        Edition.ForeColor = System.Drawing.Color.Red;
        //        retval = false;
        //    }
        //    if ((Publisher.Text == "") || (Publisher.Text == toDisplay))
        //    {
        //        Publisher.Text = toDisplay;
        //        Publisher.ForeColor = System.Drawing.Color.Red;
        //        retval = false;
        //    }

        //    InvalidCredentialsMessage.Text = toDisplay;
        //    InvalidCredentialsMessage.Visible = true;

        //    return retval;
        //}

        //protected void Admin_Click(object sender, EventArgs e)
        //{
        //    FormsIdentity ident = User.Identity as FormsIdentity;

        //    if (ident != null)
        //    {
        //        FormsAuthenticationTicket ticket = ident.Ticket;

        //        string[] buffer = ticket.UserData.Split('|');
        //        string GroupID = buffer[0];
        //        string UserID = buffer[1];

        //        if (Int32.Parse(GroupID) == 1)
        //        {
        //            Response.Redirect("ManageAccounts.aspx");
        //            //for system admin
        //        }
        //        else if (Int32.Parse(GroupID) == 2)
        //        {
        //            Response.Redirect("InstituteAdminIndex.aspx");
        //            //for instute admin
        //        }
        //    }
        //}
    }
}