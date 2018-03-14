    Dim customerList2 = From cust In customers
                        Aggregate order In cust.Orders
                        Into AnyOrderOver500 = Any(order.Total >= 500)