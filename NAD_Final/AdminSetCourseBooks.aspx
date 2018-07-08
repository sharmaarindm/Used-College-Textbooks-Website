<%--
/*
* FILE : AdminSetCourseBooks.aspx
* PROJECT : NAD
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin, Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION : This interface is to allow the admin to organize books by course.
*/
--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/TextbookTrader.Master" AutoEventWireup="true" CodeBehind="AdminSetCourseBooks.aspx.cs" Inherits="NAD_Final.AdminSetCourseBooks" %>

<asp:Content ID="indexHeader" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>

<asp:Content ID="adminBrowseTitle" ContentPlaceHolderID="TitleContent" runat="server">   
    <h1>Course Book Approval</h1> 
</asp:Content>

<asp:Content ID="admin" ContentPlaceHolderID="AdminButton" runat="server">
    <asp:Button class="btn btn-info tahoma" ID="Button14" runat="server" Text="Administrate" Visible="false" OnClick="Admin_Click"/>
</asp:Content>

<asp:Content ID="indexBody" ContentPlaceHolderID="MainContent" runat="server">
    <div class ="organize_page">

            <div class="text-center"><!--drop down header -->
                <div class="flex-container">
                    <div id="SelectCollegeLabel"><h3>Select a College <asp:DropDownList ID="CollegeListDropDown" runat="server" OnSelectedIndexChanged="CollegeListDropDown_SelectedIndexChanged" AutoPostBack="true" ViewStateMode="Enabled"></asp:DropDownList></h3></div>
                </div>     
                <div class="flex-container">
                    <div id="SelectCourseLabel"><h3>Select a Course <asp:DropDownList ID="CourseDropDownList" runat="server" OnSelectedIndexChanged="CourseDropDownList_SelectedIndexChanged" ViewStateMode="Enabled"  AutoPostBack="true"></asp:DropDownList> <!-- <asp:Button ID="testbtn" runat="server" Text="refresh booklist" OnClick="testbtn_Click" /> --></h3></div>
                </div>
                </br>
                </br>
            </div> <!--end of drop down header -->

    <div class="organize_tableViews"><!-- start of list view content -->
        <%-- ListView goes here!--%>
    <!--<div class="result-table-browse">-->
        <!--<div class="flex-container">-->


            <%-- ALL BOOKS LIST --%>
            <div class ="color">
                <asp:ListView ID="AllBookListView" runat="server">
                    <LayoutTemplate>
                        <div class="result-scroll-bar2">
                        <Table class="border">
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                        </Table>
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr class="border">
                            <td id="image-data"><img id="bookImage" src="https://i.amz.mshcdn.com/oz75gS6Ke1aRMwWuu4M_jP6LSLE=/356x205/https%3A%2F%2Fblueprint-api-production.s3.amazonaws.com%2Fuploads%2Fstory%2Fthumbnail%2F62429%2F0cb95ccb-ac64-41e7-a30f-b7d1d01b094d.png"></td>
                            <td class="align-data text-nowrap"><h3>Book ID: <%#Eval("_book_id") %></h3></td>
                            <td class="align-data text-nowrap"><h3>Book Title: <%#Eval("_book_title") %></h3></td>
                            <td class="align-data text-nowrap"><h3>Book Author: <%#Eval("_book_author") %></h3></td>
                            <td class="align-data-expire text-nowrap"><h4>ISBN: <%#Eval("_book_isbn") %></h4></td>
                            <td class="align-data"><asp:Button class="ListViewButton" ID="AddBtn" runat="server" Text="Add" OnClick="AddBtn_Click"/></td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
             </div>

                                    <%-- BOOKS ADDED TO COURSE LIST --%>
             <div class ="color2">
                <asp:ListView ID="CourseBookListView" runat="server">
                    <LayoutTemplate>
                        <div class="result-scroll-bar2">
                        <Table class="border">               
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                        </Table>
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr class="border">
                            <td id="image-data"><img id="bookImage" src="https://i.amz.mshcdn.com/oz75gS6Ke1aRMwWuu4M_jP6LSLE=/356x205/https%3A%2F%2Fblueprint-api-production.s3.amazonaws.com%2Fuploads%2Fstory%2Fthumbnail%2F62429%2F0cb95ccb-ac64-41e7-a30f-b7d1d01b094d.png"></td>
                            <td class="align-data text-nowrap"><h3>Course ID: <%#Eval("_course_id") %></h3></td>
                            <td class="align-data text-nowrap"><h3>Book Title: <%#Eval("_book_title") %></h3></td>
                            <td class="align-data-expire text-nowrap"><h4>Book ID: <%#Eval("_book_id") %></h4></td>
                            <td class="align-data"><asp:Button class="ListViewButton" ID="RemoveBtn" runat="server" Text="Remove" OnClick="RemoveBtn_Click"/></td>                            
                        </tr>
                    </ItemTemplate>                  
                </asp:ListView>
              </div>





            <!--</div> -->
        <!--</div>-->
        </div><!-- end of listview content -->
        </div><!-- encapsulated div -->
    </asp:Content>