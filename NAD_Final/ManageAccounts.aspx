
<%@ Page Title="" Language="C#" MasterPageFile="~/TextbookTrader.Master" AutoEventWireup="true" CodeBehind="ManageAccounts.aspx.cs" Inherits="NAD_Final.ManageAccounts" %>

<%--
/*
* FILE : ManageAccounts.aspx
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin, Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This interface is to allow the system admin to add an institute to the system, or to add an institute admin to the system.
*/
--%>

<asp:Content ID="indexHeader" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="adminBrowseTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <h1>Manage Admins & Institutions</h1>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminButton" runat="server">
    <asp:Button class="btn btn-info tahoma" ID="Button14" runat="server" Text="Administrate" Visible="false" OnClick="Admin_Click"/>
</asp:Content>

<asp:Content ID="indexBody" ContentPlaceHolderID="MainContent" runat="server">
      <div class="afterjumbo">
        <div class="manageAccountsButtons">
            <div id="institutez">
                <asp:Button ID="institute" runat="server" Text="Manage Institutions" OnClick="ARInstitution_click" />
            </div>
            <div id="adminz">
                <asp:Button ID="admin" runat="server" Text="Manage Institution Admins" OnClick="ARSysAdmin_Click" />
            </div>
        </div>
       </div>
</asp:Content>