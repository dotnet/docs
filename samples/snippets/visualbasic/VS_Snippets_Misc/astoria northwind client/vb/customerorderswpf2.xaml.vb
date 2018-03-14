Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
'<snippetCustomersOrdersImportsWpf>
Imports System.Data.Services.Client
Imports NorthwindClient.Northwind
'</snippetCustomersOrdersImportsWpf>

Partial Public Class CustomerOrdersWpf2
    Inherits Window
    '<snippetCustomersOrdersDefinitionWpf>
    Private context As NorthwindEntities
    Private customersViewSource As CollectionViewSource
    Private trackedCustomers As DataServiceCollection(Of Customer)
    Private Const customerCountry As String = "Germany"
    Private Const svcUri As String = "http://localhost:12345/Northwind.svc/"
    '</snippetCustomersOrdersDefinitionWpf>

    Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        '<snippetCustomersOrdersDataBindingWpf>
        ' Initialize the context for the data service.
        context = New NorthwindEntities(New Uri(svcUri))

        ' Create a LINQ query that returns customers with related orders.
        Dim customerQuery = From cust In context.Customers.Expand("Orders") _
                                 Where cust.Country = customerCountry _
                                 Select cust

        ' Create a new collection for binding based on the LINQ query.
        trackedCustomers = New DataServiceCollection(Of Customer)(customerQuery)

            try
                ' Get the customersViewSource resource and set the binding to the collection.
            customersViewSource = _
                CType(Me.FindResource("customersViewSource"), CollectionViewSource)
            customersViewSource.Source = trackedCustomers
            customersViewSource.View.MoveCurrentToFirst()
        Catch ex As DataServiceQueryException
            MessageBox.Show("The query could not be completed:\n" + ex.ToString())
        Catch ex As InvalidOperationException
            MessageBox.Show("The following error occurred:\n" + ex.ToString())
        End Try
        '</snippetCustomersOrdersDataBindingWpf>
    End Sub
End Class
