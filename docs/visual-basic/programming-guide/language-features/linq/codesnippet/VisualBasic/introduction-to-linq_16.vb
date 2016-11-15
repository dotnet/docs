        ' Returns the customer company name and largest 
        ' order amount for each customer.
        Dim customerMax = From cust In customers
                          Aggregate order In cust.Orders
                          Into MaxOrder = Max(order.Amount)
                          Select cust.CompanyName, MaxOrder