<%@ Page Title="" Language="C#" MasterPageFile="~/TextbookTrader.Master" AutoEventWireup="true" CodeBehind="InstituteAdminIndex.aspx.cs" Inherits="NAD_Final.InstituteAdminIndex" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
    <h1>Manage Books & Courses</h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="AdminButton" runat="server">
     <asp:Button class="btn btn-info tahoma" ID="Button14" runat="server" Text="Administrate" Visible="false" OnClick="Admin_Click"/>
</asp:Content>

<%--<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>--%>

<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
     <div class="afterjumbo">
        <div class="manageAccountsButtons">
            <div id="coursesz">
                <h1 style="margin-right:5%;"><asp:Button ID="courses_signup" runat="server" Text="Manage Courses" Enabled="false" OnClick="ManageCourses_click" /></h1>
            </div>
                
            <div id="textbookz">
                <h1 style="margin-left:5%;"><asp:Button ID="book_signup" runat="server" Text="Manage Textbooks" OnClick="ManageTextbooks_Click" /></h1>
            </div>
        </div>
       </div>
</asp:Content>
