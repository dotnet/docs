    Protected Sub LinqDataSource_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceInsertEventArgs)
        Dim product As Product
        product = CType(e.NewObject, Product)
        product.DateModified = DateTime.Now
    End Sub