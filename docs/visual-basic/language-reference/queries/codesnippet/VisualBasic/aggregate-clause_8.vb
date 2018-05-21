  Public Sub AggregateSample()
    Dim customers = GetCustomerList()

    Dim customerOrderTotal =
        From cust In customers
        Aggregate order In cust.Orders
        Into Sum(order.Total), MaxOrder = Max(order.Total),
        MinOrder = Min(order.Total), Avg = Average(order.Total)

    For Each customer In customerOrderTotal
      Console.WriteLine(customer.cust.CompanyName & vbCrLf &
                       vbTab & "Sum = " & customer.Sum & vbCrLf &
                       vbTab & "Min = " & customer.MinOrder & vbCrLf &
                       vbTab & "Max = " & customer.MaxOrder & vbCrLf &
                       vbTab & "Avg = " & customer.Avg.ToString("#.##"))
    Next
  End Sub