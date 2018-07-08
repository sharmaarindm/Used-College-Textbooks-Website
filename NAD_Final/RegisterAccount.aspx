<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterAccount.aspx.cs" Inherits="NAD_Final.RegisterAccount" %>

<%--
/*
* FILE : RegisterAccount.aspx
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin, Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This interface is to allow the user to use the system and create an account depending on their institution.
* The user will be requried to specify some information in order to be able to create the account.
*/
--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <link rel="stylesheet" href="Content/myCustom.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
      
         <div class="jumbotron">
            <div class="flexBox2">
                <div style="flex-grow:1">
                    <asp:ImageButton class ="LogoImage" ID="ImageButton1" src="Images/ourLogo.jpg" runat="server" OnClick="Logo_Click"/>
                </div>
                <div style="flex-grow:8" class ="mainaligncentrediv">
                    <h1>Register Your Account</h1>
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
        <div class="container containerz">
      
            <div class ="flexBox">
                <div class="flexBoxCol">
                    <div>
                        <div class ="boxedRegister">
                            <div>
                                <pre class="registerButton">Account</pre>
                                <pre class="registerFont">  Username         <asp:TextBox ID="UserName" runat="server"></asp:TextBox></pre>
                                <pre class="registerFont">  Password         <asp:TextBox ID="password" runat="server"></asp:TextBox></pre>
                                <pre class="registerFont">  Confirm Password <asp:TextBox ID="ConfirmPassword" runat="server"></asp:TextBox></pre>

                            </div>
                        </div>

                    </div>
                    <div>
                        <div class ="boxedRegister">
                            <div>
                                
                                <pre class="registerButton">College/University</pre>
                                <pre class="registerFont">  College/University           <asp:DropDownList ID="CollegeUniversity" runat="server"></asp:DropDownList></pre>
                                <pre class="registerFont">  Estimated Year of Graduation <asp:DropDownList ID="YearOfGraduation" runat="server"></asp:DropDownList></pre>
                                <pre class="registerFont">  College Email                <asp:TextBox ID="CollegeEmail" runat="server"></asp:TextBox></pre>
                                <pre class="registerFont">  College Email Confirmation   <asp:TextBox ID="ConfirmCollegeEmail" runat="server"></asp:TextBox></pre>

                            </div>
                        </div>
                    </div>

                </div>
                
                <div class="flexBoxCol">
                    <div>
                        <div class ="boxedRegister">
                            <div>
                                <pre class="registerButton">Personal</pre>
                                <pre class="registerFont">  First Name <asp:TextBox ID="fName" runat="server"></asp:TextBox>                  </pre>
                                <pre class="registerFont">  Last Name  <asp:TextBox ID="lName" runat="server"></asp:TextBox>                  </pre>
                                <pre class="registerFont">   </pre>
                            </div>
                        </div>
                    </div>
                    <div>
                        <asp:Button class= "CreateAccountButton" ID="CreateAccount" runat="server" Text="Create Account" />
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
