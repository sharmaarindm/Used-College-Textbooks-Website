<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminBrowseApprove.aspx.cs" Inherits="NAD_Final.AdminBrowseApprove" %>

<%--
/*
* FILE : AdminBrowseApprove.aspx
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin, Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This file is the admins view of the browser. The admin uses this view in order to browse posts that were 
* request by the users creating posts in order to sell boooks.
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
    <link rel="stylesheet" href="Content/BrowseStyleSheet.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron">
            <h1 class="leftspace">  Post Your Textbooks</h1>
        </div>

        <div class="container">

            <div class ="flexBox">
                <div>
                    <div class ="boxedRegister">
                        <div class ="flexBox">
                            <div>
                                <asp:Image ID="Image1" runat="server" Height="124px" Width="126px" />
                            </div>
                            <div>
                                <pre class="registerFont">  Title     <asp:TextBox ID="Title" runat="server"></asp:TextBox></pre>
                                <pre class="registerFont">  Author    <asp:TextBox ID="Author" runat="server"></asp:TextBox></pre>
                            </div>
                            
                        </div>
                        <div>
                            <pre class="registerFont">  ISBN                 <asp:TextBox ID="ISBN" runat="server"></asp:TextBox></pre>
                            <pre class="registerFont">  Edition              <asp:TextBox ID="Edition" runat="server"></asp:TextBox></pre>
                            <pre class="registerFont">  Publisher            <asp:TextBox ID="Publisher" runat="server"></asp:TextBox></pre>
                            <pre class="registerFont">  Year Of Publication  <asp:TextBox ID="YearOfPublication" runat="server"></asp:TextBox></pre>
                            <pre class="registerFont">  Add course           <asp:DropDownList ID="AddCourse" runat="server"></asp:DropDownList></pre>
                        </div>
                    </div>
                    <asp:Button class="addpostButton" ID="AddPost" runat="server" Text="Add Post" />
                </div>

                <div>
                <div class="flex-container3">
                <div id="resultsListbox">
                    <div class="flex-container2">
                            <div class ="flexBox">
                                <div>
                                    <div><img id="bookImage2" src="https://i.amz.mshcdn.com/oz75gS6Ke1aRMwWuu4M_jP6LSLE=/356x205/https%3A%2F%2Fblueprint-api-production.s3.amazonaws.com%2Fuploads%2Fstory%2Fthumbnail%2F62429%2F0cb95ccb-ac64-41e7-a30f-b7d1d01b094d.png"></div>
                    
                                </div>
                                <div class="spaceonbothsides">
                              
                                    <h3><asp:Label ID="Title1" runat="server" Text="Title"></asp:Label></h3>
                   
                                </div>
                                <div class="spaceonbothsides">
                                    <br />
                                    <br />
                                    <asp:Label ID="expireDate1" runat="server" Text="Expires: 5/26/2017"></asp:Label>
                                </div>
                                <div>
                                    <br />
                                    <div><asp:Button class="editRemoveButton" ID="Edit1" runat="server" Text="Edit" /><asp:Button class="editRemoveButton RemoveButton" ID="Remove1" runat="server" Text="Remove" /></div>

                                </div>
                            </div>
                   
                                    
                        </div>
                    <div class="flex-container2">
                            <div class ="flexBox">
                                <div>
                                    <div><img id="bookImage2" src="https://i.amz.mshcdn.com/oz75gS6Ke1aRMwWuu4M_jP6LSLE=/356x205/https%3A%2F%2Fblueprint-api-production.s3.amazonaws.com%2Fuploads%2Fstory%2Fthumbnail%2F62429%2F0cb95ccb-ac64-41e7-a30f-b7d1d01b094d.png"></div>
                    
                                </div>
                                <div class="spaceonbothsides">
                              
                                    <h3><asp:Label ID="Title2" runat="server" Text="Title"></asp:Label></h3>
                   
                                </div>
                                <div class="spaceonbothsides">
                                    <br />
                                    <br />
                                    <asp:Label ID="expireDate2" runat="server" Text="Expires: 5/26/2017"></asp:Label>
                                </div>
                                <div>
                                    <br />
                                    <div><asp:Button class="editRemoveButton" ID="Edit2" runat="server" Text="Edit" /><asp:Button class="editRemoveButton RemoveButton" ID="Remove2" runat="server" Text="Remove" /></div>

                                </div>
                            </div>
                   
                                    
                        </div>
                    <div class="flex-container2">
                            <div class ="flexBox">
                                <div>
                                    <div><img id="bookImage2" src="https://i.amz.mshcdn.com/oz75gS6Ke1aRMwWuu4M_jP6LSLE=/356x205/https%3A%2F%2Fblueprint-api-production.s3.amazonaws.com%2Fuploads%2Fstory%2Fthumbnail%2F62429%2F0cb95ccb-ac64-41e7-a30f-b7d1d01b094d.png"></div>
                    
                                </div>
                                <div class="spaceonbothsides">
                              
                                    <h3><asp:Label ID="Title3" runat="server" Text="Title"></asp:Label></h3>
                   
                                </div>
                                <div class="spaceonbothsides">
                                    <br />
                                    <br />
                                    <asp:Label ID="expireDate3" runat="server" Text="Expires: 5/26/2017"></asp:Label>
                                </div>
                                <div>
                                    <br />
                                    <div><asp:Button class="editRemoveButton" ID="Edit3" runat="server" Text="Edit" /><asp:Button class="editRemoveButton RemoveButton" ID="Remove3" runat="server" Text="Remove" /></div>

                                </div>
                            </div>
                   
                                    
                        </div>
                    <div class="flex-container2">
                            <div class ="flexBox">
                                <div>
                                    <div><img id="bookImage2" src="https://i.amz.mshcdn.com/oz75gS6Ke1aRMwWuu4M_jP6LSLE=/356x205/https%3A%2F%2Fblueprint-api-production.s3.amazonaws.com%2Fuploads%2Fstory%2Fthumbnail%2F62429%2F0cb95ccb-ac64-41e7-a30f-b7d1d01b094d.png"></div>
                    
                                </div>
                                <div class="spaceonbothsides">
                              
                                    <h3><asp:Label ID="Title4" runat="server" Text="Title"></asp:Label></h3>
                   
                                </div>
                                <div class="spaceonbothsides">
                                    <br />
                                    <br />
                                    <asp:Label ID="expireDate4" runat="server" Text="Expires: 5/26/2017"></asp:Label>
                                </div>
                                <div>
                                    <br />
                                    <div><asp:Button class="editRemoveButton" ID="Edit4" runat="server" Text="Edit" /><asp:Button class="editRemoveButton RemoveButton" ID="Remove4" runat="server" Text="Remove" /></div>

                                </div>
                            </div>
                   
                                    
                        </div>
                    <div class="flex-container2">
                            <div class ="flexBox">
                                <div>
                                    <div><img id="bookImage2" src="https://i.amz.mshcdn.com/oz75gS6Ke1aRMwWuu4M_jP6LSLE=/356x205/https%3A%2F%2Fblueprint-api-production.s3.amazonaws.com%2Fuploads%2Fstory%2Fthumbnail%2F62429%2F0cb95ccb-ac64-41e7-a30f-b7d1d01b094d.png"></div>
                    
                                </div>
                                <div class="spaceonbothsides">
                              
                                    <h3><asp:Label ID="Title5" runat="server" Text="Title"></asp:Label></h3>
                   
                                </div>
                                <div class="spaceonbothsides">
                                    <br />
                                    <br />
                                    <asp:Label ID="expireDate5" runat="server" Text="Expires: 5/26/2017"></asp:Label>
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
                        
                        <pre class="registerFont">                 <asp:Button class="btn btn-primary" ID="back" runat="server" Text="<"></asp:Button> <asp:Label class="label label-info registerFont" ID="currentPage" runat="server" Text="1"></asp:Label> <asp:Button class="btn btn-primary" ID="next" runat="server" Text=">"></asp:Button></pre>

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
