<%@ Page Title="" Language="C#" MasterPageFile="~/TextbookTrader.Master" AutoEventWireup="true" CodeBehind="ManageCourses.aspx.cs" Inherits="NAD_Final.ManageCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
      <h1>Manage Courses</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="AdminButton" runat="server">
    <asp:Button class="btn btn-info tahoma" ID="Button14" runat="server" Text="Administrate" Visible="false" OnClick="Admin_Click"/>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
<%--     <script type="text/javascript">
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
        </script>--%>
        <div class="container">
            <div class ="flexBox">
                <div>
                    <div class ="boxedRegister">
                        <div class ="flexBox">  
                        <div>                     
                            <pre class="registerFont">  Course Semester      <asp:TextBox ID="CourseSemester" runat="server" OnClick="CourseSemester_ClientClicked()"></asp:TextBox></pre>
                            <pre class="registerFont">  Course Name          <asp:TextBox ID="CourseName" runat="server" OnClick="CourseName_ClientClicked()"></asp:TextBox></pre>
                            <pre class="registerFont">  Course Description   <asp:TextBox ID="CourseDescription" runat="server" OnClick="CourseDescription_ClientClicked()"></asp:TextBox></pre> 
                        </div>
                    </div>
                    <asp:Button class="addpostButton" ID="AddCourse" runat="server" Text="Add Course" OnClick="Add_Course_Clicked"/>
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
                        </Table>
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr class="border">
                            <td class="align-data text-nowrap"><h3>Course Name: <%#Eval("_course_name") %></h3></td>
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
