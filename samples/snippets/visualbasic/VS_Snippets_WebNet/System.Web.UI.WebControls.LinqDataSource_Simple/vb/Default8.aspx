<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Example Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <!-- <Snippet8> -->
        <asp:DropDownList AutoPostBack="true" ID="DropDownList1" runat="server">
            <asp:ListItem Value="Category"></asp:ListItem>
            <asp:ListItem Value="Price"></asp:ListItem>
        </asp:DropDownList>
        <asp:LinqDataSource 
            ContextTypeName="ExampleDataContext" 
            TableName="Products" 
            AutoGenerateOrderByClause="true"
            ID="LinqDataSource1" 
            runat="server">
            <OrderByParameters>
              <asp:ControlParameter
                 ControlID="DropDownList1" 
                 Type="String" />
            </OrderByParameters>
        </asp:LinqDataSource>
        <asp:GridView 
            DataSourceID="LinqDataSource1"
            ID="GridView1" 
            runat="server">
        </asp:GridView>
        <!-- </Snippet8> -->
    </div>
    </form>
</body>
</html>
