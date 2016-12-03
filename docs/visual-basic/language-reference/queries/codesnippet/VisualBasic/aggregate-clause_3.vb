    Dim customerOrderAverage = Aggregate order In orders
                               Into Average(order.Total)