
<%@ Page Title="" Language="C#" MasterPageFile="~/TextbookTrader.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="NAD_Final.FAQ" %>

<%--
/*
* FILE : FAQ.aspx
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin, Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This is the frequently asked questions interface. The users cab browse this page in order to find answers to commonly asked
* questions.
*/
--%>

<asp:Content ID="indexHeader" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="adminBrowseTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <h1>Frequently Asked Questions</h1>
</asp:Content>

<asp:Content ID="admin" ContentPlaceHolderID="AdminButton" runat="server">
    <asp:Button class="btn btn-info tahoma" ID="Button14" runat="server" Text="Administrate" Visible="false" OnClick="Admin_Click"/>
</asp:Content>

<asp:Content ID="indexBody" ContentPlaceHolderID="MainContent" runat="server">
       <div class="container">
      
            <div class ="boxedFAQ">
                <div class="flexBox">
                    <div> 
                        <br />
                        <p class="FAQQuestion">Question <asp:Label ID="Question1" runat="server" Text="________________________________"></asp:Label></p>
                        <br />
                        <p class="FAQQuestion">Question <asp:Label ID="Question2" runat="server" Text="________________________________ "></asp:Label></p>
                        <br />
                        <p class="FAQQuestion">Question <asp:Label ID="Question3" runat="server" Text="________________________________"></asp:Label></p>
                        <br />
                        <p class="FAQQuestion">Question <asp:Label ID="Question4" runat="server" Text="________________________________"></asp:Label></p>
                        <br />
                        <p class="FAQQuestion">Question <asp:Label ID="Question5" runat="server" Text="________________________________"></asp:Label></p>
                        <br />
                        <p class="FAQQuestion">Question <asp:Label ID="Question6" runat="server" Text="________________________________"></asp:Label></p>
                        <br />
                    </div>
                    <div>
                         <br />
                        <p class="FAQAnswer">Answer <asp:Label ID="Answer1" runat="server" Text="________________________________"></asp:Label></p>
                        <br />
                        <p class="FAQAnswer">Answer <asp:Label ID="Answer2" runat="server" Text="________________________________"></asp:Label></p>
                        <br />
                        <p class="FAQAnswer">Answer <asp:Label ID="Answer3" runat="server" Text="________________________________"></asp:Label></p>
                        <br />
                        <p class="FAQAnswer">Answer <asp:Label ID="Answer4" runat="server" Text="________________________________"></asp:Label></p>
                        <br />
                        <p class="FAQAnswer">Answer <asp:Label ID="Answer5" runat="server" Text="________________________________"></asp:Label></p>
                        <br />
                        <p class="FAQAnswer">Answer <asp:Label ID="Answer6" runat="server" Text="________________________________"></asp:Label></p>
                        <br />
                    </div>

                </div>
            </div>
        </div>
</asp:Content>



