<%@ Page Title="" Language="C#" MasterPageFile="~/TextbookTrader.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="NAD_Final.LoginPage" %>

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

<asp:Content ID="indexHeader" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="adminBrowseTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <h1>Login</h1>
</asp:Content>

<asp:Content ID="admin" ContentPlaceHolderID="AdminButton" runat="server">
    <asp:Button class="btn btn-info tahoma" ID="Button14" runat="server" Text="Administrate" Visible="false" OnClick="Admin_Click"/>
</asp:Content>

<asp:Content ID="indexBody" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
         function Username_ClientClicked()
          {
              document.getElementById("<%=UserName.ClientID%>").value = "";
              document.getElementById("<%=UserName.ClientID%>").style.color = "black";
         }
         function Password_ClientClicked() {
             document.getElementById("<%=password.ClientID%>").value = "";
             document.getElementById("<%=password.ClientID%>").style.color = "black";
        }
        </script>
<div class="container">
            <div class="text-center"><h3><asp:Label ID="failedLogin" runat="server" Visible="false"></asp:Label></h3></div>
            <div class ="boxedLogin">
                <div>
                      <pre class="registerButton">Sign In                      <asp:Button ID="Register" runat="server" Text="Register" OnClick="Register_Click" /></pre>
                     
                      <pre class="registerFont">  Username <asp:TextBox ID="UserName" runat="server" Onclick ="Username_ClientClicked()"></asp:TextBox></pre>
                      <pre class="registerFont">  Password <asp:TextBox ID="password" runat="server" TextMode="Password" Onclick ="Password_ClientClicked()"></asp:TextBox><asp:Button ID="forgot" runat="server" Text="Forgot?" Onclick="Forgot_click"></asp:Button></pre>
                      <pre><div class="text-center"><asp:Button class="registerButton" ID="login" runat="server" Text="   Login   " OnClick="Login_Click"></asp:Button></div></pre>
                </div>
            </div>
        </div>
</asp:Content>

