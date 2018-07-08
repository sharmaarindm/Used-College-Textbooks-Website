/*
* FILE : DAL.cs
* PROJECT : NAD - Final
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin,Sean Moulton
* DESCRIPTION : This file is the data access layer for this project. All the methods are accessed from here within in the program
*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.IO;
using System.Web.Hosting;
using NAD_Final.Model;


namespace NAD_Final.Model
{
    public class DAL
    {
        SqlConnection mySQLConnection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["DalConnectString"].ConnectionString);
        //SqlCommand cmd = new SqlCommand();

        public void OpenConnection()
        {
            mySQLConnection.Open();
        }

        //
        //  METHOD      : CloseConnection
        //  DESCRIPTION : close connection to database
        //  PARAMETERS  : na
        //  RETURNS     : void
        //
        public void CloseConnection()
        {
            mySQLConnection.Close();
        }


        //public DataTable selectAllPosts()
        //{
        //    DataTable results = new DataTable();

        //    cmd.CommandText = "SELECT * FROM _Post";
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = mySQLConnection;

        //    OpenConnection();

        //    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        //    {
        //        da.Fill(results);
        //    }

        //    CloseConnection();

        //    return results;
        //}






        #region browse


        //
        //  METHOD      : returnTitleResults
        //  DESCRIPTION : returns the title of the book
        //  PARAMETERS  : string value
        //  RETURNS     : DataTable
        //
        public DataTable returnTitleResults(string value)
        {

            //uncomment this section to run properly
            DataTable results = new DataTable();

            SqlCommand mySQLCommand = new SqlCommand(
                 "BrowseTextbooksbyTitle", mySQLConnection);

            mySQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

            mySQLCommand.Parameters.Add("@param", SqlDbType.VarChar).Value = value;

            mySQLCommand.Connection = mySQLConnection;

            OpenConnection();

            using (SqlDataAdapter da = new SqlDataAdapter(mySQLCommand))
            {
                da.Fill(results);
            }

            CloseConnection();
            // end of uncommented section

            return results;

        }

        //
        //  METHOD      : returnTitleResults
        //  DESCRIPTION : returns the title of the book and institute
        //  PARAMETERS  : string book_name, string institution_name
        //  RETURNS     : DataTable
        //
        public DataTable returnTitleResults(string book_name, string institution_name)
        {
            //uncomment this section to run properly
            DataTable results = new DataTable();

            SqlCommand mySQLCommand = new SqlCommand(
                 "BrowseTxtbooksbyTitleAndInstitution", mySQLConnection);

            mySQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

            mySQLCommand.Parameters.Add("@book_title", SqlDbType.VarChar).Value = book_name;
            mySQLCommand.Parameters.Add("@institute", SqlDbType.VarChar).Value = institution_name;

            mySQLCommand.Connection = mySQLConnection;

            OpenConnection();

            using (SqlDataAdapter da = new SqlDataAdapter(mySQLCommand))
            {
                da.Fill(results);
            }

            CloseConnection();
            // end of uncommented section

            return results;
        }


        //
        //  METHOD      : returnISBNResults
        //  DESCRIPTION : returns the title of the book and institute
        //  PARAMETERS  : This method returns the datatable of the textbook ISBNs
        //  RETURNS     : DataTable
        //
        public DataTable returnISBNResults(string value)
        {
            DataTable results = new DataTable();

            SqlCommand mySQLCommand = new SqlCommand(
                 "BrowseTextbooksbyISBN", mySQLConnection);

            mySQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

            mySQLCommand.Parameters.Add("@param", SqlDbType.VarChar).Value = value;

            mySQLCommand.Connection = mySQLConnection;

            OpenConnection();

            using (SqlDataAdapter da = new SqlDataAdapter(mySQLCommand))
            {
                da.Fill(results);
            }

            CloseConnection();
            // end of uncommented section

            return results;
        }


        //
        //  METHOD      : returnISBNResults
        //  DESCRIPTION : returns the title of the book and institute
        //  PARAMETERS  : string isbn, string institution_name
        //  RETURNS     : DataTable
        //
        public DataTable returnISBNResults(string isbn, string institution_name)
        {
            DataTable results = new DataTable();

            SqlCommand mySQLCommand = new SqlCommand(
                 "BrowseTxtbooksbyISBNAndInstitution", mySQLConnection);

            mySQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

            mySQLCommand.Parameters.Add("@ISBN", SqlDbType.VarChar).Value = isbn;
            mySQLCommand.Parameters.Add("@institute", SqlDbType.VarChar).Value = institution_name;

            mySQLCommand.Connection = mySQLConnection;

            OpenConnection();

            using (SqlDataAdapter da = new SqlDataAdapter(mySQLCommand))
            {
                da.Fill(results);
            }

            CloseConnection();
            // end of uncommented section

            return results;
        }

        public DataTable returnAuthorResults(string value)
        {
            DataTable results = new DataTable();

            SqlCommand mySQLCommand = new SqlCommand(
                 "BrowseTextbooksbyAuthor", mySQLConnection);

            mySQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

            mySQLCommand.Parameters.Add("@param", SqlDbType.VarChar).Value = value;

            mySQLCommand.Connection = mySQLConnection;

            OpenConnection();

            using (SqlDataAdapter da = new SqlDataAdapter(mySQLCommand))
            {
                da.Fill(results);
            }

            CloseConnection();
            // end of uncommented section

            return results;

        }

        public DataTable returnAuthorResults(string author, string institution_name)
        {
            DataTable results = new DataTable();

            SqlCommand mySQLCommand = new SqlCommand(
                 "BrowseTxtbooksbyAuthorAndInstitution", mySQLConnection);

            mySQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

            mySQLCommand.Parameters.Add("@author", SqlDbType.VarChar).Value = author;
            mySQLCommand.Parameters.Add("@institute", SqlDbType.VarChar).Value = institution_name;

            mySQLCommand.Connection = mySQLConnection;

            OpenConnection();

            using (SqlDataAdapter da = new SqlDataAdapter(mySQLCommand))
            {
                da.Fill(results);
            }

            CloseConnection();
            // end of uncommented section

            return results;
        }

        #endregion
        //
        //  METHOD      : DisplayCoursesByInstitution
        //  DESCRIPTION : Displayys the courses by providing the institutionID
        //  PARAMETERS  : int institutionID
        //  RETURNS     : DataTable
        //
        public DataTable DisplayCoursesByInstitution(int institutionID)
        {
            DataTable myDataTable = new DataTable();
            SqlCommand mySQLCommand = new SqlCommand(
                "GetCoursesByInstitutionID", mySQLConnection);
            mySQLCommand.CommandType = CommandType.StoredProcedure;
            mySQLCommand.Parameters.Add("@param", SqlDbType.VarChar).Value = institutionID;

            mySQLCommand.Connection = mySQLConnection;
            OpenConnection();
            using (SqlDataAdapter da = new SqlDataAdapter(mySQLCommand))
            {
                da.Fill(myDataTable);
            }

            CloseConnection();
            return myDataTable;
        }

        //
        //  METHOD      : GetCourseIDCourseName
        //  DESCRIPTION : Gets the course ID from the course name provided
        //  PARAMETERS  : string courseName
        //  RETURNS     : DataTable
        //

        public DataTable GetCourseIDCourseName(string courseName)
        {
            DataTable myDataTable = new DataTable();

            SqlCommand mySQLCommand = new SqlCommand("GetCourseIDByCourseName", mySQLConnection);

            mySQLCommand.CommandType = CommandType.StoredProcedure;

            mySQLCommand.Parameters.Add("@param", SqlDbType.VarChar).Value = courseName;

            mySQLCommand.Connection = mySQLConnection;

            OpenConnection();

            using (SqlDataAdapter da = new SqlDataAdapter(mySQLCommand))
            {
                da.Fill(myDataTable);
            }

            CloseConnection();

            return myDataTable;
        }

        //
        //  METHOD      : GetInstituteByUserID
        //  DESCRIPTION : Gets the institution by the user ID provided
        //  PARAMETERS  : int userID
        //  RETURNS     : DataTable
        //
        public DataTable GetInstituteByUserID(int userID)
        {
            DataTable myDataTable = new DataTable();

            SqlCommand mySQLCommand = new SqlCommand("GetInstitutionByUserID", mySQLConnection);

            mySQLCommand.CommandType = CommandType.StoredProcedure;

            mySQLCommand.Parameters.Add("@param", SqlDbType.Int).Value = userID;

            mySQLCommand.Connection = mySQLConnection;

            OpenConnection();

            using (SqlDataAdapter da = new SqlDataAdapter(mySQLCommand))
            {
                da.Fill(myDataTable);
            }

            CloseConnection();

            return myDataTable;
        }

        //
        //  METHOD      : AddCourseToCourseBookList
        //  DESCRIPTION : Adds the course to course books
        //  PARAMETERS  : int courseID, int bookID
        //  RETURNS     : DataTable
        //
        public int AddCourseToCourseBookList(int courseID, int bookID)
        {
            int result = 0;


            DataTable myDataTable = new DataTable();

            SqlCommand mySQLCommand = new SqlCommand("AddBookToCourseMaterials", mySQLConnection);

            mySQLCommand.CommandType = CommandType.StoredProcedure;

            mySQLCommand.Parameters.Add("@param1", SqlDbType.Int).Value = courseID;

            mySQLCommand.Parameters.Add("@param2", SqlDbType.Int).Value = bookID;

            mySQLCommand.Connection = mySQLConnection;

            OpenConnection();

            result = mySQLCommand.ExecuteNonQuery();

            CloseConnection();

            return result;
        }

        //
        //  METHOD      : RemoveBookFromCourseBooklist
        //  DESCRIPTION : Deletes a boom from the course material
        //  PARAMETERS  : int courseID, int bookID
        //  RETURNS     : DataTable
        //
        public int RemoveBookFromCourseBooklist(int courseID, int bookID)
        {
            int result = 0;

            DataTable myDataTable = new DataTable();

            SqlCommand mySQLCommand = new SqlCommand("DeleteBookFromCourseMaterials", mySQLConnection);

            mySQLCommand.CommandType = CommandType.StoredProcedure;

            mySQLCommand.Parameters.Add("@param1", SqlDbType.Int).Value = courseID;

            mySQLCommand.Parameters.Add("@param2", SqlDbType.Int).Value = bookID;

            mySQLCommand.Connection = mySQLConnection;

            OpenConnection();

            result = mySQLCommand.ExecuteNonQuery();

            CloseConnection();

            return result;
        }

        //
        //  METHOD      : DisplayBooksByCourses
        //  DESCRIPTION : Gets a book by a course name
        //  PARAMETERS  : string course
        //  RETURNS     : DataTable
        //

        public DataTable DisplayBooksByCourses(string course)
        {
            DataTable myDataTable = new DataTable();

            SqlCommand mySQLCommand = new SqlCommand("GetBooksByCourseName", mySQLConnection);

            mySQLCommand.CommandType = CommandType.StoredProcedure;

            mySQLCommand.Parameters.Add("@param", SqlDbType.VarChar).Value = course;

            mySQLCommand.Connection = mySQLConnection;

            OpenConnection();

            using (SqlDataAdapter da = new SqlDataAdapter(mySQLCommand))
            {
                da.Fill(myDataTable);
            }

            CloseConnection();

            return myDataTable;
        }


        //
        //  METHOD      : retrievePostByPostID
        //  DESCRIPTION : views a post by post ID
        //  PARAMETERS  : int post_id
        //  RETURNS     : DataTable
        //
        public DataTable retrievePostByPostID(int post_id)
        {
            //ViewPostByPostID
            DataTable results = new DataTable();

            SqlCommand mySQLCommand = new SqlCommand(
                 "ViewPostByPostID", mySQLConnection);

            mySQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

            mySQLCommand.Parameters.Add("@param", SqlDbType.VarChar).Value = post_id;

            mySQLCommand.Connection = mySQLConnection;

            OpenConnection();

            using (SqlDataAdapter da = new SqlDataAdapter(mySQLCommand))
            {
                da.Fill(results);
            }

            CloseConnection();
            // end of uncommented section

            return results;
        }


        //
        //  METHOD      : returnUserPosts
        //  DESCRIPTION : views a post by user ID
        //  PARAMETERS  : int user_id
        //  RETURNS     : DataTable
        //
        public DataTable returnUserPosts(int user_id)
        {
            DataTable results = new DataTable();

            SqlCommand mySQLCommand = new SqlCommand(
                 "ViewPostByUserID", mySQLConnection);

            mySQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

            mySQLCommand.Parameters.Add("@param", SqlDbType.VarChar).Value = user_id;

            mySQLCommand.Connection = mySQLConnection;

            OpenConnection();

            using (SqlDataAdapter da = new SqlDataAdapter(mySQLCommand))
            {
                da.Fill(results);
            }

            CloseConnection();
            // end of uncommented section

            return results;
        }

        //
        //  METHOD      : CreatePosting
        //  DESCRIPTION : views a post by user ID
        //  PARAMETERS  : string title, string author, string isbn, int edition, string publisher, double price, DateTime postExpire, int userID, DateTime postdate
        //  RETURNS     : int
        //

        public int CreatePosting(string title, string author, string isbn, int edition, string publisher, double price, DateTime postExpire, int userID, DateTime postdate)
        {
            int results = 0;

            SqlCommand mySQLCommand = new SqlCommand(
                "CreatePosting", mySQLConnection);

            mySQLCommand.CommandType = CommandType.StoredProcedure;

            mySQLCommand.Parameters.Add("@bookTitle", SqlDbType.VarChar).Value = title;
            mySQLCommand.Parameters.Add("@bookAuthor", SqlDbType.VarChar).Value = author;
            mySQLCommand.Parameters.Add("@bookISBN", SqlDbType.VarChar).Value = isbn;
            mySQLCommand.Parameters.Add("@bookEdition", SqlDbType.Int).Value = edition;
            mySQLCommand.Parameters.Add("@bookPublisher", SqlDbType.VarChar).Value = publisher;
            mySQLCommand.Parameters.Add("@price", SqlDbType.Float).Value = (float)price;
            mySQLCommand.Parameters.Add("@postExpire", SqlDbType.DateTime).Value = postExpire;
            mySQLCommand.Parameters.Add("@UserID", SqlDbType.Int).Value = userID;
            mySQLCommand.Parameters.Add("@postdate", SqlDbType.DateTime).Value = postdate;

            mySQLCommand.Connection = mySQLConnection;

            OpenConnection();

            results = mySQLCommand.ExecuteNonQuery();

            CloseConnection();

            //return the number of rows affected.
            return results;
        }

        //
        //  METHOD      : getStoredProcData
        //  DESCRIPTION : get stored procedure data
        //  PARAMETERS  : string procToExec
        //  RETURNS     : DataTable
        //

        public DataTable getStoredProcData(string procToExec)
        {
            DataTable results = new DataTable();

            SqlCommand mySQLCommand = new SqlCommand(procToExec, mySQLConnection);

            mySQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

            mySQLCommand.Connection = mySQLConnection;

            OpenConnection();

            using (SqlDataAdapter da = new SqlDataAdapter(mySQLCommand))
            {
                da.Fill(results);
            }

            CloseConnection();
            // end of uncommented section

            return results;
        }


        //
        //  METHOD      : CreateStudentUser
        //  DESCRIPTION : Create a student user
        //  PARAMETERS  : User userobj
        //  RETURNS     : int
        //
        public int CreateStudentUser(User userobj)
        {
            int results = 0;

            SqlCommand mySQLCommand = new SqlCommand("CreateStudentUser", mySQLConnection);

            mySQLCommand.CommandType = CommandType.StoredProcedure;

            mySQLCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userobj.UserName;
            mySQLCommand.Parameters.Add("@hashpass", SqlDbType.VarChar).Value = userobj.hashpass;
            mySQLCommand.Parameters.Add("@fname", SqlDbType.VarChar).Value = userobj.fname;
            mySQLCommand.Parameters.Add("@lname", SqlDbType.VarChar).Value = userobj.lname;
            mySQLCommand.Parameters.Add("@institute", SqlDbType.VarChar).Value = userobj.institute;
            mySQLCommand.Parameters.Add("@yearOfGraduation", SqlDbType.VarChar).Value = userobj.yearOfGraduation;
            mySQLCommand.Parameters.Add("@salt", SqlDbType.VarChar).Value = userobj.userSalt;

            mySQLCommand.Connection = mySQLConnection;

            OpenConnection();

            results = mySQLCommand.ExecuteNonQuery();

            CloseConnection();

            //return the number of rows affected.
            return results;
        }

        //
        //  METHOD      : displayPost
        //  DESCRIPTION : Display a post method
        //  PARAMETERS  : int id
        //  RETURNS     : DataTable
        //

        public DataTable displayPost(int id)
        {
            DataTable myDataTable = new DataTable();
            SqlCommand mySQLCommand = new SqlCommand(
                "getpostbypostid", mySQLConnection);

            mySQLCommand.CommandType = CommandType.StoredProcedure;
            mySQLCommand.Parameters.Add("@param", SqlDbType.Int).Value = id;

            mySQLCommand.Connection = mySQLConnection;
            OpenConnection();
            using (SqlDataAdapter da = new SqlDataAdapter(mySQLCommand))
            {
                da.Fill(myDataTable);
            }

            CloseConnection();

            return myDataTable;
        }
        //
        //  METHOD      : addInstitute
        //  DESCRIPTION : Add institution to the database
        //  PARAMETERS  : string instiName
        //  RETURNS     : bool
        //
        public bool addInstitute(string instiName)
        {
            bool flag = true;
            int retVal = 0;

            SqlCommand mySQLCommand = new SqlCommand(
                "AddInstitute", mySQLConnection);
            mySQLCommand.CommandType = CommandType.StoredProcedure;
            mySQLCommand.Parameters.Add("@param", SqlDbType.VarChar).Value = instiName;

            mySQLCommand.Connection = mySQLConnection;
            OpenConnection();
            retVal = mySQLCommand.ExecuteNonQuery();
            CloseConnection();
            if (retVal == -1)
            {
                flag = false;
            }

            return flag;
        }

        //
        //  METHOD      : returnUserForUsername
        //  DESCRIPTION : returnUserForUsername
        //  PARAMETERS  : string UserName
        //  RETURNS     : DataTable
        //
        public DataTable returnUserForUsername(string UserName)
        {

            //uncomment this section to run properly
            DataTable results = new DataTable();

            SqlCommand mySQLCommand = new SqlCommand("getuserbyuserName", mySQLConnection);

            mySQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

            mySQLCommand.Parameters.Add("@param", SqlDbType.VarChar).Value = UserName;

            using (SqlDataAdapter da = new SqlDataAdapter(mySQLCommand))
            {
                da.Fill(results);
            }



            CloseConnection();

            return results;
        }


        //
        //  METHOD      : updatePost
        //  DESCRIPTION : update a bost 
        //  PARAMETERS  : int postID, string title, string author, string isbn, int edition, string publisher, float price
        //  RETURNS     : int
        //

        public int updatePost(int postID, string title, string author, string isbn, int edition, string publisher, float price)
        {

            int results = 0;

            SqlCommand mySQLCommand = new SqlCommand("UpdatePosting", mySQLConnection);

            mySQLCommand.CommandType = CommandType.StoredProcedure;

            mySQLCommand.Parameters.Add("@postID", SqlDbType.Int).Value = postID;
            mySQLCommand.Parameters.Add("@bookTitle", SqlDbType.VarChar).Value = title;
            mySQLCommand.Parameters.Add("@bookAuthor", SqlDbType.VarChar).Value = author;
            mySQLCommand.Parameters.Add("@bookISBN", SqlDbType.VarChar).Value = isbn;
            mySQLCommand.Parameters.Add("@bookEdition", SqlDbType.Int).Value = edition;
            mySQLCommand.Parameters.Add("@bookPublisher", SqlDbType.VarChar).Value = publisher;
            mySQLCommand.Parameters.Add("@price", SqlDbType.Float).Value = price;

            mySQLCommand.Connection = mySQLConnection;

            OpenConnection();

            results = mySQLCommand.ExecuteNonQuery();

            CloseConnection();

            return results;
        }

        //
        //  METHOD      : deletePost
        //  DESCRIPTION : deletePost 
        //  PARAMETERS  : int postID
        //  RETURNS     : int
        //
        public int deletePost(int postID)
        {
            int results = 0;

            SqlCommand mySQLCommand = new SqlCommand("DeletePostByPostID", mySQLConnection);

            mySQLCommand.CommandType = CommandType.StoredProcedure;

            mySQLCommand.Parameters.Add("@param", SqlDbType.Int).Value = postID;

            mySQLCommand.Connection = mySQLConnection;

            OpenConnection();


            results = mySQLCommand.ExecuteNonQuery();

            CloseConnection();
            // end of uncommented section

            return results;

            //return cheeseIt();
        }

        //
        //  METHOD      : displayInstitutions
        //  DESCRIPTION : deletePost 
        //  PARAMETERS  : int postID
        //  RETURNS     : DataTable
        //
        public DataTable displayInstitutions()
        {
            DataTable myDataTable = new DataTable();
            SqlCommand mySQLCommand = new SqlCommand(
                "GetInstitutes", mySQLConnection);
            mySQLCommand.CommandType = CommandType.StoredProcedure;

            mySQLCommand.Connection = mySQLConnection;
            OpenConnection();
            using (SqlDataAdapter da = new SqlDataAdapter(mySQLCommand))
            {
                da.Fill(myDataTable);
            }

            CloseConnection();



            return myDataTable;
        }

        //
        //  METHOD      : editInstitution
        //  DESCRIPTION : editInstitution by providing the institution name and the new institution name
        //  PARAMETERS  : string instName, string newInstName
        //  RETURNS     : void
        //
        public void editInstitution(string instName, string newInstName)
        {
            SqlCommand mySQLCommand = new SqlCommand(
                "EditInstitute", mySQLConnection);
            mySQLCommand.CommandType = CommandType.StoredProcedure;
            mySQLCommand.Parameters.Add("@oldValue", SqlDbType.VarChar).Value = instName;
            mySQLCommand.Parameters.Add("@newValue", SqlDbType.VarChar).Value = newInstName;

            mySQLCommand.Connection = mySQLConnection;
            OpenConnection();
            mySQLCommand.ExecuteNonQuery();
            CloseConnection();

        }

        //
        //  METHOD      : deleteInstitution
        //  DESCRIPTION : Delete an institution
        //  PARAMETERS  : string instToDel
        //  RETURNS     : int
        //
        public int deleteInstitution(string instToDel)
        {
            int retVal;
            SqlCommand mySQLCommand = new SqlCommand(
                "DeleteInstitute", mySQLConnection);
            mySQLCommand.CommandType = CommandType.StoredProcedure;
            mySQLCommand.Parameters.Add("@InstituteName", SqlDbType.VarChar).Value = instToDel;

            mySQLCommand.Connection = mySQLConnection;
            OpenConnection();
            try
            {
                retVal = mySQLCommand.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException)
            {

                return 0;
            }
            CloseConnection();

            return retVal;
        }


        //
        //  METHOD      : displayAllInstAmins
        //  DESCRIPTION : Display all institutions
        //  PARAMETERS  : void
        //  RETURNS     : DataTable
        //
        public DataTable displayAllInstAmins()
        {
            DataTable myDataTable = new DataTable();

            SqlCommand mySQLCommand = new SqlCommand(
                "getInstituteAdmin", mySQLConnection);
            mySQLCommand.CommandType = CommandType.StoredProcedure;

            mySQLCommand.Connection = mySQLConnection;
            OpenConnection();
            using (SqlDataAdapter da = new SqlDataAdapter(mySQLCommand))
            {
                da.Fill(myDataTable);
            }

            CloseConnection();



            return myDataTable;
        }
        //
        //  METHOD      : DeleteInstAdmin
        //  DESCRIPTION : Delete institution admin by his name
        //  PARAMETERS  : string adminName
        //  RETURNS     : int
        //
        public int DeleteInstAdmin(string adminName)
        {
            int retVal;

            SqlCommand mySQLCommand = new SqlCommand(
                "DeleteInstituteAdmin", mySQLConnection);
            mySQLCommand.CommandType = CommandType.StoredProcedure;
            mySQLCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = adminName;

            mySQLCommand.Connection = mySQLConnection;
            OpenConnection();
            try
            {
                retVal = mySQLCommand.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException)
            {

                return 0;
            }
            CloseConnection();

            return retVal;

        }
        //
        //  METHOD      : editAdmin
        //  DESCRIPTION : Edit admin
        //  PARAMETERS  : string instName, string fName, string lName, string userName, string pass, string salty
        //  RETURNS     : int
        //
        public int editAdmin(string instName, string fName, string lName, string userName, string pass, string salty)
        {


            int retVal;

            SqlCommand mySQLCommand = new SqlCommand(
                "UpdateInstituteAdmin", mySQLConnection);
            mySQLCommand.CommandType = CommandType.StoredProcedure;

            mySQLCommand.Parameters.Add("@institution_Name", SqlDbType.VarChar).Value = instName;
            mySQLCommand.Parameters.Add("@first_name", SqlDbType.VarChar).Value = fName;
            mySQLCommand.Parameters.Add("@last_name", SqlDbType.VarChar).Value = lName;
            mySQLCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = userName;
            mySQLCommand.Parameters.Add("@password", SqlDbType.VarChar).Value = pass;
            mySQLCommand.Parameters.Add("@salt", SqlDbType.VarChar).Value = salty;

            mySQLCommand.Connection = mySQLConnection;

            OpenConnection();

            try
            {
                retVal = mySQLCommand.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException)
            {

                return 0;
            }

            CloseConnection();



            return retVal;
        }

        //
        //  METHOD      : retrieveUserIDByEmail
        //  DESCRIPTION : Edit admin
        //  PARAMETERS  : string email
        //  RETURNS     : DataTable
        //

        public DataTable retrieveUserIDByEmail(string email)
        {

            DataTable myDataTable = new DataTable();


            SqlCommand mySQLCommand = new SqlCommand(
                "getUIDfromEmail", mySQLConnection);

            mySQLCommand.CommandType = CommandType.StoredProcedure;
            mySQLCommand.Parameters.Add("@param", SqlDbType.VarChar).Value = email;

            mySQLCommand.Connection = mySQLConnection;
            OpenConnection();


            using (SqlDataAdapter da = new SqlDataAdapter(mySQLCommand))
            {
                da.Fill(myDataTable);
            }

            CloseConnection();

            return myDataTable;
        }

        //
        //  METHOD      : AddInstituteAdmin
        //  DESCRIPTION : AddInstituteAdmin
        //  PARAMETERS  : string institutionName, string firstName, string lastName, string userName, string password, string salt
        //  RETURNS     : int
        //
        public int AddInstituteAdmin(string institutionName, string firstName, string lastName, string userName, string password, string salt)
        {
            int retVal;

            SqlCommand mySQLCommand = new SqlCommand(
                "AddInstituteAdmin", mySQLConnection);
            mySQLCommand.CommandType = CommandType.StoredProcedure;

            mySQLCommand.Parameters.Add("@institution_Name", SqlDbType.VarChar).Value = institutionName;
            mySQLCommand.Parameters.Add("@first_name", SqlDbType.VarChar).Value = firstName;
            mySQLCommand.Parameters.Add("@last_name", SqlDbType.VarChar).Value = lastName;
            mySQLCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = userName;
            mySQLCommand.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
            mySQLCommand.Parameters.Add("@salt", SqlDbType.VarChar).Value = salt;

            mySQLCommand.Connection = mySQLConnection;
            OpenConnection();

            try
            {
                retVal = mySQLCommand.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException)
            {

                return 0;
            }
            CloseConnection();


            return retVal;

        }


        //
        //  METHOD      : CheckifUserExists
        //  DESCRIPTION : CheckifUserExists
        //  PARAMETERS  : string username
        //  RETURNS     : int
        //
        public int CheckifUserExists(string username)
        {
            int retVal;

            SqlCommand mySQLCommand = new SqlCommand(
                "checkifUserExists", mySQLConnection);
            mySQLCommand.CommandType = CommandType.StoredProcedure;

            mySQLCommand.Parameters.Add("@param", SqlDbType.VarChar).Value = username;

            mySQLCommand.Connection = mySQLConnection;
            OpenConnection();

            DataTable myDataTable = new DataTable();

            using (SqlDataAdapter da = new SqlDataAdapter(mySQLCommand))
            {
                da.Fill(myDataTable);
            }

            CloseConnection();

            if (myDataTable.Rows.Count > 0)
            {
                retVal = 0;
            }
            else
            {
                retVal = -1;
            }
            return retVal;

        }


        //
        //  METHOD      : updatehashsalt
        //  DESCRIPTION : CheckifUserExists
        //  PARAMETERS  : string username,string hash, string salt
        //  RETURNS     : int
        //
        public int updatehashsalt(string username, string hash, string salt)
        {
            int retVal;

            SqlCommand mySQLCommand = new SqlCommand(
                "editSaltHash", mySQLConnection);
            mySQLCommand.CommandType = CommandType.StoredProcedure;

            mySQLCommand.Parameters.Add("@hash", SqlDbType.VarChar).Value = hash;
            mySQLCommand.Parameters.Add("@salt", SqlDbType.VarChar).Value = salt;
            mySQLCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = username;


            mySQLCommand.Connection = mySQLConnection;
            OpenConnection();

            try
            {
                retVal = mySQLCommand.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException)
            {

                return 0;
            }
            CloseConnection();


            return retVal;

        }


        //
        //  METHOD      : GetCourseIDsByBookTitle
        //  DESCRIPTION : GetCourseIDsByBookTitle
        //  PARAMETERS  : string book_title
        //  RETURNS     : DataTable
        //

        public DataTable GetCourseIDsByBookTitle(string book_title)
        {
            int retVal;

            SqlCommand mySQLCommand = new SqlCommand(
                "GetCourseIDsByBookTitle", mySQLConnection);
            mySQLCommand.CommandType = CommandType.StoredProcedure;

            mySQLCommand.Parameters.Add("@book_title", SqlDbType.VarChar).Value = book_title;

            mySQLCommand.Connection = mySQLConnection;
            OpenConnection();

            DataTable myDataTable = new DataTable();

            using (SqlDataAdapter da = new SqlDataAdapter(mySQLCommand))
            {
                da.Fill(myDataTable);
            }

            CloseConnection();

            if (myDataTable.Rows.Count > 0)
            {
                retVal = 0;
            }
            else
            {
                retVal = -1;
            }
            return myDataTable;
        }


        //
        //  METHOD      : GetCourseDescriptionByCourseID
        //  DESCRIPTION : GetCourseDescriptionByCourseID
        //  PARAMETERS  : int course_id
        //  RETURNS     : DataTable
        //
        public DataTable GetCourseDescriptionByCourseID(int course_id)
        {
            int retVal;

            SqlCommand mySQLCommand = new SqlCommand(
                "GetCourseDescriptionByCourseID", mySQLConnection);
            mySQLCommand.CommandType = CommandType.StoredProcedure;

            mySQLCommand.Parameters.Add("@course_id", SqlDbType.Int).Value = course_id;

            mySQLCommand.Connection = mySQLConnection;
            OpenConnection();

            DataTable myDataTable = new DataTable();

            using (SqlDataAdapter da = new SqlDataAdapter(mySQLCommand))
            {
                da.Fill(myDataTable);
            }

            CloseConnection();

            if (myDataTable.Rows.Count > 0)
            {
                retVal = 0;
            }
            else
            {
                retVal = -1;
            }
            return myDataTable;
        }
    }
}



