<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="NAD_Final.MainPage" %>

<%--
/*
* FILE : MainPage.aspx
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin, Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This interface is to allow the user to either browse the posts, access the FAQ page, or create a post. From this page the user can
* redirect themself to the login page.
*/
--%>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>New and Used Books for Sale - Textbook Classifieds </title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <link rel="stylesheet" href="Content/myCustom.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form class="form-horizontal" id="form1" runat="server">
        <div class="jumbotron ">
            <div class="flexBox2">
                <div style="flex-grow:1">
                    <asp:ImageButton class ="LogoImage" ID="ImageButton2" src="Images/ourLogo.jpg" runat="server" OnClick="Logo_Click"/>
                </div>
                <div style="flex-grow:8" class ="mainaligncentrediv">
                    <h1>Buy & Sell Your Used Textbooks</h1>
                </div>
                <div style="flex-grow:1">
                   <asp:ImageButton class ="LogoImage" ID="ImageButton3" Visibile = "False" src="" runat="server" />
                </div>
            </div>
            <div class="Logins">
                
                <div class="row">
                    
                    <div class="col-sm-4">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/LoginPage.aspx">Login</asp:HyperLink>
                    </div>
                    <div class="col-sm-4">
                        <asp:HyperLink ID="HyperLink2" runat="server">Account</asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>
       
        <div class="afterjumbo">
            <br/>
            <br/>
            <div class="searchboxDiv">
                <h3 class="browseLabel text-center">Browse
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Browse_Click" />
                </h3>
            
            </div>

            <div class="row" id="mainbuttons">
                <div class="col-sm-3">
                    <asp:Button class="indexButtons" ID="Button2" runat="server" Text="Browse" OnClick="Browse_Click" />
                </div>
                <div class="col-sm-3">
                    <asp:Button class="indexButtons" ID="Button3" runat="server" Text="Post" OnClick="Post_Click" />
                </div>
                <div class="col-sm-3">
                    <asp:Button class="indexButtons" ID="Button4" runat="server" Text="FAQ" OnClick="FAQ_Click" />
                </div>
            </div>
       </div>
    </form>
    <div id="footer">
         <div class="container text-center">
          </br>
          </br>
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
</body>
</html>
