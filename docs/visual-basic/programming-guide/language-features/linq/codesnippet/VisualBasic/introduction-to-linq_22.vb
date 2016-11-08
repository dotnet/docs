        ' Returns a list of customers. The query returns
        ' customers until the first customer for whom 
        ' HasOrders returns false. That customer and all 
        ' remaining customers are ignored.
        Dim customersWithOrders = From cust In customers
                                  Order By cust.Orders.Count Descending
                                  Take While HasOrders(cust)