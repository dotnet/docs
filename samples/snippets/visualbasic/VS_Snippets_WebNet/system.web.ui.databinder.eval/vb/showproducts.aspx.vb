' <snippet2>
Public Class ShowProducts
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim products As New List(Of Product)()
        products.Add(New Product With {.ProductID = 1, .Name = "Bike", .Price = 150.0})
        products.Add(New Product With {.ProductID = 2, .Name = "Helmet", .Price = 19.99})
        products.Add(New Product With {.ProductID = 3, .Name = "Tire", .Price = 10.0})

        ProductList.DataSource = products
        ProductList.DataBind()
    End Sub

End Class
' </snippet2>