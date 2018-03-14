'<snippetUsing>
Imports System.Data.Services.Client
Imports NorthwindClient.Northwind
'</snippetUsing>

Class Window1
    '<snippetQueryCode>
    Private context As NorthwindEntities
    Private customerId As String = "ALFKI"

    ' Replace the host server and port number with the values 
    ' for the test server hosting your Northwind data service instance.
    Private svcUri As Uri = New Uri("http://localhost:12345/Northwind.svc")

    Private Sub Window1_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Try
            ' Instantiate the DataServiceContext.
            context = New NorthwindEntities(svcUri)

            ' Define a LINQ query that returns Orders and 
            ' Order_Details for a specific customer.
            Dim ordersQuery = From o In context.Orders.Expand("Order_Details") _
                                  Where o.Customer.CustomerID = customerId _
                                  Select o

            ' Create an DataServiceCollection(Of T) based on
            ' execution of the LINQ query for Orders.
            Dim customerOrders As DataServiceCollection(Of Order) = New  _
                DataServiceCollection(Of Order)(ordersQuery)

            '<snippetWpfDataBindingCodeShort>
            ' Make the DataServiceCollection<T> the binding source for the Grid.
            Me.orderItemsGrid.DataContext = customerOrders
            '</snippetWpfDataBindingCodeShort>
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    '</snippetQueryCode>
    '<snippetSaveChanges>
    Private Sub buttonSaveChanges_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Try
            ' Save changes made to objects tracked by the context.
            context.SaveChanges()
        Catch ex As DataServiceRequestException
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub buttonClose_Click(ByVal sender As Object, ByVal a As RoutedEventArgs)
        Me.Close()
    End Sub
    '</snippetSaveChanges> 
End Class
