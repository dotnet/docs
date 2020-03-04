<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<script runat="server">
    Dim IsOnlineSale As Boolean = True
    Dim OnlineDiscount As Decimal = 0.1
    
    '<Snippet5>
    Protected Sub LinqDataSource_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs)
        If (IsOnlineSale) Then
            e.SelectParameters.Add("Discount", OnlineDiscount)
        Else
            e.SelectParameters.Add("Discount", 0)
        End If
    End Sub
    '</Snippet5>
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!-- <Snippet6> -->
        <asp:LinqDataSource 
            ContextTypeName="ExampleDataContext" 
            TableName="Products"            
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
