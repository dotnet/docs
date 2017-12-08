    Dim customerOrders = From customer In customers 
                         Join ord In orders 
                           On customer.CustomerID Equals ord.CustomerID 
                         Select Customer = customer, Order = ord
