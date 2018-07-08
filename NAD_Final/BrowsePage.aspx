<%--
/*
* FILE : BrowsePage.aspx
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin, Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This file is interface for the users that wish to browse posts posted by other users that wish to sell books. 
*/
--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/TextbookTrader.Master" AutoEventWireup="true" CodeBehind="BrowsePage.aspx.cs" Inherits="NAD_Final.BrowsePage" %>

<asp:Content ID="indexHeader" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="adminBrowseTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <h1>Browse for Textbooks</h1>
</asp:Content>

<asp:Content ID="admin" ContentPlaceHolderID="AdminButton" runat="server">
    <asp:Button class="btn btn-info tahoma" ID="Button14" runat="server" Text="Administrate" Visible="false" OnClick="Admin_Click"/>
</asp:Content>


<asp:Content ID="indexBody" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
          function newTitle_ClientClicked()
          {
              document.getElementById("<%=TextBox1.ClientID%>").value = "";
              document.getElementById("<%=TextBox1.ClientID%>").style.color = "black";
        }
    </script>
    <div class="flexBoxCol2">
        <table>
            <tr>
                <td><h3 class="browseLabelzz">Select a College </h3></td><td><h3><asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList></h3></td>
            </tr>
            <tr>
                <td><h3 class="browseLabelz">Browse </h3></td><td><h3><asp:TextBox class="browseTextbox" ID="TextBox1" runat="server" OnClick="newTitle_ClientClicked()"></asp:TextBox></h3></td><td><h3><asp:Button class="searchButtonBrowse" ID="Button1" runat="server" Text="Search" OnClick="Browse_Click"  AutoPostBack="True"/></h3></td>
            </tr>

        </table>
         <div><h3><asp:Label ID="postResultsLabel" runat="server" Text="No Results Found" Visible="false"></asp:Label></h3></div>
       <%-- <div class="flexBox">
            <div id="SelectCollegeLabel"><h3>Select a College <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList></h3></div>
        </div>     
        <div class="flexBox">
            <div id="BrowseLabel"><h3>Browse <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><asp:Button class="searchButtonBrowse" ID="Button7" runat="server" Text="Search" OnClick="Browse_Click"  AutoPostBack="True"/></h3></div>
        </div>
        </br>--%>
        </br>
        <%-- ListView goes here!--%>
        <div class="result-table-browse">
        <div class="flex-container">
                <asp:ListView ID="browseResultsListView" runat="server" AutoPostBack="True">
                    <LayoutTemplate>
                        <div class="result-scroll-bar">
                        <Table class="border">
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                        </Table>
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr class="border">
                            <td id="image-data"><img id="bookImage" src="https://i.amz.mshcdn.com/oz75gS6Ke1aRMwWuu4M_jP6LSLE=/356x205/https%3A%2F%2Fblueprint-api-production.s3.amazonaws.com%2Fuploads%2Fstory%2Fthumbnail%2F62429%2F0cb95ccb-ac64-41e7-a30f-b7d1d01b094d.png"></td>
                            <td class="align-data text-nowrap"><h3>Title: <%#Eval("_book_title") %></h3></td>
                            <td class="align-data text-nowrap"><h3>Author: <%#Eval("_book_author") %></h3></td>
                            <td class="align-data-expire text-nowrap"><h4>Expires: <%#Eval("_post_expire") %></h4></td>
                            <td class="align-data"><asp:Button class="ListViewButton" ID="Button13" runat="server" Text="View" OnClick="ViewPost_Click" AutoPostBack="False"/></td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
        </div>
        </div>
    </div>
       <%-- <div class="flex-container3">
            <div id="resultsListbox">
                <div class="flex-container2">
                    <div><img id="bookImage" src="https://i.amz.mshcdn.com/oz75gS6Ke1aRMwWuu4M_jP6LSLE=/356x205/https%3A%2F%2Fblueprint-api-production.s3.amazonaws.com%2Fuploads%2Fstory%2Fthumbnail%2F62429%2F0cb95ccb-ac64-41e7-a30f-b7d1d01b094d.png"></div>
                    <div><h3>Title</h3></div>
                    <div><h3>Author</h3></div>
                    <div><h3>Expires: 5/26/2017</h3></div>
                    <div><asp:Button ID="Button8" runat="server" Text="View" OnClick="ViewPost_Click" /></div>
                </div>
                <div class="flex-container2">
                    <div><img id="bookImage" src="https://i.amz.mshcdn.com/oz75gS6Ke1aRMwWuu4M_jP6LSLE=/356x205/https%3A%2F%2Fblueprint-api-production.s3.amazonaws.com%2Fuploads%2Fstory%2Fthumbnail%2F62429%2F0cb95ccb-ac64-41e7-a30f-b7d1d01b094d.png"></div>
                    <div id="bookTitle" runat="server">Title</div>
                    <div id="author" runat="server">Author</div>
                    <div id="expiry" runat="server">Expires: 5/26/2017</div>
                    <div><asp:Button ID="Button9" runat="server" Text="View" OnClick="ViewPost_Click" /></div>
                </div>              
            </div>
        </div>--%>
</asp:Content>