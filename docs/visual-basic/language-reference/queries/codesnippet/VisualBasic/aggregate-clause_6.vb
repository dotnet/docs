    Dim customerMinOrder = From cust In customers
                           Aggregate order In cust.Orders
                           Into MinOrder = Min(order.Total)