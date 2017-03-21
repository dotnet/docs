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