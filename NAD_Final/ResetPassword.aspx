<%@ Page Title="" Language="C#" MasterPageFile="~/TextbookTrader.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="NAD_Final.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
     <h1>Reset Password</h1>
</asp:Content>

<asp:Content ID="admin" ContentPlaceHolderID="AdminButton" runat="server">
    <asp:Button class="btn btn-info tahoma" ID="Button14" runat="server" Text="Administrate" Visible="false" OnClick="Admin_Click"/>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
            <div class="container">
                <div class="text-center"><h3><asp:Label ID="failedAttempt" runat="server" Visible="false"></asp:Label></h3></div>
                <div class="boxedLogin">

                    <div class="text-center">
                        <pre class="registerFont">Enter Your New Password</pre>
                    </div>

                    <div class="text-center">
                        <pre class="registerFont">          New Password <asp:TextBox ID="UserName" runat="server" ></asp:TextBox></pre>
                    </div>
                    <div class="text-center">
                        <pre class="registerFont">  Confirm New Password <asp:TextBox ID="password" runat="server" TextMode="Password" ></asp:TextBox></pre>
                    </div>
                    <div class="text-center">
                        <pre><asp:Button class="registerButton" ID="login" runat="server" Text="   Reset Password   " OnClick="ResetPass_Click"></asp:Button></pre>
                    </div>
                </div>
           </div>
</asp:Content>
