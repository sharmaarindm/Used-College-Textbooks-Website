
<%@ Page Title="" Language="C#" MasterPageFile="~/TextbookTrader.Master" AutoEventWireup="true" CodeBehind="sysAdminAddRemoveInstitute.aspx.cs" Inherits="NAD_Final.sysAdminAddRemoveInstitute" %>


<%--
/*
* FILE : sysAdminAddRemoveInstitution.aspx
* PROJECT : NAD - Project proof of concept
* PROGRAMMER : Arindm Sharm, Jody Markic, Zivojin Pecin,Sean Moulton
* FIRST VERSION : 2017-11-8
* DESCRIPTION :
* This file is interface for the system admin user in order to be able to add or remove an institution.
*/
--%>

<asp:Content ID="indexHeader" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="adminAddRemoveInstitutionTitle" ContentPlaceHolderID="TitleContent" runat="server">
    <h1>Add/Remove Institution</h1>
</asp:Content>

<asp:Content ID="admin" ContentPlaceHolderID="AdminButton" runat="server">
    <asp:Button class="btn btn-info tahoma" ID="Button14" runat="server" Text="Administrate" Visible="false" OnClick="Admin_Click"/>
</asp:Content>

<asp:Content ID="indexBody" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
          function newTitle_ClientClicked()
          {
              document.getElementById("<%=Institute.ClientID%>").value = "";
              document.getElementById("<%=Institute.ClientID%>").style.color = "black";
        }
    </script>
  <div class="container">
            <div class ="flexBox">
                <%--<div class="text-center" >--%>
                   <%-- <asp:Label  ID="alerts" runat="server" Text=""></asp:Label>--%>
                <div style="margin-right:5px">
                    <div class ="boxedRegister">
                        <div>
                           
                            <pre>       <h1><asp:Label ID="EditInstName" runat="server" Text="Add New Institute"></asp:Label></h1></pre>
                            
                        </div>
                        <div>
                            <pre class="registerFont">    <asp:Label ID="NewInstName" runat="server" Text="Institute name"></asp:Label>            <asp:TextBox ID="Institute" runat="server" OnClick="newTitle_ClientClicked()"></asp:TextBox></pre>
                            
                        </div>
                    </div>
                    <div style="margin-top:20px; margin-right:15px">
                        <asp:Button class="addpostButton" ID="AddInstitute" runat="server" Text="Add Institute" OnClick="AddInstituteButton_Click"/>
                    </div>
                </div>
               <%-- asdadasdasdas--%>
                <div>
                    <asp:ListView ID="instituteListView" runat="server" OnSelectedIndexChanged="instituteListView_SelectedIndexChanged" AutoPostBack="True" ShowItemToolTips ="True">
                        <LayoutTemplate>
                            <div class="result-scroll-bar">
                               <%-- <table style="width:auto">--%>
                                <table class="border">
                                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>              
                               <%-- </Table>--%>
                                </table>
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr class="border">
                                <td class="align-data text-nowrap"><h3>Title: <%#Eval("_institution_name") %></h3></td>
                                <td class="align-data-buttons">
                                     <asp:Button class="ListViewButton" ID="editInstitutebutton" runat="server" Text="Edit" OnClick="editInstitute_Click"/>
                                     <asp:Button class="ListViewButton" ID="deleteInstituteButton" runat="server" Text="Delete" OnClick="DeleteInstitute_Click"/>
                                </td>     
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                 </div>


<%--                <div>
                <div class="flex-container3">
                <div id="resultsListbox">
                    <div class="flex-container2">
                            <div class ="flexBox">
                                
                                <div class="spaceonbothsides">
                              
                                    <h3><asp:Label ID="Title1" runat="server" Text="Name of Institute"></asp:Label></h3>
                   
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
                              
                                    <h3><asp:Label ID="Title2" runat="server" Text="Name of Institute"></asp:Label></h3>
                   
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
                              
                                    <h3><asp:Label ID="Title3" runat="server" Text="Name of Institute"></asp:Label></h3>
                   
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
                              
                                    <h3><asp:Label ID="Title4" runat="server" Text="Name of Institute"></asp:Label></h3>
                   
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
                              
                                    <h3><asp:Label ID="Title5" runat="server" Text="Name of Institute"></asp:Label></h3>
                   
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
                    </div>
                </div>--%>

           <%-- </div>--%>
        </div>
</asp:Content>