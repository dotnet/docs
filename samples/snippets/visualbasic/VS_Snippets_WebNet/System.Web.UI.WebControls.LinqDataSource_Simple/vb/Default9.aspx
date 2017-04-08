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
        
        <!-- <Snippet9> -->
        <asp:LinqDataSource 
            ContextTypeName="ExampleDataContext" 
            TableName="Products" 
            EnableUpdate="true"
            EnableInsert="true"
            ID="LinqDataSource1" 
            runat="server">
            <UpdateParameters>
              <asp:Parameter Name="Category" DefaultValue="Miscellaneous" />
            </UpdateParameters>
            <InsertParameters>
              <asp:Parameter Name="Category" DefaultValue="Miscellaneous" />
            </InsertParameters>
        </asp:LinqDataSource>
        <asp:GridView 
            DataSourceID="LinqDataSource1"
            ID="GridView1" 
            runat="server">
        </asp:GridView>
        <!-- </Snippet9> -->
    </div>
    </form>
</body>
</html>
