    Dim customerOrderAfter1996 = From cust In customers
                                 Aggregate order In cust.Orders
                                 Into Count(order.OrderDate > #12/31/1996#)