'<snippetBindPagedData>
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
Imports System.Data.Services.Client
Imports NorthwindClient.Northwind

Partial Public Class CustomerOrdersWpf3
    Inherits Window

    Private context As NorthwindEntities
    Private trackedCustomers As DataServiceCollection(Of Customer)
    Private Const customerCountry As String = "Germany"
    Private Const svcUri As String = "http://localhost:12345/Northwind.svc/"

    Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Try
            ' Initialize the context for the data service.
            context = New NorthwindEntities(New Uri(svcUri))

            ' Create a LINQ query that returns customers with related orders.
            Dim customerQuery = From cust In context.Customers _
                                Where cust.Country = customerCountry _
                                Select cust

            '<snippetBindPagedDataSpecific>
            ' Create a new collection for binding based on the LINQ query.
            trackedCustomers = New DataServiceCollection(Of Customer)(customerQuery)

            ' Load all pages of the response at once.
            While trackedCustomers.Continuation IsNot Nothing
                trackedCustomers.Load( _
                        context.Execute(Of Customer)(trackedCustomers.Continuation.NextLinkUri))
            End While
            '</snippetBindPagedDataSpecific>

            ' Bind the root StackPanel element to the collection
            ' related object binding paths are defined in the XAML.
            Me.LayoutRoot.DataContext = trackedCustomers
        Catch ex As DataServiceQueryException
            MessageBox.Show("The query could not be completed:\n" + ex.ToString())
        Catch ex As InvalidOperationException
            MessageBox.Show("The following error occurred:\n" + ex.ToString())
        End Try
    End Sub
    Private Sub customerIDComboBox_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
        Dim selectedCustomer As Customer = _
            CType(Me.customerIDComboBox.SelectedItem, Customer)
        Try
            If selectedCustomer.Orders.Count = 0 Then
                ' Load the first page of related orders for the selected customer.
                context.LoadProperty(selectedCustomer, "Orders")
            End If

            ' Load all remaining pages.
            While selectedCustomer.Orders.Continuation IsNot Nothing
                selectedCustomer.Orders.Load( _
                        context.Execute(Of Order)(selectedCustomer.Orders.Continuation.NextLinkUri))
            End While
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub saveChangesButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Try
            ' Save changes to the data service.
            context.SaveChanges()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
End Class
'</snippetBindPagedData>
