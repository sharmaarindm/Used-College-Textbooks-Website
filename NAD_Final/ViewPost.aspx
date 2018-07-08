<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPost.aspx.cs" Inherits="NAD_Final.ViewPost" %>

<%--
/*
* FILE : ViewPost.aspx
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin,Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This file is interface for the user to be able to see the post created by other users.
*/
--%>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <link rel="stylesheet" href="Content/myCustom.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
      


        <div class="jumbotron ">
            <div class="flexBox2">
                <div style="flex-grow:1">
                    <asp:ImageButton class ="LogoImage" ID="ImageButton1" src="Images/ourLogo.jpg" runat="server" OnClick="Logo_Click"/>
                </div>
                <div style="flex-grow:8" class ="mainaligncentrediv">
                    <h1><asp:Label ID="PostName" runat="server" Text="Bromans Post 1"></asp:Label></h1>
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
      
         <div class="container">
      
            <div class="boxedViewPost">
            <div class ="flexBox">
                <div>
                    <pre><asp:Image CssClass="imageViewPost" ID="PostImage" runat="server" Height="233px" Width="181px" /></pre>
                </div>
                <div class="leftmarginView">
                    <pre class="registerFont">  Post Owner   <asp:TextBox ID="postOwner" runat="server"></asp:TextBox></pre>
                    <pre class="registerFont">  Price        <asp:TextBox ID="price" runat="server"></asp:TextBox></pre>
                    <pre class="registerFont">  Title        <asp:TextBox ID="Title" runat="server"></asp:TextBox></pre>
                    <pre class="registerFont">  Author       <asp:TextBox ID="Author" runat="server"></asp:TextBox></pre>

                </div>
                
            </div>
                <div>
                    <pre class="registerFont">  ISBN                  <asp:TextBox ID="ISBN" runat="server"></asp:TextBox> Course Description</pre>
                    <div class ="flexBox">
                        <div>
                        <pre class="registerFont">  Edition               <asp:TextBox ID="Edition" runat="server"></asp:TextBox></pre>
                        <pre class="registerFont">  Publisher             <asp:TextBox ID="Publisher" runat="server"></asp:TextBox></pre>
                        <pre class="registerFont">  Year Of Publication   <asp:TextBox ID="YearOfPublication" runat="server"></asp:TextBox></pre>
                        </div>
                        <div>
                            <asp:TextBox class="courseDescriptionText" ID="CourseDescription" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div id="footer">
            <div class="container text-center">
                <br/>
                <br/>
                <div class="row">
                    <div class="col-sm-4">
                        <asp:HyperLink ID="ContactUsLink" runat="server">Contact Us</asp:HyperLink>
                    </div>
                    <div class="col-sm-4">
                        <asp:HyperLink ID="TermsOfUseLink" runat="server">Terms Of Use</asp:HyperLink>
                    </div>
                    <div class="col-sm-4">
                        <asp:HyperLink ID="PrivacyLink" runat="server">Privacy Policy</asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

