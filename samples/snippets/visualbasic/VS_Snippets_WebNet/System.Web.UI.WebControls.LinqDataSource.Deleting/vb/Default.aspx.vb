
Partial Class _Default
    Inherits System.Web.UI.Page

    '<Snippet1>
    Protected Sub LinqDataSource_Deleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceDeleteEventArgs)
        Dim product As Product
        product = CType(e.OriginalObject, Product)

        If (product.OnSale And Not confirmCheckBox.Checked) Then
            e.Cancel = True
        End If
    End Sub
    '</Snippet1>
End Class
