<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Protected Sub LogError(ByVal message As String)
        
    End Sub
    
    '<Snippet1>
    Protected Sub LinqDataSource_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceStatusEventArgs)
        If (IsNothing(e.Exception)) Then
            Dim newProduct As Product
            newProduct = CType(e.Result, Product)
            Literal1.Text = "The new product id is " & newProduct.ProductID
            Literal1.Visible = True
        Else
            LogError(e.Exception.Message)
            Literal1.Text = "We are sorry. There was a problem saving the record. The administrator has been notified."
            Literal1.Visible = True
            e.ExceptionHandled = True
        End If
    End Sub
    '</Snippet1>
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LinqDataSource  
            ContextTypeName="ExampleDataContext" 
            TableName="Products" 
            OnInserted="LinqDataSource_Inserted"
            EnableInsert="true"
            ID="LinqDataSource1" 
            runat="server">
        </asp:LinqDataSource>
        <asp:DetailsView 
            AutoGenerateInsertButton="true"
            DataSourceID="LinqDataSource1"
            ID="DetailsView1" 
            runat="server">
        </asp:DetailsView>
        <asp:Literal 
            Visible="false" 
            ID="Literal1" 
            runat="server">
        </asp:Literal>
    </div>
    </form>
</body>
</html>
