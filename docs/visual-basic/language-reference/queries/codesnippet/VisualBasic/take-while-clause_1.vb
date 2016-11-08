  Public Sub TakeWhileSample()
    Dim customers = GetCustomerList()

    ' Return customers until the first customer with no orders is found.
    Dim customersWithOrders = From cust In customers
                              Order By cust.Orders.Count Descending
                              Take While HasOrders(cust)

    For Each cust In customersWithOrders
      Console.WriteLine(cust.CompanyName & " (" & cust.Orders.Length & ")")
    Next
  End Sub

  Public Function HasOrders(ByVal cust As Customer) As Boolean
    If cust.Orders.Length > 0 Then Return True

    Return False
  End Function