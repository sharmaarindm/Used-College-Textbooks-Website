using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace NAD_Final.Model
{
    public class User
    {
        /*FunctionHeader
        * FUNCTION : UserID
        *
        * DESCRIPTION : Accessor for
        *
        */
        public int UserID { get; set; }
        /*FunctionHeader
        * FUNCTION : userGroupId
        *
        * DESCRIPTION : Accessor for
        *
        */
        public string userGroupId { get; set; }
        /*FunctionHeader
        * FUNCTION : UserName
        *
        * DESCRIPTION : Accessor for
        *
        */
        public string UserName { get; set; }
        /*FunctionHeader
        * FUNCTION : hashpass
        *
        * DESCRIPTION : Accessor for
        *
        */
        public string hashpass { get; set; }
        /*FunctionHeader
        * FUNCTION : fname
        *
        * DESCRIPTION : Accessor for
        *
        */
        public string fname { get; set; }
        /*FunctionHeader
        * FUNCTION : lname
        *
        * DESCRIPTION : Accessor for
        *
        */
        public string lname { get; set; }
        /*FunctionHeader
        * FUNCTION : institute
        *
        * DESCRIPTION : Accessor for
        */
        public string institute { get; set; }
        /*FunctionHeader
        * FUNCTION : yearOfGraduation
        *
        * DESCRIPTION : Accessor for
        *
        */
        public string yearOfGraduation { get; set; }
        /*FunctionHeader
        * FUNCTION : collegeEmail
        *
        * DESCRIPTION :Accessor for
        *
        */
        public string collegeEmail { get; set; }
        /*FunctionHeader
        * FUNCTION : userSalt
        *
        * DESCRIPTION : Accessor for
        *
        */
        public string userSalt { get; set; }
        /*FunctionHeader
        * FUNCTION : flaggarion
        *
        * DESCRIPTION : Accessor for
        *
        */
        public static int flaggarion { get; set; }
        /*FunctionHeader
        * FUNCTION : flagz
        *
        * DESCRIPTION : Accessor for
        *
        */
        public static int flagz { get; set; }

    }
}