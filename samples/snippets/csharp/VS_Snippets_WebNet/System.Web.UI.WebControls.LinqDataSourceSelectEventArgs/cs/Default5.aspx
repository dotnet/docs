<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<script runat="server">
    bool IsOnlineSale = true;
    decimal OnlineDiscount = .1M;
    
    // <Snippet5> 
    protected void LinqDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        if (IsOnlineSale)
        {
            e.SelectParameters.Add("Discount", OnlineDiscount);
        }
        else
        {
            e.SelectParameters.Add("Discount", 0);
        }
    }
    // </Snippet5> 
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Example Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!-- <Snippet6> -->
        <asp:LinqDataSource 
            ContextTypeName="ExampleDataContext" 
            TableName="Products" 
            AutoGenerateWhereClause="true"
            Select="new(Name, Price * (1 - @Discount) As OnlinePrice)"
            OnSelecting="LinqDataSource_Selecting" 
            ID="LinqDataSource1" 
            runat="server">
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
