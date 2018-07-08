<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sysAdminAddRemoveAdmin.aspx.cs" Inherits="NAD_Final.sysAdminAddRemoveAdmin" %>

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


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ADD/REMOVE Administerator</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <link rel="stylesheet" href="Content/myCustom.css">
    <link rel="stylesheet" href="Content/BrowseStyleSheet.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
         <div class="jumbotron ">
            <div class="flexBox2">
                <div style="flex-grow:1">
                    <asp:ImageButton class ="LogoImage" ID="ImageButton1" src="Images/ourLogo.jpg" runat="server" OnClick="Logo_Click"/>
                </div>
                <div style="flex-grow:8" class ="mainaligncentrediv">
                    <h1>ADD/REMOVE Administerator</h1>
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


        <div class="container">

            <div class ="flexBox">
                <div>
                    <div class ="boxedRegister">
                        <div>
                           
                            <pre>               <h1>Add New System Admin</h1></pre>
                            
                        </div>
                        <div>
                            <pre class="registerFont">  Admin name                 <asp:TextBox ID="AdminName" runat="server"></asp:TextBox></pre>
                            <pre class="registerFont">  Username                   <asp:TextBox ID="Username" runat="server"></asp:TextBox></pre>
                            <pre class="registerFont">  Password                   <asp:TextBox ID="Password" runat="server"></asp:TextBox></pre>
                        </div>
                    </div>
                    <asp:Button class="addpostButton" ID="AddAdmin" runat="server" Text="Add Admin" />
                </div>

                <div>
                <div class="flex-container3">
                <div id="resultsListbox">
                    <div class="flex-container2">
                            <div class ="flexBox">
                                
                                <div class="spaceonbothsides">
                              
                                    <h3><asp:Label ID="Title1" runat="server" Text="Admin Username"></asp:Label></h3>
                   
                                </div>
                              
                                <div>
                                    <br />
                                    <div><asp:Button class="editRemoveButton" ID="Edit1" runat="server" Text="Edit" /><asp:Button class="editRemoveButton RemoveButton" ID="Remove1" runat="server" Text="Remove" /></div>

                                </div>
                            </div>
                   
                                    
                        </div>
                    <div class="flex-container2">
                            <div class ="flexBox">
                                
                                <div class="spaceonbothsides">
                              
                                    <h3><asp:Label ID="Title2" runat="server" Text="Admin Username"></asp:Label></h3>
                   
                                </div>
                              
                                <div>
                                    <br />
                                    <div><asp:Button class="editRemoveButton" ID="Edit2" runat="server" Text="Edit" /><asp:Button class="editRemoveButton RemoveButton" ID="Remove2" runat="server" Text="Remove" /></div>

                                </div>
                            </div>
                   
                                    
                        </div>
                    <div class="flex-container2">
                            <div class ="flexBox">
                                
                                <div class="spaceonbothsides">
                              
                                    <h3><asp:Label ID="Title3" runat="server" Text="Admin Username"></asp:Label></h3>
                   
                                </div>
                              
                                <div>
                                    <br />
                                    <div><asp:Button class="editRemoveButton" ID="Edit3" runat="server" Text="Edit" /><asp:Button class="editRemoveButton RemoveButton" ID="Remove3" runat="server" Text="Remove" /></div>

                                </div>
                            </div>
                   
                                    
                        </div>
                    <div class="flex-container2">
                            <div class ="flexBox">
                                
                                <div class="spaceonbothsides">
                              
                                    <h3><asp:Label ID="Title4" runat="server" Text="Admin Username"></asp:Label></h3>
                   
                                </div>
                              
                                <div>
                                    <br />
                                    <div><asp:Button class="editRemoveButton" ID="Edit4" runat="server" Text="Edit" /><asp:Button class="editRemoveButton RemoveButton" ID="Remove4" runat="server" Text="Remove" /></div>

                                </div>
                            </div>
                   
                                    
                        </div>
               <div class="flex-container2">
                            <div class ="flexBox">
                                
                                <div class="spaceonbothsides">
                              
                                    <h3><asp:Label ID="Title5" runat="server" Text="Admin Username"></asp:Label></h3>
                   
                                </div>
                              
                                <div>
                                    <br />
                                    <div><asp:Button class="editRemoveButton" ID="Edit5" runat="server" Text="Edit" /><asp:Button class="editRemoveButton RemoveButton" ID="Remove5" runat="server" Text="Remove" /></div>

                                </div>
                            </div>
                   
                                    
                        </div>
                
                     </div>
                    
                    </div>
                    <div>
                        
                        <pre class="registerFont">            <asp:Button class="btn btn-primary" ID="back" runat="server" Text="<"></asp:Button> <asp:Label class="label label-info registerFont" ID="currentPage" runat="server" Text="1"></asp:Label> <asp:Button class="btn btn-primary" ID="next" runat="server" Text=">"></asp:Button></pre>

                    </div>
                </div>
            </div>
        </div>

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
    </form>
</body>
</html>
