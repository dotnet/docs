    ' Return a list of customers.
    Private Function GetCustomers() As List(Of Customer)
        Return New List(Of Customer) From
            {
                New Customer With {.CustomerID = 1, .CompanyName = "Contoso, Ltd", .City = "Halifax", .Country = "Canada"},
                New Customer With {.CustomerID = 2, .CompanyName = "Margie's Travel", .City = "Redmond", .Country = "United States"},
                New Customer With {.CustomerID = 3, .CompanyName = "Fabrikam, Inc.", .City = "Vancouver", .Country = "Canada"}
            }
    End Function

    ' Return a list of orders.
    Private Function GetOrders() As List(Of Order)
        Return New List(Of Order) From
            {
                New Order With {.CustomerID = 1, .Amount = "200.00"},
                New Order With {.CustomerID = 3, .Amount = "600.00"},
                New Order With {.CustomerID = 1, .Amount = "300.00"},
                New Order With {.CustomerID = 2, .Amount = "100.00"},
                New Order With {.CustomerID = 3, .Amount = "800.00"}
            }
    End Function

    ' Customer Class.
    Private Class Customer
        Public Property CustomerID As Integer
        Public Property CompanyName As String
        Public Property City As String
        Public Property Country As String
    End Class

    ' Order Class.
    Private Class Order
        Public Property CustomerID As Integer
        Public Property Amount As Decimal
    End Class