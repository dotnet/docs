<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddDynamicDataListView.aspx.cs" Inherits="AddDynamicDataListView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <h2 class="DDSubHeader">Accessing <%= table.DisplayName%> Using a ListView Control and Dynamic Data</h2>
  
    <br />
    
    <div class="DDNavigation">
       <a id="A3" runat="server" href="~/default.aspx">
       <img id="Img3" alt="Back to home page" runat="server" src="~/DynamicData/Content/Images/back.gif" />Back to home page</a>
    </div>
    
    <div class="ExampleView"> 
     This example shows how to add dynamic behavior to the 
     <code><a href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.listview.aspx" 
        target="_blank">System.Web.UI.WebControls.ListView</a></code> control by using the following types:
        <ul>
            <li><code><a href="http://msdn.microsoft.com/en-us/library/system.web.dynamicdata.dynamicdatamanager.aspx" 
                target="_blank">System.Web.DynamicData.DynamicDataManager</a></code></li>
            <li><code><a href="http://msdn.microsoft.com/en-us/library/system.web.dynamicdata.dynamicvalidator.aspx" 
                target="_blank">System.Web.DynamicData.DynamicValidator</a></code></li>
            <li><code><a href="http://msdn.microsoft.com/en-us/library/system.web.dynamicdata.dynamiccontrol.aspx" 
                target="_blank">System.Web.DynamicData.DynamicControl</a></code></li>
        </ul>
     </div>
     
    <form id="form1" runat="server">
    
       
        <%-- Define the script manager to manage partial rendering. --%>
        <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server"/>
        
       
        <hr />
   
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
  
            <ContentTemplate>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="true" 
                    HeaderText="List of validation errors" CssClass="DDValidator"  />
                <asp:DynamicValidator runat="server" ID="DynamicValidator1"
                    ControlToValidate="ListView1" Display="None" CssClass="DDValidator"  />

                 <asp:DynamicDataManager ID="DynamicDataManager1" runat="server">
                    <DataControls>
                        <asp:DataControlReference ControlID="ListView1" />
                    </DataControls>
                </asp:DynamicDataManager>
        
                <asp:EntityDataSource ID="EntityDataSource1" runat="server" 
                    ContextTypeName="AdventureWorksLT_DataModel.AdventureWorksLT_DataEntities" 
                    EnableDelete="True" 
                    EnableFlattening="False" EnableInsert="True" EnableUpdate="True" 
                    EntitySetName="Customers" 
                    ConnectionString="name=AdventureWorksLT_DataEntities" 
                    DefaultContainerName="AdventureWorksLT_DataEntities">
                </asp:EntityDataSource>


            

            </ContentTemplate>


        </asp:UpdatePanel>

        <%-- <Snippet3> --%>
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="CustomerID"  
            DataSourceID="EntityDataSource1">
            
            <EditItemTemplate>
                <tr style="">
                    <td>
                        <asp:LinkButton ID="UpdateButton" runat="server" CommandName="Update" 
                         CausesValidation="true" Text="Update" />
                        <asp:LinkButton ID="CancelButton" runat="server" CommandName="Cancel"  
                        CausesValidation="false" Text="Cancel" />
                    </td>
                 
                   
                    <td>
                        <asp:DynamicControl runat="server" DataField="FirstName" Mode="Edit" />
                    </td>
                   
                    <td>
                        <asp:DynamicControl runat="server" DataField="LastName" Mode="Edit" />
                    </td>
                   
                    <td>
                        <asp:DynamicControl runat="server" DataField="CompanyName" Mode="Edit" />
                    </td>

                    <td>
                        <asp:DynamicControl runat="server" DataField="EmailAddress" Mode="Edit" />
                    </td>
                   
                    <td>
                        <asp:DynamicControl runat="server" DataField="ModifiedDate" Mode="Edit" />
                    </td>
                    
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>
                            No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
           
            <ItemTemplate>
                <tr style="">
                    <td>
                       
                        <asp:LinkButton ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" Text="Delete"
                            OnClientClick='return confirm("Are you sure you want to delete this item?");' />

                    </td>
                  
                    
                    <td>
                        <asp:DynamicControl runat="server" DataField="FirstName" Mode="ReadOnly" />
                    </td>
                    
                    <td>
                        <asp:DynamicControl runat="server" DataField="LastName" Mode="ReadOnly" />
                    </td>
                    
                    <td>
                        <asp:DynamicControl runat="server" DataField="CompanyName" Mode="ReadOnly" />
                    </td>
                   
                    <td>
                        <asp:DynamicControl runat="server" DataField="EmailAddress" Mode="ReadOnly" />
                    </td>
                    
                    <td>
                        <asp:DynamicControl runat="server" DataField="ModifiedDate" Mode="ReadOnly" />
                    </td>
                    
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table  class="ExampleView" runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table ID="itemPlaceholderContainer" runat="server" border="0" style="">
                                <tr runat="server" style="">
                                    <th runat="server">
                                    </th>
                                   
                                    <th runat="server">
                                        FirstName</th>
                                   
                                    <th runat="server">
                                        LastName</th>
                                    
                                    <th runat="server">
                                        CompanyName</th>
                                    
                                    <th runat="server">
                                        EmailAddress</th>
                                    
                                    <th runat="server">
                                        ModifiedDate</th>
                                  
                                </tr>
                                <tr ID="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NumericPagerField />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="">
                    <td>
                       
                        <asp:LinkButton ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" Text="Delete"
                            OnClientClick='return confirm("Are you sure you want to delete this item?");' />
                    </td>
                   
                    <td>
                        <asp:DynamicControl runat="server" DataField="FirstName" Mode="ReadOnly" />
                    </td>
                    
                    <td>
                        <asp:DynamicControl runat="server" DataField="LastName" Mode="ReadOnly" />
                    </td>
                    
                    <td>
                        <asp:DynamicControl runat="server" DataField="CompanyName" Mode="ReadOnly" />
                    </td>
                    
                    <td>
                        <asp:DynamicControl runat="server" DataField="EmailAddress" Mode="ReadOnly" />
                    </td>
                    
                    <td>
                        <asp:DynamicControl runat="server" DataField="ModifiedDate" Mode="ReadOnly" />
                    </td>
                   
                   
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>

        <%-- </Snippet3> --%>
    </form>
</body>
</html>
