
<%@ Page Title="" Language="C#" MasterPageFile="~/TextbookTrader.Master" AutoEventWireup="true" CodeBehind="ViewPost.aspx.cs" Inherits="NAD_Final.ViewPost" %>

<%--
/*
* FILE : ViewPost.aspx
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin,Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This file is interface for the user to be able to see the post created by other users.
*/
--%>

<asp:Content ID="indexHeader" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="adminBrowseTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <h1><asp:Label ID ="ViewPostTitle" runat="server"></asp:Label></h1>
</asp:Content>

<asp:Content ID="admin" ContentPlaceHolderID="AdminButton" runat="server">
    <asp:Button class="btn btn-info tahoma" ID="Button14" runat="server" Text="Administrate" Visible="false" OnClick="Admin_Click"/>
</asp:Content>

<asp:Content ID="indexBody" ContentPlaceHolderID="MainContent" runat="server">
    <div class="flex-container5">
      
            <div class="boxedViewPost">
                <div><h3 class="text-center"><b>Student Post</b></h3></div>
                <div class ="flexBox">
                    <div>
                        <pre><asp:Image CssClass="imageViewPost" ID="PostImage" runat="server" Height="233px" Width="181px" src="Images/ourLogo.jpg"/></pre>
                    </div>
                    <div style="flex-grow: 2">
                        <pre class="registerFont"> Course Descriptions</pre>
                        <asp:TextBox class="courseDescriptionText" ID="TextBox5" runat="server" Height="191px" Width="323px" TextMode="MultiLine" readonly="true"></asp:TextBox>
                    </div>
                </div>        
                <div>
                    <div class ="flexBox">
                        <div>
                        <pre class="registerFont">  Post Owner            <asp:TextBox ID="postOwner" runat="server" readonly="true"></asp:TextBox></pre>
                        <pre class="registerFont">  Price                 <asp:TextBox ID="price" runat="server" readonly="true"></asp:TextBox></pre>
                        <pre class="registerFont">  Title                 <asp:TextBox ID="newTitle" runat="server" readonly="true"></asp:TextBox></pre>
                        <pre class="registerFont">  Author                <asp:TextBox ID="Author" runat="server" readonly="true"></asp:TextBox></pre>
                        <pre class="registerFont">  ISBN                  <asp:TextBox ID="ISBN" runat="server" readonly="true"></asp:TextBox> </pre>
                        <pre class="registerFont">  Edition               <asp:TextBox ID="Edition" runat="server" readonly="true"></asp:TextBox></pre>
                        <pre class="registerFont">  Publisher             <asp:TextBox ID="Publisher" runat="server" readonly="true"></asp:TextBox></pre>
                        </div>
                    </div>
                </div>
            </div>
            <div class="flex-column">
                <div class="contact_poster">
                    <div><h3 class="text-center"><b>Contact the Poster</b></h3></div> <!-- div label-->
                    <div>
                         <div class ="flexBox">
                             <pre class="registerFont">  Provide Your Email     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></pre>

                         </div>
                    </div> <!-- div your email textbox -->
                    <div> <pre class="registerFont text-center">Write A Message</div>
                    <div>
                        <asp:TextBox class="courseDescriptionText" ID="TextBox2" runat="server" Height="191px" Width="526px" TextMode="MultiLine"></asp:TextBox>
                    </div><!-- div email body message textbox -->
                </div>
                <div>
                    <div class ="text-right"><asp:Button class="SendEmailButton" ID="Button1" runat="server" Text="Send Message" OnClick="sendMail"></asp:Button></div>
                </div> <!-- div send email button  -->
             </div>
        </div>
</asp:Content>


