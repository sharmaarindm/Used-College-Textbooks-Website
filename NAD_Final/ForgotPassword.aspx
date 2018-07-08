<%@ Page Title="" Language="C#" MasterPageFile="~/TextbookTrader.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="NAD_Final.ForgotPassword" %>

<%--
/*
* FILE : ForgotPassword.aspx
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
    <h1>Forgot Password?</h1>
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
         
        </script>
<div class="container">
            <div class="text-center"><h3><asp:Label ID="failedAttempt" runat="server" Visible="false"></asp:Label></h3></div>
            <div class ="boxedLogin">
                <div>
                      <div class="text-center"><pre class="registerButton"><asp:Label ID="confirmationlabel" runat="server" text="Get Confirmation Code"></asp:Label></pre></div>
                     
                      <div class="text-center"><pre class="registerFont"><asp:Label ID="usernameLabel" runat="server" Text="Username "></asp:Label><asp:TextBox ID="UserName" runat="server" Onclick ="Username_ClientClicked()"></asp:TextBox></pre></div>
                      
                      <div class="text-center"><pre><asp:Button class="registerButton" ID="SendMail" runat="server" Text="   Send Email   " OnClick="send_Click"></asp:Button></pre></div>
                </div>
            </div>
        </div>
</asp:Content>

