
Namespace LightSwitchApplication

    Public Class NorthwindDataService
        '<Snippet4>
        Private Sub Orders_Validate _
            (entity As Order, results As  _
             Microsoft.LightSwitch.EntitySetValidationResultsBuilder)
            If Not CustomerCreditApproval(entity.Customer) Then
                results.AddEntityError("Customer Credit has not yet been approved")
            End If

        End Sub
        Private Function CustomerCreditApproval(ByVal entity As Customer) As Boolean
            'Some custom code to check the customer’s credit status.
            Return True

        End Function
        '</Snippet4>
        '<Snippet9>
        Private Sub Orders_Inserting(entity As Order)
            For Each detail In entity.Order_Details
                detail.Product.UnitsInStock =
                    detail.Product.UnitsInStock - detail.Quantity
            Next
        End Sub
        '</Snippet9>
        '<Snippet13>
        Private Sub Customers_CanUpdate(ByRef result As Boolean)
            result = Me.Application.User.HasPermission(Permissions.RoleUpdate)
        End Sub
        '</Snippet13>

        Private Sub TopNSalesOrders_PreprocessQuery(TopN As System.Nullable(Of Short), _
                                ByRef query As System.Linq.IQueryable(Of LightSwitchApplication.Customer))
            query = From myCustomer In query
                Where myCustomer.Orders.Count > 0
                Select myCustomer
                Order By myCustomer.Orders.Count Descending
                Take (TopN)

        End Sub
        '<Snippet18>
        Private Sub Order_Details_Inserting(entity As Order_Detail)
            Dim topCustomers = _
                From myCustomers In _
                Me.DataWorkspace.NorthwindData.TopNSalesOrders(10).Execute()
            Select myCustomers

            Dim top_Germany_Customers =
                From customers In topCustomers
                Where customers.Country = "Germany"
                Select customers

            For Each cust In top_Germany_Customers
                If cust.CustomerID = entity.Order.Customer.CustomerID Then
                    entity.Discount = 0.1
                End If
            Next

        End Sub
        '</Snippet18>
    End Class

End Namespace
