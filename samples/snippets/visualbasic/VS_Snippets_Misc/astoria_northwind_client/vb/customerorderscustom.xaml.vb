'<snippetWpfDataBindingCustom>
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
Imports System.Collections.Specialized

Partial Public Class CustomerOrdersCustom
    Inherits Window
    Private context As NorthwindEntities
    Private trackedCustomers As DataServiceCollection(Of Customer)
    Private Const customerCountry As String = "Germany"
    Private Const svcUri As String = "http://localhost:12345/Northwind.svc/"
    Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Try
            ' Initialize the context for the data service.
            context = New NorthwindEntities(New Uri(svcUri))

            '<snippetMasterDetailBinding>
            ' Create a LINQ query that returns customers with related orders.
            Dim customerQuery = From cust In context.Customers.Expand("Orders") _
                                Where cust.Country = customerCountry _
                                Select cust

            ' Create a new collection for binding based on the LINQ query.
            trackedCustomers = New DataServiceCollection(Of Customer)(customerQuery, _
                    TrackingMode.AutoChangeTracking, "Customers", _
                    AddressOf OnMyPropertyChanged, AddressOf OnMyCollectionChanged)

            ' Bind the root StackPanel element to the collection
            ' related object binding paths are defined in the XAML.
            Me.LayoutRoot.DataContext = trackedCustomers
            '</snippetMasterDetailBinding>
        Catch ex As DataServiceQueryException
            MessageBox.Show("The query could not be completed:\n" + ex.ToString())
        Catch ex As InvalidOperationException
            MessageBox.Show("The following error occurred:\n" + ex.ToString())
        End Try
    End Sub
    '<snippetCustomersOrdersDeleteRelated>
    ' Method that is called when the CollectionChanged event is handled.
    Private Function OnMyCollectionChanged( _
        ByVal entityCollectionChangedinfo As EntityCollectionChangedParams) As Boolean
        If entityCollectionChangedinfo.Action = _
            NotifyCollectionChangedAction.Remove Then

            ' Delete the related items when an order is deleted.
            If entityCollectionChangedinfo.TargetEntity.GetType() Is GetType(Order) Then

                ' Get the context and object from the supplied parameter.
                Dim context = entityCollectionChangedinfo.Context
                Dim deletedOrder As Order = _
                CType(entityCollectionChangedinfo.TargetEntity, Order)

                If deletedOrder.Order_Details.Count = 0 Then
                    ' Load the related OrderDetails.
                    context.LoadProperty(deletedOrder, "Order_Details")
                End If

                ' Delete the order and its related items
                For Each item As Order_Detail In deletedOrder.Order_Details
                    context.DeleteObject(item)
                Next

                ' Delete the order and then return false since the object is already deleted.
                context.DeleteObject(deletedOrder)

                Return True
            Else
                Return False
            End If
        Else
            ' Use the default behavior.
            Return False
        End If
    End Function
    '</snippetCustomersOrdersDeleteRelated>
    ' Method that is called when the PropertyChanged event is handled.
    Private Function OnMyPropertyChanged( _
    ByVal entityChangedInfo As EntityChangedParams) As Boolean
        ' Validate a changed order to ensure that changes are not made 
        ' after the order ships.
        If entityChangedInfo.Entity.GetType() Is GetType(Order) AndAlso _
            (CType(entityChangedInfo.Entity, Order).ShippedDate < DateTime.Today) Then
            Throw New ApplicationException(String.Format( _
                "The order {0} cannot be changed because it shipped on {1}.", _
                CType(entityChangedInfo.Entity, Order).OrderID, _
                CType(entityChangedInfo.Entity, Order).ShippedDate))
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub deleteButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Get the Orders binding collection.
        If customerIDComboBox.SelectedItem IsNot Nothing Then
            Dim trackedOrders As DataServiceCollection(Of Order) = _
                (CType(customerIDComboBox.SelectedItem, Customer)).Orders

            ' Remove the currently selected order.
            trackedOrders.Remove(CType(ordersDataGrid.SelectedItem, Order))
        End If
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
'</snippetWpfDataBindingCustom>
