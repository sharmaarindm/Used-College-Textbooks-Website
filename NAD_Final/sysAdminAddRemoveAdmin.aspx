
<%@ Page Title="" Language="C#" MasterPageFile="~/TextbookTrader.Master" AutoEventWireup="true" CodeBehind="sysAdminAddRemoveAdmin.aspx.cs" Inherits="NAD_Final.sysAdminAddRemoveAdmin" %>

<%--
/*
* FILE : sysAdminAddRemoveAdmin.aspx
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin,Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This file is interface for the system admin user in order to be able to add or remove an admin for an institution.
*/
--%>

<asp:Content ID="indexHeader" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="adminAddRemoveUsersTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <h1>Manage Institution Admins</h1>
</asp:Content>

<asp:Content ID="admin" ContentPlaceHolderID="AdminButton" runat="server">
    <asp:Button class="btn btn-info tahoma" ID="Button14" runat="server" Text="Administrate" Visible="false" OnClick="Admin_Click"/>
</asp:Content>

<asp:Content ID="indexBody" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        
            <div class ="flexBox">
                <div class="text-center" >
                    <asp:Label  ID="alerts" runat="server" Text=""></asp:Label>
                    <div class ="boxedRegister">
                        <div>                    
                            <pre>          <h1>Add New Institution Admin</h1></pre>                       
                        </div>
                        <div>
                            <pre class="registerFont">  Admin Username            <asp:TextBox class="addremoveuserbox" ID="Username" runat="server" ></asp:TextBox></pre>
                            <pre class="registerFont">  Institution name          <asp:DropDownList class="comboheight" ID="InstitutionName2" runat="server" AutoPostBack="True"></asp:DropDownList></pre>
                            <pre class="registerFont">  Admin First Name          <asp:TextBox class="addremoveuserbox" ID="AdminFname" runat="server"></asp:TextBox></pre>
                            <pre class="registerFont">  Admin Last Name           <asp:TextBox class="addremoveuserbox" ID="AdminLName" runat="server"></asp:TextBox></pre>
                            <pre class="registerFont">  Password                  <asp:TextBox class="addremoveuserbox" ID="Password" runat="server" TextMode="Password"></asp:TextBox></pre>
                        </div>
                    </div>
                    <asp:Button class="addpostButton" ID="AddAdmin" runat="server" Text="Add Admin" OnClick="AddAdmin_Click1" />
                </div>


                <div class="flex-column">
                    <%--<div class="text-center"><asp:Label  ID="alerts2" runat="server" Text=""></asp:Label></div>--%>
                    <asp:ListView ID="sysAdminListView" runat="server" OnSelectedIndexChanged="sysAdminListView_SelectedIndexChanged" AutoPostBack="True" ShowItemToolTips ="True">
                        <LayoutTemplate>
                            <div class="result-scroll-bar">
                            <Table class="border">
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>              
                            </Table>
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr class="border">
                                <td class="align-data text-nowrap"><h3>Username: <%#Eval("_email_address") %></h3></td>
                                <td class="align-data-buttons">
                                     <asp:Button class="ListViewButton" ID="editInstitutebutton" runat="server" Text="Edit" OnClick="EditAdmin_Click"/>
                                     <asp:Button class="ListViewButton" ID="deleteInstituteButton" runat="server" Text="Delete" OnClick="DeleteAdmin_Click"/>
                                </td>     
                            </tr>
                        </ItemTemplate>
                        </asp:ListView>
                    </div>
            </div>
        </div>
</asp:Content>