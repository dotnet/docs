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
        
        <!-- <Snippet6> -->
        <asp:DropDownList AutoPostBack="true" ID="DropDownList1" runat="server">
            <asp:ListItem Value="0"></asp:ListItem>
            <asp:ListItem Value="25"></asp:ListItem>
            <asp:ListItem Value="100"></asp:ListItem>
            <asp:ListItem Value="400"></asp:ListItem>
        </asp:DropDownList>
        <asp:LinqDataSource 
            ContextTypeName="ExampleDataContext" 
            TableName="Products" 
            Where="Price>@UserPrice"
            ID="LinqDataSource1" 
            runat="server">
            <WhereParameters>
                <asp:ControlParameter 
                    Name="UserPrice" 
                    DefaultValue="0" 
                    ControlID="DropDownList1" 
                    Type="Int32" />
            </WhereParameters>
        </asp:LinqDataSource>
        <asp:GridView 
            DataSourceID="LinqDataSource1"
            ID="GridView1" 
            runat="server">
        </asp:GridView>
        <!-- </Snippet6> -->
    </div>
    </form>
</body>
</html>
