<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageAccounts.aspx.cs" Inherits="NAD_Final.ManageAccounts" %>

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
                    <asp:ImageButton class ="LogoImage" ID="ImageButton2" src="Images/ourLogo.jpg" runat="server" OnClick="Logo_Click"/>
                </div>
                <div style="flex-grow:8" class ="mainaligncentrediv">
                    <h1>Manage Accounts</h1>
                </div>
                <div style="flex-grow:1">
                   <asp:ImageButton class ="LogoImage" ID="ImageButton3" Visibile = "False" src="" runat="server" />
                </div>
            </div>
            <div class="Logins">
                
                <div class="row">
                    
                    <div class="col-sm-4">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/LoginPage.aspx">Login</asp:HyperLink>
                    </div>
                    <div class="col-sm-4">
                        <asp:HyperLink ID="HyperLink2" runat="server">Account</asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>
        <div class="afterjumbo">
            <br/>
            <br/>
            <div class="row" id="mainbuttons">
                <div class="flexBox">
                        <div>
                            <asp:Button class="indexButtons2" ID="institute" runat="server" Text="Add/Remove Institution" OnClick="ARInstitution_click" />
                        </div>
                
                        <div>
                            <asp:Button class="indexButtons2 indexButtons2margin" ID="admin" runat="server" Text="Add/Remove System Admin" OnClick="ARSysAdmin_Click" />
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

