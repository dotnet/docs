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