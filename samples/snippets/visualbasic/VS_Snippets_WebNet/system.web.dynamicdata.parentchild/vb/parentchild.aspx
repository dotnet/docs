<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:DynamicDataManager ID="DynamicDataManager1" runat="server" >
    <DataControls>
        <asp:DataControlReference ControlID="GridView1" />
        <asp:DataControlReference ControlID="GridView2" />
    </DataControls>
    </asp:DynamicDataManager>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="AdventureWorksLTDataContext" EntityTypeName="" 
        TableName="ProductCategories">
    </asp:LinqDataSource>

    <h2>Parent Table: ProductCategories</h2>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="True" DataKeyNames="ProductCategoryID"  
        SelectedIndex="4"
        DataSourceID="LinqDataSource1">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    
    
    <asp:LinqDataSource ID="LinqDataSource2" runat="server" 
        ContextTypeName="AdventureWorksLTDataContext" EntityTypeName="" 
        TableName="Products">
    </asp:LinqDataSource>

    <h2>Child Table: Products</h2>
    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
        AutoGenerateColumns="True" DataKeyNames="ProductID" PageSize="5"
        DataSourceID="LinqDataSource2">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
           
        </Columns>
    </asp:GridView>
    
    <asp:QueryExtender ID="QueryExtenderID" 
        TargetControlID="LinqDataSource2" runat="server" >
             <asp:ControlFilterExpression
                ControlID="GridView1"
                Column="ProductCategory" />
    </asp:QueryExtender>

    
    </form>
</body>
</html>
<!-- </Snippet1> -->