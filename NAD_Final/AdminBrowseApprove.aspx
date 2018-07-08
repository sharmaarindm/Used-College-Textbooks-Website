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
<%@ Page Title="" Language="C#" MasterPageFile="~/TextbookTrader.Master" AutoEventWireup="true" CodeBehind="AdminBrowseApprove.aspx.cs" Inherits="NAD_Final.AdminBrowseApprove" %>

<asp:Content ID="indexHeader" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="adminBrowseTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <h1>Approve Textbooks</h1>
</asp:Content>

<asp:Content ID="admin" ContentPlaceHolderID="AdminButton" runat="server">
    <asp:Button class="btn btn-info tahoma" ID="Button14" runat="server" Text="Administrate" Visible="false" OnClick="Admin_Click"/>
</asp:Content>


<asp:Content ID="indexBody" ContentPlaceHolderID="MainContent" runat="server">
            <<div class="container">

            <div class ="flexBox">
                <div>
                    <div class ="boxedRegister">
                        <div class ="flexBox">
                            <div>
                                <asp:Image ID="Image2" runat="server" Height="124px" Width="126px" />
                            </div>
                            <div>
                                <pre class="registerFont">  Title     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></pre>
                                <pre class="registerFont">  Author    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></pre>
                            </div>
                            
                        </div>
                        <div>
                            <pre class="registerFont">  ISBN                 <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></pre>
                            <pre class="registerFont">  Edition              <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></pre>
                            <pre class="registerFont">  Publisher            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></pre>
                            <pre class="registerFont">  Year Of Publication  <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></pre>
                            <pre class="registerFont">  Add course           <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList></pre>
                        </div>
                    </div>
                    <asp:Button class="addpostButton" ID="Button1" runat="server" Text="Add Post" />
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
                              
                                    <h3><asp:Label ID="Label1" runat="server" Text="Title"></asp:Label></h3>
                   
                                </div>
                                <div class="spaceonbothsides">
                                    <br />
                                    <br />
                                    <asp:Label ID="Label2" runat="server" Text="Expires: 5/26/2017"></asp:Label>
                                </div>
                                <div>
                                    <br />
                                    <div><asp:Button class="editRemoveButton" ID="Button2" runat="server" Text="Edit" /><asp:Button class="editRemoveButton RemoveButton" ID="Button3" runat="server" Text="Remove" /></div>

                                </div>
                            </div>
                   
                                    
                        </div>
                    <div class="flex-container2">
                            <div class ="flexBox">
                                <div>
                                    <div><img id="bookImage2" src="https://i.amz.mshcdn.com/oz75gS6Ke1aRMwWuu4M_jP6LSLE=/356x205/https%3A%2F%2Fblueprint-api-production.s3.amazonaws.com%2Fuploads%2Fstory%2Fthumbnail%2F62429%2F0cb95ccb-ac64-41e7-a30f-b7d1d01b094d.png"></div>
                    
                                </div>
                                <div class="spaceonbothsides">
                              
                                    <h3><asp:Label ID="Label3" runat="server" Text="Title"></asp:Label></h3>
                   
                                </div>
                                <div class="spaceonbothsides">
                                    <br />
                                    <br />
                                    <asp:Label ID="Label4" runat="server" Text="Expires: 5/26/2017"></asp:Label>
                                </div>
                                <div>
                                    <br />
                                    <div><asp:Button class="editRemoveButton" ID="Button4" runat="server" Text="Edit" /><asp:Button class="editRemoveButton RemoveButton" ID="Button5" runat="server" Text="Remove" /></div>

                                </div>
                            </div>
                   
                                    
                        </div>
                    <div class="flex-container2">
                            <div class ="flexBox">
                                <div>
                                    <div><img id="bookImage2" src="https://i.amz.mshcdn.com/oz75gS6Ke1aRMwWuu4M_jP6LSLE=/356x205/https%3A%2F%2Fblueprint-api-production.s3.amazonaws.com%2Fuploads%2Fstory%2Fthumbnail%2F62429%2F0cb95ccb-ac64-41e7-a30f-b7d1d01b094d.png"></div>
                    
                                </div>
                                <div class="spaceonbothsides">
                              
                                    <h3><asp:Label ID="Label5" runat="server" Text="Title"></asp:Label></h3>
                   
                                </div>
                                <div class="spaceonbothsides">
                                    <br />
                                    <br />
                                    <asp:Label ID="Label6" runat="server" Text="Expires: 5/26/2017"></asp:Label>
                                </div>
                                <div>
                                    <br />
                                    <div><asp:Button class="editRemoveButton" ID="Button6" runat="server" Text="Edit" /><asp:Button class="editRemoveButton RemoveButton" ID="Button7" runat="server" Text="Remove" /></div>

                                </div>
                            </div>
                   
                                    
                        </div>
                    <div class="flex-container2">
                            <div class ="flexBox">
                                <div>
                                    <div><img id="bookImage2" src="https://i.amz.mshcdn.com/oz75gS6Ke1aRMwWuu4M_jP6LSLE=/356x205/https%3A%2F%2Fblueprint-api-production.s3.amazonaws.com%2Fuploads%2Fstory%2Fthumbnail%2F62429%2F0cb95ccb-ac64-41e7-a30f-b7d1d01b094d.png"></div>
                    
                                </div>
                                <div class="spaceonbothsides">
                              
                                    <h3><asp:Label ID="Label7" runat="server" Text="Title"></asp:Label></h3>
                   
                                </div>
                                <div class="spaceonbothsides">
                                    <br />
                                    <br />
                                    <asp:Label ID="Label8" runat="server" Text="Expires: 5/26/2017"></asp:Label>
                                </div>
                                <div>
                                    <br />
                                    <div><asp:Button class="editRemoveButton" ID="Button8" runat="server" Text="Edit" /><asp:Button class="editRemoveButton RemoveButton" ID="Button9" runat="server" Text="Remove" /></div>

                                </div>
                            </div>
                   
                                    
                        </div>
                    <div class="flex-container2">
                            <div class ="flexBox">
                                <div>
                                    <div><img id="bookImage2" src="https://i.amz.mshcdn.com/oz75gS6Ke1aRMwWuu4M_jP6LSLE=/356x205/https%3A%2F%2Fblueprint-api-production.s3.amazonaws.com%2Fuploads%2Fstory%2Fthumbnail%2F62429%2F0cb95ccb-ac64-41e7-a30f-b7d1d01b094d.png"></div>
                    
                                </div>
                                <div class="spaceonbothsides">
                              
                                    <h3><asp:Label ID="Label9" runat="server" Text="Title"></asp:Label></h3>
                   
                                </div>
                                <div class="spaceonbothsides">
                                    <br />
                                    <br />
                                    <asp:Label ID="Label10" runat="server" Text="Expires: 5/26/2017"></asp:Label>
                                </div>
                                <div>
                                    <br />
                                    <div><asp:Button class="editRemoveButton" ID="Button10" runat="server" Text="Edit" /><asp:Button class="editRemoveButton RemoveButton" ID="Button11" runat="server" Text="Remove" /></div>

                                </div>
                            </div>

                        </div>
                
                     </div>
                    
                    </div>
                    <div>
                        
                        <pre class="registerFont">                 <asp:Button class="btn btn-primary" ID="Button12" runat="server" Text="<"></asp:Button>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                <asp:Label class="label label-info registerFont" ID="Label11" runat="server" Text="1"></asp:Label> <asp:Button class="btn btn-primary" ID="Button13" runat="server" Text=">"></asp:Button></pre>

                    </div>
                </div>
            </div>
        </div>
</asp:Content>




