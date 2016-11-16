        ' Returns the sum of all order amounts.
        Dim orderTotal = Aggregate order In orders
                         Into Sum(order.Amount)