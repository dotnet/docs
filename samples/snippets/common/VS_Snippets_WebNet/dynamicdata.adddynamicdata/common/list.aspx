<%@ Page Language="C#" CodeFile="List.aspx.cs" Inherits="List" %>

<%@ Register src="~/DynamicData/Content/GridViewPager.ascx" tagname="GridViewPager" tagprefix="asp" %>

<%@ Register TagPrefix="Uedd" Src="~/DynamicData/Content/MoreInformation.ascx" TagName="Doc" %> 

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>

    <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" AutoLoadForeignKeys="true">
        <DataControls>
            <asp:DataControlReference ControlID="GridView1" />
        </DataControls>
    </asp:DynamicDataManager>
    
     
    <h2 class="DDSubHeader">Accessing <%= table.DisplayName%> Table Using a GridView Control and Dynamic Data</h2>
    
    <form id="form1" runat="server">
    
    <%-- Define the script manager to manage partial rendering. --%>
    <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server"/>
   
 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        
         
            <%-- Add on-line documentatiion. --%> 
            <div  class="ExampleView">
                To verify that the Dynamic Data features have been added to the GridView control, 
                perform the following steps:
            </div>
            <Uedd:Doc ID="docID" runat="server" 
                FilePath="DynamicData/CustomPages/SalesOrderDetails/SalesOrderDetails.htm" />
             
            <br /> <br />
            
            <div class="DD">
                <%-- Define the validation controls to validate the GridView control. --%>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" EnableClientScript="true"
                    HeaderText="List of validation errors" CssClass="DDValidator" />
                <asp:DynamicValidator runat="server" ID="GridViewValidator" ControlToValidate="GridView1" Display="None" CssClass="DDValidator" />

               <%-- Define the data filtering controls. --%>
                    <asp:QueryableFilterRepeater runat="server" ID="FilterRepeater">
                        <ItemTemplate>
                            <span  style="margin:20px 0px 1000px 10px;"><asp:Label ID="Label1" runat="server" Text='<%# Eval("DisplayName") %>' OnPreRender="Label_PreRender" />
                            <asp:DynamicFilter runat="server" ID="DynamicFilter" OnFilterChanged="DynamicFilter_FilterChanged" /></span>
                        </ItemTemplate>
                    </asp:QueryableFilterRepeater>
            </div>

            <hr /> 

	    <%-- <Snippet1> --%> 
            <asp:GridView ID="GridView1" runat="server" DataSourceID="GridDataSource" 
                EnablePersistedSelection="True" AutoGenerateColumns="False" GridLines="None" 
                AllowPaging="True" AllowSorting="True" CssClass="DDGridView"
                RowStyle-CssClass="td" HeaderStyle-CssClass="th" CellPadding="6">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:DynamicHyperLink runat="server" Action="Edit" Text="Edit"
                            />&nbsp;<asp:LinkButton runat="server" CommandName="Delete" Text="Delete"
                                OnClientClick='return confirm("Are you sure you want to delete this item?");'
                            />&nbsp;<asp:DynamicHyperLink runat="server" Text="Details" /> 
                             
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:DynamicField DataField="OrderQty" HeaderText="Order Quantity" />
                    <asp:DynamicField DataField="UnitPrice" HeaderText="Unit Price" />
                    <asp:DynamicField DataField="ModifiedDate" HeaderText="Modified Date" />
                    <asp:DynamicField DataField="SalesOrderHeader" HeaderText="Sales Order" />
                    <asp:DynamicField DataField="Product" HeaderText="Product Name" />
                </Columns>
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle CssClass="th" />
               
                <PagerStyle CssClass="DDFooter"/>        
                <PagerTemplate>
                    <asp:GridViewPager runat="server" />
                </PagerTemplate>
                <EmptyDataTemplate>
                    There are currently no items in this table.
                </EmptyDataTemplate>
                <RowStyle CssClass="td" />
            </asp:GridView>
	    <%-- </Snippet1> --%> 

            <asp:LinqDataSource ID="GridDataSource" runat="server" EnableDelete="true" />
            
            <%-- Define the query and associate it with the data filtering controls. --%>
            <asp:QueryExtender TargetControlID="GridDataSource" ID="GridQueryExtender" runat="server">
                <asp:DynamicFilterExpression ControlID="FilterRepeater" />
            </asp:QueryExtender>

            <br />

            <div class="DDBottomHyperLink">
                <asp:DynamicHyperLink ID="InsertHyperLink" runat="server" 
                Action="Insert"><img runat="server" 
                src="~/DynamicData/Content/Images/plus.gif" alt="Insert new item" />
                Insert new item</asp:DynamicHyperLink>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
</form>

</body>
</html>