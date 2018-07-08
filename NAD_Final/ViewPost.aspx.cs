
/*
* FILE : ViewPost.aspx.cs
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin,Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This file is the class for the viewPost page.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NAD_Final.Model;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Web.Security;

namespace NAD_Final
{


    public partial class ViewPost : System.Web.UI.Page
    {
        static int userID;
        DAL myDal = new DAL();

        Logger log = new Logger();

        //
        //  METHOD      : Page_Load
        //  DESCRIPTION : seeds the ListView
        //  PARAMETERS  : object sender, EventArgs e
        //  RETURNS     : void
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable idTable = new DataTable();
            DataTable courses = new DataTable();

            //Page Authentication 1
            if (Request.IsAuthenticated)
            {
                FormsIdentity ident = User.Identity as FormsIdentity;

                if (ident != null)
                {
                    FormsAuthenticationTicket ticket = ident.Ticket;
                    log.AddEventToLog("Identity Authenticated", "Audit", "ViewPost");
                    string[] buffer = ticket.UserData.Split('|');
                    string GroupID = buffer[0];
                    string UserID = buffer[1];

                    if (Int32.Parse(GroupID) < 3)
                    {
                        Button14.Visible = true;
                    }
                }

                string value = Request.QueryString["PostID"];
                int postID = Convert.ToInt32(value);
                object[] resultSet = myDal.displayPost(postID).Rows[0].ItemArray;

                ViewPostTitle.Text = resultSet[0].ToString() + " " + resultSet[1].ToString() + "'s " + "Post";

                postOwner.Text = resultSet[0].ToString() + " " + resultSet[1].ToString();
                price.Text = resultSet[2].ToString();
                newTitle.Text = resultSet[3].ToString();
                Author.Text = resultSet[4].ToString();
                ISBN.Text = resultSet[5].ToString();
                Edition.Text = resultSet[6].ToString();
                Publisher.Text = resultSet[7].ToString();

                //need course descriptions here
                //TextBox5 is course description;
                string courseDescriptions = "";

                idTable = myDal.GetCourseIDsByBookTitle(newTitle.Text);
                for (int i = 0; i < idTable.Rows.Count; i++)
                {
                    courses = myDal.GetCourseDescriptionByCourseID(Int32.Parse(idTable.Rows[i].ItemArray[0].ToString()));
                    //Title
                    courseDescriptions += "Course:  " + courses.Rows[0].ItemArray[0].ToString() + "\n";
                    //Description
                    courses.Rows[0].ItemArray[1].ToString();
                    courseDescriptions += "Course Description:\n" + courses.Rows[0].ItemArray[1].ToString() + "\n\n\n";
                    courses.Clear();
                }

                TextBox5.Text = courseDescriptions;

                ViewState["postOwnerEmail"] = resultSet[8].ToString();
                ViewState["title"] = "inquiry regarding \"" + newTitle.Text+"\"";
            }
            else
            {
                Response.Redirect("~/LoginPage.aspx");
                log.AddEventToLog("Identity Not Authenticated", "Audit", "ResetPassword");
            }
        }

        /*
        * FUNCTION : SetUserIDFromPost
        *
        * DESCRIPTION : 
        *
        * PARAMETERS : 
        *
        * RETURNS : 
        */
        public void SetUserIDFromPost(int id)
        {
            userID = id;       
        }


        //
        //  METHOD      : GetUserIDFromPost
        //  DESCRIPTION :
        //  PARAMETERS  : n/a
        //  RETURNS     : int
        //
        public int GetUserIDFromPost()
        {
            return userID;
        }

        //
        //  METHOD      : sendMail
        //  DESCRIPTION :
        //  PARAMETERS  : object sender, EventArgs e
        //  RETURNS     : void
        //

        protected void sendMail(object sender, EventArgs e)
        {
            SendEmail(ViewState["postOwnerEmail"].ToString(),TextBox1.Text, ViewState["title"].ToString(), TextBox2.Text);
        }

        //
        //  METHOD      : SendEmail
        //  DESCRIPTION :
        //  PARAMETERS  : string toEmail, string fromEmail, string title, string bod
        //  RETURNS     : void
        //
        protected void SendEmail(string toEmail, string fromEmail, string title, string body)
        {

            using (MailMessage mm = new MailMessage("donotreply.studenttextbook@gmail.com", toEmail))
            {
                mm.Subject = title;
                mm.Body = "\n" + body + "\n\n\nTo get back to the sender reply at:\n" + fromEmail;

                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("donotreply.studenttextbook@gmail.com", "buyandsell");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);

                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
                log.AddEventToLog("Email Sent to Post Owner", "Audit", "ViewPost");
            }
        }

        //
        //  METHOD      : Admin_Click
        //  DESCRIPTION :
        //  PARAMETERS  : object sender, EventArgs e
        //  RETURNS     : void
        //

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