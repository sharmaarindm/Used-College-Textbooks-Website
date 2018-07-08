
<%@ Page Title="" Language="C#" MasterPageFile="~/TextbookTrader.Master" AutoEventWireup="true" CodeBehind="RegisterAccount.aspx.cs" Inherits="NAD_Final.RegisterAccount" %>

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


<asp:Content ID="indexHeader" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="adminBrowseTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <h1>Register Now!</h1>
</asp:Content>

<asp:Content ID="admin" ContentPlaceHolderID="AdminButton" runat="server">
    <asp:Button class="btn btn-info tahoma" ID="Button14" runat="server" Text="Administrate" Visible="false" OnClick="Admin_Click"/>
</asp:Content>

<asp:Content ID="indexBody" ContentPlaceHolderID="MainContent" runat="server">

     <script type="text/javascript">
         function Username_ClientClicked()
          {
              document.getElementById("<%=UserName.ClientID%>").value = "";
              document.getElementById("<%=UserName.ClientID%>").style.color = "black";
         }
         function Password_ClientClicked() {
             document.getElementById("<%=password.ClientID%>").value = "";
             document.getElementById("<%=password.ClientID%>").style.color = "black";
         }
         function ConfirmPassword_ClientClicked() {
             document.getElementById("<%=ConfirmPassword.ClientID%>").value = "";
             document.getElementById("<%=ConfirmPassword.ClientID%>").style.color = "black";
         }
        
         function fName_ClientClicked() {
             document.getElementById("<%=fName.ClientID%>").value = "";
             document.getElementById("<%=fName.ClientID%>").style.color = "black";
         }
         function lName_ClientClicked() {
             document.getElementById("<%=lName.ClientID%>").value = "";
             document.getElementById("<%=lName.ClientID%>").style.color = "black";
         }

    </script>
     <div class="container">
            <div class="text-center" style="margin-top: -2%;"><h3><asp:Label ID="errorLabel" runat="server" Visible="false" Text="Test where this lands"></asp:Label></h3></div>
            <div class ="flexBox">
                <div class="flexBoxCol">
                    <div>
                        <div class ="boxedRegister">
                            <div>
                                <pre class="registerButton">Account</pre>
                                <pre class="registerFont">  College Email                <asp:TextBox class="addremoveuserbox" ID="UserName" runat="server" OnClick ="Username_ClientClicked()"></asp:TextBox></pre>
                                <pre class="registerFont">  Password                     <asp:TextBox class="addremoveuserbox" ID="password" runat="server" TextMode="Password" OnClick ="Password_ClientClicked()"></asp:TextBox></pre>
                                <pre class="registerFont">  Confirm Password             <asp:TextBox class="addremoveuserbox" ID="ConfirmPassword" runat="server" TextMode="Password" OnClick ="ConfirmPassword_ClientClicked()"></asp:TextBox></pre>

                            </div>
                        </div>

                    </div>
                    <div>
                        <div class ="boxedRegister">
                            <div>
                                
                                <pre class="registerButton">College/University</pre>
                                <pre class="registerFont">  College/University           <asp:DropDownList class="comboheight" ID="CollegeUniversity" runat="server" AutoPostBack="True"></asp:DropDownList></pre>
                                <pre class="registerFont">  Estimated Year of Graduation <asp:DropDownList class="comboheight" ID="YearOfGraduation" runat="server" AutoPostBack="True"></asp:DropDownList></pre>
                               
                            </div>
                        </div>
                    </div>

                </div>
                
                <div class="flexBoxCol">
                    <div>
                        <div class ="boxedRegister">
                            <div>
                                <pre class="registerButton">Personal</pre>
                                <pre class="registerFont">  First Name <asp:TextBox ID="fName" class="addremoveuserbox" runat="server" OnClick ="fName_ClientClicked()"></asp:TextBox></pre>
                                <pre class="registerFont">  Last Name  <asp:TextBox ID="lName" class="addremoveuserbox" runat="server" OnClick ="lName_ClientClicked()"></asp:TextBox></pre>
                              
                            </div>
                        </div>
                    </div>
                    <div>
                        <asp:Button class= "CreateAccountButton" ID="CreateAccount" runat="server" Text="Create Account"  OnClick="Create_Click"/>
                    </div>

                </div>
                
            </div>
            
        </div>
</asp:Content>

