using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using NAD_Final.Model;

/*
* FILE : Logger.cs
* PROJECT : NAD - Final
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin,Sean Moulton
* DESCRIPTION : Contains logic for the programs logging system
*/



namespace NAD_Final
{


    public class Logger
    {
        string title = "Log-";
        string extension = ".txt";
        string fileName = "";
        //string user = "";

        /*FunctionHeader
        * FUNCTION : AppendYMD
        *
        * DESCRIPTION : Append stamp of year,month,day
        */

        private string AppendYMD()
        {
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            return currentDate;
        }

        /*FunctionHeader
        * FUNCTION : AppendHMS
        *
        * DESCRIPTION :Append stamp of hour,minute,second
        *
        */
        private string AppendHMS()
        {
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return currentDate; 
        }

        /*FunctionHeader
* FUNCTION : AddEventToLog
*
* DESCRIPTION : Add event to log
*
* Add event to log
*/
        public void AddEventToLog(string eventToLog, string status, string location)
        {
            // CHANGE PATH FOR AZURE DB?
            string path = HttpContext.Current.Server.MapPath("~/App_Data");
            VerifyDir(path);

            fileName = title + AppendYMD() + extension;
            using (StreamWriter sw = File.AppendText(path + fileName))
            {
                sw.WriteLine("Event: " + eventToLog);
                sw.WriteLine("Status: " + status);
                sw.WriteLine("Time: " + AppendHMS());
                sw.WriteLine("Page: " + location);
            }           
        }

        /*FunctionHeader
        * FUNCTION : VerifyDir
        *
        * DESCRIPTION :  Verify exists or create folder and path.
        *
        */
        public static void VerifyDir(string path)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                if (!dir.Exists)
                {
                    dir.Create();
                }
            }
            catch { }
        }
    }    
}