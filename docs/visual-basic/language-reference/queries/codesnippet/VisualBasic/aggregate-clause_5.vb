    Dim customerMaxOrder = Aggregate order In orders
                           Into MaxOrder = Max(order.Total)