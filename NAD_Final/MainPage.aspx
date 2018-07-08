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
<%@ Page Title="" Language="C#" MasterPageFile="~/TextbookTrader.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="NAD_Final.MainPage" %>



<asp:Content ID="indexHeader" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="adminBrowseTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <h1>Buy & Sell Used Textbooks</h1>
</asp:Content>

<asp:Content ID="admin" ContentPlaceHolderID="AdminButton" runat="server">
    <asp:Button class="btn btn-info tahoma" ID="Button14" runat="server" Text="Administrate" Visible="false" OnClick="Admin_Click"/>
</asp:Content>


<asp:Content ID="indexBody" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
          function newTitle_ClientClicked()
          {
              document.getElementById("<%=TextBox2.ClientID%>").value = "";
              document.getElementById("<%=TextBox2.ClientID%>").style.color = "black";
            }
    </script>
    <div class="afterjumbo">
            <br/>
            <br/>
            <div class="searchboxDiv">
                <h3 class="browseLabel text-center">Browse
                    <asp:TextBox ID="TextBox2" runat="server" OnClick="newTitle_ClientClicked()"></asp:TextBox>
                    <asp:Button ID="Button5" runat="server" Text="Search" OnClick="Search_Click" />
                </h3>
            </div>

            <div class="row" id="mainbuttons">
                <div class="col-sm-3">
                    <asp:Button class="indexButtons" ID="Button6" runat="server" Text="Browse" OnClick="Browse_Click" />
                </div>
                <div class="col-sm-3">
                    <asp:Button class="indexButtons" ID="Button7" runat="server" Text="Post" OnClick="Post_Click" />
                </div>
                <div class="col-sm-3">
                    <asp:Button class="indexButtons" ID="Button8" runat="server" Text="FAQ" OnClick="FAQ_Click" />
                </div>
            </div>
       </div>
</asp:Content>