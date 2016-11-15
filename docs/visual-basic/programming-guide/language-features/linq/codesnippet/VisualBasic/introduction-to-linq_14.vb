        ' Returns a combined collection of customers and
        ' customer orders.
        Dim customerList = From cust In customers
                           Group Join ord In orders On
                             cust.CustomerID Equals ord.CustomerID
                           Into CustomerOrders = Group,
                                TotalOfOrders = Sum(ord.Amount)
                           Select cust.CompanyName, cust.CustomerID,
                                  CustomerOrders, TotalOfOrders