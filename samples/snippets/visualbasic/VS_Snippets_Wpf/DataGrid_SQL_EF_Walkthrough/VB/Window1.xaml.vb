
Imports System.Data.Objects

Class Window1
    Dim dataEntities As AdventureWorksLT2008Entities = New AdventureWorksLT2008Entities

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        Dim products As ObjectQuery(Of Product) = dataEntities.Products

        Dim query = _
            From product In products _
            Where product.Color = "Red" _
            Order By product.ListPrice _
            Select product.Name, product.Color, CategoryName = product.ProductCategory.Name, product.ListPrice

        DataGrid1.ItemsSource = query.ToList()
    End Sub
End Class
