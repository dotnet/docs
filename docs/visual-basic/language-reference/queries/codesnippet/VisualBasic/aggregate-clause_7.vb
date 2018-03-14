    Dim customerTotals = From cust In customers
                         Aggregate order In cust.Orders
                         Into Sum(order.Total)