<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BrowsePage.aspx.cs" Inherits="NAD_Final.BrowsePage" %>


<%--
/*
* FILE : BrowsePage.aspx
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin, Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This file is interface for the users that wish to browse posts posted by other users that wish to sell books. 
*/
--%>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>New and Used books for sale</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <link rel="stylesheet" href="Content/myCustom.css">
    <link rel="stylesheet" href="Content/BrowseStyleSheet.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form class="form-horizontal" id="form1" runat="server">
        <div class="jumbotron ">
            <div class="flexBox2">
                <div style="flex-grow:1">
                    <asp:ImageButton class ="LogoImage" ID="ImageButton1" src="Images/ourLogo.jpg" runat="server" OnClick="Logo_Click"/>
                </div>
                <div style="flex-grow:8" class ="mainaligncentrediv">
                    <h1>Browse for textbooks</h1>
                </div>
                <div style="flex-grow:1">
                   <asp:ImageButton class ="LogoImage" ID="ImageButton2" Visibile = "False" src="" runat="server" />
                </div>
            </div>
            <div class="Logins">
                
                <div class="row">
                    
                    <div class="col-sm-4">
                        <asp:HyperLink ID="LoginHyperLink" runat="server" NavigateUrl="~/LoginPage.aspx">Login</asp:HyperLink>
                    </div>
                    <div class="col-sm-4">
                        <asp:HyperLink ID="AccountHyperLink" runat="server">Account</asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>
       <%-- <div>
            <h1 id="LoginSubtitle">Browse For Textbooks</h1>
        </div> --%>
        <div class="flex-container">
            <div id="SelectCollegeLabel"><h3>Select a College <asp:DropDownList ID="CollegeDropdown" runat="server"></asp:DropDownList></h3></div>
        </div>     
        <div class="flex-container">
            <div id="BrowseLabel"><h3>Browse <asp:TextBox ID="BrowsePageTextbox" runat="server"></asp:TextBox><asp:Button ID="BrowseSearchButton" runat="server" Text="Search" /></h3><div>
        </div>
        <div class="flex-container3">
            <div id="resultsListbox">
                <div class="flex-container2">
                    <div><img id="bookImage" src="https://i.amz.mshcdn.com/oz75gS6Ke1aRMwWuu4M_jP6LSLE=/356x205/https%3A%2F%2Fblueprint-api-production.s3.amazonaws.com%2Fuploads%2Fstory%2Fthumbnail%2F62429%2F0cb95ccb-ac64-41e7-a30f-b7d1d01b094d.png"></div>
                    <div><h3>Title</h3></div>
                    <div><h3>Author</h3></div>
                    <div><h3>Expires: 5/26/2017</h3></div>
                    <div><asp:Button ID="resultsViewOne" runat="server" Text="View" OnClick="ViewPost_Click" /></div>
                </div>
                <div class="flex-container2">
                    <div><img id="bookImage" src="https://i.amz.mshcdn.com/oz75gS6Ke1aRMwWuu4M_jP6LSLE=/356x205/https%3A%2F%2Fblueprint-api-production.s3.amazonaws.com%2Fuploads%2Fstory%2Fthumbnail%2F62429%2F0cb95ccb-ac64-41e7-a30f-b7d1d01b094d.png"></div>
                    <div><h3>Title</h3></div>
                    <div><h3>Author</h3></div>
                    <div><h3>Expires: 5/26/2017</h3></div>
                    <div><asp:Button ID="resultsViewTwo" runat="server" Text="View" OnClick="ViewPost_Click" /></div>
                </div>
                <div class="flex-container2">
                    <div><img id="bookImage" src="https://i.amz.mshcdn.com/oz75gS6Ke1aRMwWuu4M_jP6LSLE=/356x205/https%3A%2F%2Fblueprint-api-production.s3.amazonaws.com%2Fuploads%2Fstory%2Fthumbnail%2F62429%2F0cb95ccb-ac64-41e7-a30f-b7d1d01b094d.png"></div>
                    <div><h3>Title</h3></div>
                    <div><h3>Author</h3></div>
                    <div><h3>Expires: 5/26/2017</h3></div>
                    <div><asp:Button ID="resultsViewThree" runat="server" Text="View" OnClick="ViewPost_Click" /></div>
                </div>
                <div class="flex-container2">
                    <div><img id="bookImage" src="https://i.amz.mshcdn.com/oz75gS6Ke1aRMwWuu4M_jP6LSLE=/356x205/https%3A%2F%2Fblueprint-api-production.s3.amazonaws.com%2Fuploads%2Fstory%2Fthumbnail%2F62429%2F0cb95ccb-ac64-41e7-a30f-b7d1d01b094d.png"></div>
                    <div><h3>Title</h3></div>
                    <div><h3>Author</h3></div>
                    <div><h3>Expires: 5/26/2017</h3></div>
                    <div><asp:Button ID="resultsViewFour" runat="server" Text="View" OnClick="ViewPost_Click" /></div>
                </div>
                <div class="flex-container2">
                    <div><img id="bookImage" src="https://i.amz.mshcdn.com/oz75gS6Ke1aRMwWuu4M_jP6LSLE=/356x205/https%3A%2F%2Fblueprint-api-production.s3.amazonaws.com%2Fuploads%2Fstory%2Fthumbnail%2F62429%2F0cb95ccb-ac64-41e7-a30f-b7d1d01b094d.png"></div>
                    <div><h3>Title</h3></div>
                    <div><h3>Author</h3></div>
                    <div><h3>Expires: 5/26/2017</h3></div>
                    <div><asp:Button ID="resultsViewFive" runat="server" Text="View" OnClick="ViewPost_Click" /></div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
