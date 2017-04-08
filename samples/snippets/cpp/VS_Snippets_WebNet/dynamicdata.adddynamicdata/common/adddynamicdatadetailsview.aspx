<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddDynamicDataDetailsView.aspx.cs" Inherits="AddDynamicDataDetailsView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <h2 class="DDSubHeader">Accessing <%= table.DisplayName%> Table Using a DetailsView Control and Dynamic Data</h2>
  
    <br />
    
    <div class="DDNavigation">
       <a id="A3" runat="server" href="~/default.aspx">
       <img id="Img3" alt="Back to home page" runat="server" src="~/DynamicData/Content/Images/back.gif" />Back to home page</a>
    </div>
    
    <div class="ExampleView"> 
     This example shows how to add dynamic behavior to the 
     <code><a href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.detailsview.aspx" 
        target="_blank">System.Web.UI.WebControls.DetailsView</a></code> control by using the following types:
        <ul>
            <li><code><a href="http://msdn.microsoft.com/en-us/library/system.web.dynamicdata.dynamicfield.aspx" 
                target="_blank">System.Web.DynamicData.DynamicField</a></code></li>
            <li><code><a href="http://msdn.microsoft.com/en-us/library/system.web.dynamicdata.dynamicdatamanager.aspx" 
                target="_blank">System.Web.DynamicData.DynamicDataManager</a></code></li>
        </ul>
     </div>
     
    <form id="form1" runat="server">
    
       
        <%-- Define the script manager to manage partial rendering. --%>
        <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server"/>
        
       
        <hr />
   
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
  
            <ContentTemplate>
    
                <asp:DynamicDataManager ID="DynamicDataManager1" runat="server">
                    <DataControls>
                        <asp:DataControlReference ControlID="DetailsView1" />
                    </DataControls>
                </asp:DynamicDataManager>
        
                <asp:LinqDataSource ID="GridDataSource" runat="server"    
                    EnableUpdate="True" EnableDelete="true"
                    ContextTypeName="AdventureWorksLTDataContext"
                    TableName="SalesOrderDetails" />
               <%-- <Snippet2> --%>
                <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" 
                    CssClass="DDDetailsTable"
                    AutoGenerateRows="False" DataSourceID="GridDataSource">
                    
                    <Fields>
                        <asp:DynamicField DataField="OrderQty" HeaderText="Order Quantity" />
                        <asp:DynamicField DataField="UnitPrice" HeaderText="Unit Price" />
                        <asp:DynamicField DataField="ModifiedDate" HeaderText="Modified Date" />
                        <asp:DynamicField DataField="Product" HeaderText="Product" />
                        
                        <asp:TemplateField ShowHeader="False" >
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit" Text="Edit" /> &nbsp;
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" Text="Delete"
                                    OnClientClick='return confirm("Are you sure you want to delete this item?");' />
                            </ItemTemplate>
                            
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                    CommandName="Update" Text="Update"></asp:LinkButton> &nbsp;
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                    CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        
                    </Fields>
                   
                </asp:DetailsView>
                <%-- </Snippet2> --%>
       
            </ContentTemplate>
  
        </asp:UpdatePanel>
    </form>
</body>
</html>
