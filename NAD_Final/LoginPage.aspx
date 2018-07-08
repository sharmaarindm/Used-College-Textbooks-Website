<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="NAD_Final.LoginPage" %>

<%--
/*
* FILE : LoginPage.aspx
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin, Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This interface is to provide the user with the login page so they have the ability to login and access their account.
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
                    <h1>Login To Your Account</h1>
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
      
            <div class ="boxedLogin">
                <div>
                      <pre class="registerButton">Sign In                      <asp:Button ID="Register" runat="server" Text="Register" OnClick="Register_Click" /></pre>
                     
                      <pre class="registerFont">  Username <asp:TextBox ID="UserName" runat="server">Admin</asp:TextBox></pre>
                      <pre class="registerFont">  Password <asp:TextBox ID="password" runat="server">********</asp:TextBox><asp:Button ID="forgot" runat="server" Text="Forgot?"></asp:Button></pre>
                      <pre><asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>        Remember Me                                 <asp:Button class="registerButton" ID="login" runat="server" Text="   Login   " OnClick="Login_Click"></asp:Button></pre>
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
