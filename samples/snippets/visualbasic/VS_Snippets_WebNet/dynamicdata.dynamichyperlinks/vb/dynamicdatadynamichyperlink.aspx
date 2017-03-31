<!-- <Snippet1> -->
<%@ Page Language="VB" AutoEventWireup="true" CodeFile="DynamicDataDynamicHyperlink.aspx.vb" Inherits="DocSamples_DynamicDataDynamicHyperlink" %>

<%@ Register src="~/DynamicData/Content/GridViewPager.ascx" tagname="GridViewPager" tagprefix="asp" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Dynamic Hyperlinks</title>
</head>
<body>
    <form id="form1" runat="server">
    
    <asp:DynamicDataManager  ID="DynamicDataManager1" 
        runat="server">
        <DataControls>
            <asp:DataControlReference ControlID="GridView1" />
        </DataControls>
    </asp:DynamicDataManager>
         
    <div>
        <h3>Dynamic Hyperlinks</h3>
        
         <h4>UnBound Control Action Links</h4>
        
        <asp:DynamicHyperLink ID="InsertHyperLink" runat="server" 
            Action="Insert"   
            ContextTypeName="AdventureWorksLTDataContext"
            TableName="ProductModels">Insert new item
        </asp:DynamicHyperLink>
                
        <br />
        
        <asp:DynamicHyperLink ID="DynamicHyperLink2" runat="server" 
            Action="Edit" 
            ContextTypeName="AdventureWorksLTDataContext"
            TableName="ProductModels"  
            ProductModelID="1">Edit item</asp:DynamicHyperLink>
                
        <h4>Data-Bound Control Meta-Table Action Links</h4>
        
        <asp:GridView ID="GridView2" runat="server" 
            AutoGenerateColumns="false"
            CellPadding="6">
            <Columns>
               <asp:TemplateField HeaderText="Table Name" 
                    SortExpression="TableName">
                    <ItemTemplate>                   
                        <asp:DynamicHyperLink 
                            ID="DynamicHyperLink1" runat="server">
                            <%# Eval("DisplayName") %>
                        </asp:DynamicHyperLink>
                    </ItemTemplate>
                </asp:TemplateField>    
            </Columns>
        </asp:GridView>
     
   
        <h4>Data-Bound Control Table Row Action Links</h4>
        
        <asp:GridView ID="GridView1" runat="server" 
            AllowPaging="true" PageSize="5"
            DataSourceID="LinqDataSource1">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:DynamicHyperLink ID="EditHyperLink" 
                            runat="server"  
                            Action="Edit" Text="Edit" />       
                    </ItemTemplate> 
                </asp:TemplateField>    
            </Columns>
        </asp:GridView>
    
    
     
       <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
            ContextTypeName="AdventureWorksLTDataContext"
            TableName="Products"/>
 
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
