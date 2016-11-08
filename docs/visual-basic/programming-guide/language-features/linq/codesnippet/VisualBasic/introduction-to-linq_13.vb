        ' Returns a list of orders grouped by the order date
        ' and sorted in ascending order by the order date.
        Dim orderList = From order In orders
                        Order By order.OrderDate
                        Group By OrderDate = order.OrderDate
                        Into OrdersByDate = Group