Public Class Class2

    Public Sub RunExamples()
        Debug.WriteLine(vbCrLf & " Example1")
        Example1()

        Debug.WriteLine(vbCrLf & " Example2")
        Example2()

        Debug.WriteLine(vbCrLf & " Example3")
        Example3()

        Debug.WriteLine(vbCrLf & " Example4")
        Example4()

        Debug.WriteLine(vbCrLf & " Example5")
        Example5()

        Debug.WriteLine(vbCrLf & " Example6")
        Example6()
    End Sub


    Private Sub Example1()
        '<Snippet1>
        ' Obtain a list of customers.
        Dim customers As List(Of Customer) = GetCustomers()

        ' Return customers that are grouped based on country.
        Dim countries = From cust In customers
                        Order By cust.Country, cust.City
                        Group By CountryName = cust.Country
                        Into CustomersInCountry = Group, Count()
                        Order By CountryName

        ' Output the results.
        For Each country In countries
            Debug.WriteLine(country.CountryName & " count=" & country.Count)

            For Each customer In country.CustomersInCountry
                Debug.WriteLine("   " & customer.CompanyName & "  " & customer.City)
            Next
        Next

        ' Output:
        '   Canada count=2
        '      Contoso, Ltd  Halifax
        '      Fabrikam, Inc.  Vancouver
        '   United States count=1
        '      Margie's Travel  Redmond
        '</Snippet1>
    End Sub


    Private Sub Example2()
        '<Snippet2>
        Dim customers = GetCustomers()

        Dim queryResults = From cust In customers

        For Each result In queryResults
            Debug.WriteLine(result.CompanyName & "  " & result.Country)
        Next

        ' Output:
        '   Contoso, Ltd  Canada
        '   Margie's Travel  United States
        '   Fabrikam, Inc.  Canada
        '</Snippet2>
    End Sub

    Private Sub Example3()
        Dim customers = GetCustomers()

        '<Snippet3>
        Dim queryResults = From cust In customers
                           Where cust.Country = "Canada"
        '</Snippet3>
    End Sub

    Private Sub Example4()
        Dim customers = GetCustomers()

        '<Snippet4>
        Dim queryResults = From cust In customers
                       Where cust.Country = "Canada"
                       Select cust.CompanyName, cust.Country
        '</Snippet4>
    End Sub

    Private Sub Example5()
        '<Snippet5>
        Dim customers = GetCustomers()
        Dim orders = GetOrders()

        Dim queryResults = From cust In customers, ord In orders
                   Where cust.CustomerID = ord.CustomerID
                   Select cust, ord

        For Each result In queryResults
            Debug.WriteLine(result.ord.Amount & "  " & result.ord.CustomerID & "  " & result.cust.CompanyName)
        Next

        ' Output:
        '   200.00  1  Contoso, Ltd
        '   300.00  1  Contoso, Ltd
        '   100.00  2  Margie's Travel
        '   600.00  3  Fabrikam, Inc.
        '   800.00  3  Fabrikam, Inc.
        '</Snippet5>
    End Sub


    Private Sub Example6()
        '<Snippet6>
        Dim customers = GetCustomers()
        Dim orders = GetOrders()

        Dim queryResults = From cust In customers
                           Group Join ord In orders On
                             cust.CustomerID Equals ord.CustomerID
                             Into CustomerOrders = Group,
                                  OrderTotal = Sum(ord.Amount)
                           Select cust.CompanyName, cust.CustomerID,
                                  CustomerOrders, OrderTotal

        For Each result In queryResults
            Debug.WriteLine(result.OrderTotal & "  " & result.CustomerID & "  " & result.CompanyName)
            For Each ordResult In result.CustomerOrders
                Debug.WriteLine("   " & ordResult.Amount)
            Next
        Next

        ' Output:
        '   500.00  1  Contoso, Ltd
        '      200.00
        '      300.00
        '   100.00  2  Margie's Travel
        '      100.00
        '   1400.00  3  Fabrikam, Inc.
        '      600.00
        '      800.00
        '</Snippet6>
    End Sub


    '<Snippet31>
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
    '</Snippet31>

End Class
