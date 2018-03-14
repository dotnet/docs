
Partial Class _Default
    Inherits System.Web.UI.Page

    '<Snippet1>
    Protected Sub LinqDataSource_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceUpdateEventArgs)
        Dim originalProduct As Product
        Dim newProduct As Product

        originalProduct = CType(e.OriginalObject, Product)
        newProduct = CType(e.NewObject, Product)

        If (originalProduct.Category <> newProduct.Category) Then
            newProduct.CategoryChanged = True
        End If
    End Sub
    '</Snippet1>
End Class
