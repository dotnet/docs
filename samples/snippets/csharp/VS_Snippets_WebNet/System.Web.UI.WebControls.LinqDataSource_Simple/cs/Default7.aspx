<%@ Page Language="C#" %>

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
        
        <!-- <Snippet7> -->
        <asp:DropDownList AutoPostBack="true" ID="DropDownList1" runat="server">
            <asp:ListItem Value="Sports"></asp:ListItem>
            <asp:ListItem Value="Garden"></asp:ListItem>
            <asp:ListItem Value="Auto"></asp:ListItem>
        </asp:DropDownList>
        <asp:LinqDataSource 
            ContextTypeName="ExampleDataContext" 
            TableName="Products" 
            AutoGenerateWhereClause="true"
            ID="LinqDataSource1" 
            runat="server">
            <WhereParameters>
                <asp:ControlParameter 
                    Name="Category" 
                    ControlID="DropDownList1" 
                    Type="String" />
            </WhereParameters>
        </asp:LinqDataSource>
        <asp:GridView 
            DataSourceID="LinqDataSource1"
            ID="GridView1" 
            runat="server">
        </asp:GridView>
        <!-- </Snippet7> -->
    </div>
    </form>
</body>
</html>
