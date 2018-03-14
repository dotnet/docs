'Imports System
'Imports System.Collections.Generic
'Imports System.Linq
'Imports System.Text
'Imports System.Windows
'Imports System.Windows.Controls
'Imports System.Windows.Data
'Imports System.Windows.Documents
'Imports System.Windows.Input
'Imports System.Windows.Media
'Imports System.Windows.Media.Imaging
'Imports System.Windows.Navigation
'Imports System.Windows.Shapes
'Imports NorthwindClient.Northwind
'Imports System.Data.Services.Client
'Imports System.Windows.Threading

'Imports System.Windows.Input
'Imports System.Windows.Media
'Imports System.Windows.Media.Imaging
'Imports System.Windows.Navigation
'Imports System.Windows.Data
'Imports System.Windows.Documents
'Imports System.Windows.ShapesImports System
'Imports System.Linq
'Imports System.Windows.Controls
'Imports System.Text
'Imports System.Collections.Generic
'<snippetWpfDataBindingCode>
Imports System
Imports System.Linq
Imports System.Windows
Imports System.Data.Services.Client
Imports NorthwindClient.Northwind

'/ <summary>
'/ Interaction logic for SalesOrders.xaml
'/ </summary>
Partial Public Class SalesOrders
    Inherits Window
    Private context As NorthwindEntities
    Private customerId As String = "ALFKI"
    Private svcUri As Uri = New Uri("http://localhost:12345/Northwind.svc")

    Private Sub OrdersForm_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Try
            ' Instantiate the DataServiceContext.
            context = New NorthwindEntities(svcUri)

            ' Define a query that returns Orders and 
            ' Order_Details for a specific customer.
            Dim ordersQuery = From o In context.Orders.Expand("Order_Details") _
                                   Where o.Customer.CustomerID = customerId _
                                   Select o

            ' Create an DataServiceCollection<T> based on 
            ' execution of the query for Orders.
            Dim customerOrders As DataServiceCollection(Of Order) = _
                New DataServiceCollection(Of Order)(ordersQuery)

                '<snippetWpfDataBindingCodeShort>
            ' Make the DataServiceCollection<T> the binding source for the Grid.
                Me.orderItemsGrid.DataContext = customerOrders
                '</snippetWpfDataBindingCodeShort>
        Catch ex As DataServiceQueryException
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub buttonClose_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.Close()
    End Sub
    Private Sub buttonSaveChanges_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Try
            ' Save changes made to objects tracked by the context.
            context.SaveChanges()
        Catch ex As DataServiceRequestException
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Sub New()
        InitializeComponent()
    End Sub
End Class
'</snippetWpfDataBindingCode>
