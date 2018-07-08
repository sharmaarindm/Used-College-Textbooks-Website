using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAD_Final.Model
{
    public class PostForm
    {

        /*FunctionHeader
        * FUNCTION : Title
        *
        * DESCRIPTION : Accessor for Title
        *
        */
        public string Title { get; set; }
        /*FunctionHeader
        * FUNCTION : Author
        *
        * DESCRIPTION : Accessor for Author
        *
        */
        public string Author { get; set; }
        /*FunctionHeader
        * FUNCTION : ISBN
        *
        * DESCRIPTION : Accessor for ISBN
        *
        */
        public string ISBN { get; set; }
        /*FunctionHeader
        * FUNCTION : Edition
        *
        * DESCRIPTION : Accessor for Edition
        *
        */
        public string Edition { get; set; }
        /*FunctionHeader
        * FUNCTION : Publisher
        *
        * DESCRIPTION : Accessor for publisher
        *
        */
        public string Publisher { get; set; }
        /*FunctionHeader
        * FUNCTION : Price
        *
        * DESCRIPTION : Accessor for Price
        *
        */
        public string Price { get; set; }
        /*FunctionHeader
        * FUNCTION : CourseDescriptions
        *
        * DESCRIPTION : Accessor for course description
        *
        */
        public string CourseDescriptions { get; set; }
    }
}