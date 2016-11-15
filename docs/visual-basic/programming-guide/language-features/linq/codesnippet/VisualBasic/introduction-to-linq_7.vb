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