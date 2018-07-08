using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using NAD_Final.Model;
/*
* FILE : AdminSetCourseBooks.aspx.cs
* PROJECT : NAD - Project 
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin, Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This file is the class for the AdminSetCourseBooks aspx page.
* 
*/

namespace NAD_Final
{

    public partial class AdminSetCourseBooks : System.Web.UI.Page
    {
        DAL myDal = new DAL();
        Logger logger = new Logger();
        User user = new User();


        DataTable allBookListTable = new DataTable();
        DataTable courseList = new DataTable();
        DataTable courseBookListTable = new DataTable();
        DataTable searchResultsTable = new DataTable();


        //static bool collegeLoaded = false;



        /*          METHOD HEADER
        * NAME: Page_Load
        * PURPOSE: Called when the page is initally loaded.
        *          Sets bindings on Institute Dropdown List.
        *          Also Binds all books to booklistview.
        * 
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable myDataTablee = new DataTable();
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

                        string[] buffer = ticket.UserData.Split('|');
                        string GroupID = buffer[0];
                        string UserID = buffer[1];

                        if (Int32.Parse(GroupID) < 3)
                        {
                            Button14.Visible = true;
                        }

                        // Bind Book ListView
                        allBookListTable = myDal.getStoredProcData("GetAllBooks");
                        AllBookListView.DataSource = allBookListTable;
                        AllBookListView.DataBind();

                        int currentUserID = 0;

                        // Get user ID
                        try
                        {
                            currentUserID = Int32.Parse(buffer[1]);
                        }
                        catch
                        {
                            currentUserID = 1;
                            logger.AddEventToLog("Couldnt Validate UserID Defaulting to Basic User", "Exception", "Login Page");
                        }

                        myDataTablee = myDal.GetInstituteIDByUserID(Int32.Parse(UserID));
                        int institution_id = Int32.Parse(myDataTablee.Rows[0].ItemArray[0].ToString());

                        // Bind Insitute Dropdown Based on User ID
                        CollegeListDropDown.DataTextField = "_institution_name";
                        CollegeListDropDown.DataSource = myDal.GetInstituteByUserID(currentUserID);// NEEDS TO GET USER ID 
                        CollegeListDropDown.DataBind();


                        //THIS NEEDS TO GET FIXED.
                        CourseDropDownList.DataTextField = "_course_name";
                        CourseDropDownList.DataSource = myDal.DisplayCoursesByInstitution(institution_id);
                        CourseDropDownList.DataBind();

                        string selectedCourse = CourseDropDownList.Text;
                        courseBookListTable = myDal.DisplayBooksByCourses(selectedCourse);
                        CourseBookListView.DataSource = courseBookListTable;
                        CourseBookListView.DataBind();

                        logger.AddEventToLog("Page Loaded Successfully", "Successful Operation", "Login Page");

                    }
                    else
                    {
                        Response.Redirect("~/LoginPage.aspx", true);
                    }
                }
            }
            else
            {
                Response.Redirect("~/LoginPage.aspx", true);
            }

           

        
        }

        /*          METHOD HEADER
         * NAME: CollegeListDropDown_SelectedIndexChanged
         * PURPOSE: Called when a different selection is chosen in College drop down list.
         *          Changes bindings on Course Dropdown list so they are always relevant.
         * 
         */
        protected void CollegeListDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = CollegeListDropDown.SelectedIndex + 1;
                CourseDropDownList.DataTextField = "_course_name";
                CourseDropDownList.DataSource = myDal.DisplayCoursesByInstitution(selectedIndex);
                CourseDropDownList.DataBind();
                //courseLoaded = true;
            }
            catch (Exception ex)
            {
                logger.AddEventToLog(ex.ToString(), "Exception", "Set Course Books");
            }


        }


        /*          METHOD HEADER
         * NAME: CourseDropDownList_SelectedIndexChanged
         * PURPOSE: Called when a different selection is chosen in Course drop down list.
         *          Changes bindings on Course Dropdown list so they are always relevant.
         * 
         */
        protected void CourseDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Populate CourseBookListView based on course with GetBooksByCourseName
            try
            {
                int selectedCourseIndex = CourseDropDownList.SelectedIndex + 1;
                string selectedCourse = CourseDropDownList.Text;
                courseBookListTable = myDal.DisplayBooksByCourses(selectedCourse);
                CourseBookListView.DataSource = courseBookListTable;
                CourseBookListView.DataBind();
            }
            catch (Exception ex)
            {
                logger.AddEventToLog(ex.ToString(), "Exception", "Set Course Books");
            }          
        }


        /*          METHOD HEADER
         * NAME: RemoveBtn_Click
         * PURPOSE: Remove selected book from course assosiated booklist.
         *          
         * 
         */
        protected void RemoveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // GET BUTTON ID
                Button myButton = (Button)sender;
                string input = myButton.ClientID.ToString();
                string index = input.Substring(input.Length - 1);
                int selectedIndex = Int32.Parse(index);

                // GET COURSE NAME FOR ID QUERY
                string selectedCourse = CourseDropDownList.Text;
                courseBookListTable = myDal.DisplayBooksByCourses(selectedCourse);
                DataRow foundRow = courseBookListTable.Rows[selectedIndex];

                if (foundRow != null)
                {
                    int bookID = (int)foundRow.ItemArray[2];
                    int courseID = (int)foundRow.ItemArray[0];
                    if (myDal.RemoveBookFromCourseBooklist(courseID, bookID) == 1)
                    {
                        string selectedCourse2 = CourseDropDownList.Text;
                        courseBookListTable = myDal.DisplayBooksByCourses(selectedCourse2);
                        CourseBookListView.DataSource = courseBookListTable;
                        CourseBookListView.DataBind();
                    }
                }
                logger.AddEventToLog("Removed book to course list", "Successful Operation", "Set Course Books");

            }
            catch (Exception ex)
            {
                logger.AddEventToLog(ex.ToString(), "Exception", "Set Course Books");
            }
            
        }


        /*          METHOD HEADER
        * NAME: AddBtn_Click
        * PURPOSE: Add book from booklistview to coursebookview and associate with course
        *          
        * 
        */
        protected void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // GET BOOK ID
                Button myButton = (Button)sender;
                string input = myButton.ClientID.ToString();
                string index = input.Substring(input.Length - 1);
                int selectedIndex = Int32.Parse(index);
                allBookListTable = myDal.getStoredProcData("GetAllBooks");
                DataRow foundRow = allBookListTable.Rows[selectedIndex];

                // GET COURSE ID
                searchResultsTable = myDal.GetCourseIDCourseName(CourseDropDownList.SelectedValue);
                DataRow foundRow2 = searchResultsTable.Rows[0];

                if (foundRow != null && foundRow2 != null)
                {
                    int bookID = (int)foundRow.ItemArray[0];
                    int courseID = (int)foundRow2.ItemArray[0];
                    if (myDal.AddCourseToCourseBookList(courseID, bookID) == 1)
                    {
                        string selectedCourse = CourseDropDownList.Text;
                        courseBookListTable = myDal.DisplayBooksByCourses(selectedCourse);
                        CourseBookListView.DataSource = courseBookListTable;
                        CourseBookListView.DataBind();

                    }
                }
                logger.AddEventToLog("Added book to course list", "Successful Operation", "Set Course Books");
                // Add selected book id to course materials table under course id
            }
            catch (Exception ex)
            {
                logger.AddEventToLog(ex.ToString(), "Exception", "Set Course Books");
            }
        }

        /*
        * FUNCTION : testbtn_Click
        *
        * DESCRIPTION : Used to refresh lists. Debugging Function.
        *
        */
        protected void testbtn_Click(object sender, EventArgs e)
        {
            courseBookListTable.Clear();
            // FOR TESTING.
            int selectedCourseIndex = CourseDropDownList.SelectedIndex + 1;
            string selectedCourse = CourseDropDownList.Text;
            courseBookListTable = myDal.DisplayBooksByCourses(selectedCourse);
            CourseBookListView.DataSource = courseBookListTable;
            CourseBookListView.DataBind();
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