    Dim customerList = From cust In customers
                       Group Join ord In orders On
                       cust.CustomerID Equals ord.CustomerID
                       Into CustomerOrders = Group,
                            OrderTotal = Sum(ord.Total)
                       Select cust.CompanyName, cust.CustomerID,
                              CustomerOrders, OrderTotal

    For Each customer In customerList
      Console.WriteLine(customer.CompanyName &
                        " (" & customer.OrderTotal & ")")

      For Each order In customer.CustomerOrders
        Console.WriteLine(vbTab & order.OrderID & ": " & order.Total)
      Next
    Next