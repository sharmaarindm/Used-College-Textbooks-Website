<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="NAD_Final.FAQ" %>


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

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Accounts</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <link rel="stylesheet" href="Content/myCustom.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form class="form-horizontal" id="form1" runat="server">
     
        <div class="jumbotron ">
            <div class="flexBox2">
                <div style="flex-grow:1">
                    <asp:ImageButton class ="LogoImage" ID="ImageButton1" src="Images/ourLogo.jpg" runat="server" OnClick="Logo_Click"/>
                </div>
                <div style="flex-grow:8" class ="mainaligncentrediv">
                    <h1>Frequently Asked Questions</h1>
                </div>
                <div style="flex-grow:1">
                   <asp:ImageButton class ="LogoImage" ID="ImageButton2" Visibile = "False" src="" runat="server" />
                </div>
            </div>
            <div class="Logins">
                
                <div class="row">
                    
                    <div class="col-sm-4">
                        <asp:HyperLink ID="LoginHyperLink" runat="server" NavigateUrl="~/LoginPage.aspx">Login</asp:HyperLink>
                    </div>
                    <div class="col-sm-4">
                        <asp:HyperLink ID="AccountHyperLink" runat="server">Account</asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <br />
        <br />
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

    </form>
    <div id="footer">
         <div class="container text-center">
          <br/>
          <br/>
          <div class="row">
            <div class="col-sm-4">
                <asp:HyperLink ID="ContactUsLink" runat="server">Contact Us</asp:HyperLink>
            </div>
            <div class="col-sm-4">
                <asp:HyperLink ID="TermsOfUseLink" runat="server">Terms Of Use</asp:HyperLink>
            </div>
            <div class="col-sm-4">
                <asp:HyperLink ID="PrivacyLink" runat="server">Privacy Policy</asp:HyperLink>
            </div>
          </div>
        </div>
    </div>
</body>
</html>


