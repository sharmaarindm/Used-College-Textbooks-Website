<%--
/*
* FILE : StuPost.aspx
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin, Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This file is interface for the users that wish to create a post in order to sell books.
--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/TextbookTrader.Master" AutoEventWireup="true" CodeBehind="PostTextbooks.aspx.cs" Inherits="NAD_Final.PostTextbooks" %>

<asp:Content ID="indexHeader" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="adminBrowseTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <h1>Make a Post</h1>
</asp:Content>

<asp:Content ID="admin" ContentPlaceHolderID="AdminButton" runat="server">
    <asp:Button class="btn btn-info tahoma" ID="Button14" runat="server" Text="Administrate" Visible="false" OnClick="Admin_Click"/>
</asp:Content>

<asp:Content ID="indexBody" ContentPlaceHolderID="MainContent" runat="server">
      <script type="text/javascript">
          function newTitle_ClientClicked()
          {
              document.getElementById("<%=newTitle.ClientID%>").value = "";
              document.getElementById("<%=newTitle.ClientID%>").style.color = "black";
          }
          function Author_ClientClicked() {
              document.getElementById("<%=Author.ClientID%>").value = "";
              document.getElementById("<%=Author.ClientID%>").style.color = "black";
          }
          function ISBN_ClientClicked() {
              document.getElementById("<%=ISBN.ClientID%>").value = "";
              document.getElementById("<%=ISBN.ClientID%>").style.color = "black";
          }
          function Edition_ClientClicked() {
              document.getElementById("<%=Edition.ClientID%>").value = "";
              document.getElementById("<%=Edition.ClientID%>").style.color = "black";
          }
          function Publisher_ClientClicked() {
              document.getElementById("<%=Publisher.ClientID%>").value = "";
              document.getElementById("<%=Publisher.ClientID%>").style.color = "black";
          }
          function Price_ClientClicked() {
              document.getElementById("<%=Price.ClientID%>").value = "";
              document.getElementById("<%=Price.ClientID%>").style.color = "black";
          }
        </script>
    <div class="container">
            <div class ="flexBox">
                <div>
                    <div class ="boxedRegister">
                        <div class ="flexBox">
                            <div>
                                <asp:Image ID="Image1" runat="server" Height="124px" Width="126px" />
                            </div>
                            <div>
                                <pre class="registerFont">  Title     <asp:TextBox ID="newTitle" runat="server" OnClick="newTitle_ClientClicked()"></asp:TextBox></pre>
                                <pre class="registerFont">  Author    <asp:TextBox ID="Author" runat="server" OnClick="Author_ClientClicked()"> </asp:TextBox></pre>
                            </div>
                            
                        </div>
                        <div>
                            <pre class="registerFont">  ISBN                 <asp:TextBox ID="ISBN" runat="server" OnClick="ISBN_ClientClicked()"></asp:TextBox></pre>
                            <pre class="registerFont">  Edition              <asp:TextBox ID="Edition" runat="server" OnClick="Edition_ClientClicked()"></asp:TextBox></pre>
                            <pre class="registerFont">  Publisher            <asp:TextBox ID="Publisher" runat="server" OnClick="Publisher_ClientClicked()"></asp:TextBox></pre>
                            <pre class="registerFont">  Price                <asp:TextBox ID="Price" runat="server" OnClick="Price_ClientClicked()"></asp:TextBox></pre> 
                        </div>
                    </div>
                    <asp:Button class="addpostButton" ID="AddPost" runat="server" Text="Add Post" OnClick="Add_Post_Clicked"/>
                </div>
                <div>

                <!-- here is where we need a listView --> 
                <div class="result-table-post">
                <div class="flex-container">
                <asp:ListView ID="postListView" runat="server" OnSelectedIndexChanged="postListView_SelectedIndexChanged" AutoPostBack="True">
                    <LayoutTemplate>
                        <div class="scroll-bar">
                        <Table class="table-border">
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>              
<%--                            <tr class="nav-row">
                                <td class="nav-buttons">
                                    <asp:Button class="btn btn-primary" ID="back" runat="server" Text="<"></asp:Button>
                                    <asp:Label class="label label-info registerFont" ID="currentPage" runat="server" Text="1"></asp:Label>
                                    <asp:Button class="btn btn-primary" ID="next" runat="server" Text=">"></asp:Button>
                                </td>
                            </tr>--%>
                        </Table>
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr class="border">
                            <td id="image-data"><img id="bookImage" src="https://i.amz.mshcdn.com/oz75gS6Ke1aRMwWuu4M_jP6LSLE=/356x205/https%3A%2F%2Fblueprint-api-production.s3.amazonaws.com%2Fuploads%2Fstory%2Fthumbnail%2F62429%2F0cb95ccb-ac64-41e7-a30f-b7d1d01b094d.png"></td>
                            <td class="align-data text-nowrap"><h3>Title: <%#Eval("_book_title") %></h3></td>
                            <td class="align-data-expire text-nowrap"><h4>Expires: <%#Eval("_post_expire") %></h4></td>
                            <td class="align-data-buttons">
                                 <asp:Button class="ListViewButton" ID="editPostbutton" runat="server" Text="Edit" OnClick="EditPost_Click"/>
                                 <asp:Button class="ListViewButton" ID="deletePostButton" runat="server" Text="Delete" OnClick="DeletePost_Click"/>
                                <%--<asp:Button class="ListViewButton" ID="editPostbutton" runat="server" Text="Edit" OnClick="EditPost_Click"/><asp:Button class="ListViewButton" ID="deletePostButton" runat="server" Text="Delete" OnClick="DeletePost_Click"/>--%>
                            </td>
                       
                        </tr>
                    </ItemTemplate>
                    </asp:ListView>
                 </div>
                 </div>

                </div>
            </div>
        </div>
</asp:Content>

