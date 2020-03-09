Imports System.Data.Objects

Public Class Window2
    Dim advenWorksEntities As AdventureWorksLT2008Entities = New AdventureWorksLT2008Entities

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        Dim customers As ObjectQuery(Of Customer) = advenWorksEntities.Customers
        Dim query = _
            From customer In customers _
            Order By customer.CompanyName _
            Select _
              customer.LastName, _
              customer.FirstName, _
              customer.CompanyName, _
              customer.Title, _
              customer.EmailAddress, _
              customer.Phone, _
              customer.SalesPerson

        dataGrid1.ItemsSource = query.ToList()
    End Sub
End Class
