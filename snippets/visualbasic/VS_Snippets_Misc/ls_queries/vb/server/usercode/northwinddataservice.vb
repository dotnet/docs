
Namespace LS_Queries_VB

    Public Class NorthwindDataService
        '<Snippet1>
        Private Sub TopNSalesOrders_PreprocessQuery _
            (ByVal TopN As System.Nullable(Of Short), _
             ByRef query As System.Linq.IQueryable(Of LS_Queries_VB.Customer))
            query = From myCustomer In query
                   Where myCustomer.Orders.Count > 0
                   Select myCustomer
                   Order By myCustomer.Orders.Count Descending
                   Take (TopN)
        End Sub
        '</Snippet1>
        '<Snippet2>
        Private Sub CustomersWhoBoughtProduct_PreprocessQuery _
            (ByVal ProductID As System.Nullable(Of Short), _
             ByRef query As System.Linq.IQueryable(Of LS_Queries_VB.Customer))
            query = From myCustomers In query
                From myOrders In myCustomers.Orders
                From myOrderDetails In myOrders.Order_Details
                Where myOrderDetails.Product.ProductID = ProductID
                Select Customers
        End Sub
        '</Snippet2>

        Private Sub Order_Details_Inserting(ByVal entity As Order_Detail)
            Good_Customer_Discount2(entity)

        End Sub

        '<Snippet3>
        Private Sub Good_Customer_Discount(ByVal entity As Order_Detail)
            For Each cust As Customer In _
                Me.DataWorkspace.NorthwindData.TopNSalesOrders(10)
                If cust.CustomerID = entity.Order.Customer.CustomerID Then
                    entity.Discount = 0.1
                End If
            Next

        End Sub
        '</Snippet3>
        '<Snippet4>
        Private Sub Good_Customer_Discount2(ByVal entity As Order_Detail)
            Dim query As IDataServiceQueryable(Of Customer)
            query = From mycustomer In Me.DataWorkspace.NorthwindData.TopNSalesOrders(10)
                    Where mycustomer.CustomerID = entity.Order.Customer.CustomerID
                    Select mycustomer

            If Not IsNothing(query.SingleOrDefault) Then
                entity.Discount = 0.01
            End If

        End Sub
        '</Snippet4>

    End Class

End Namespace
