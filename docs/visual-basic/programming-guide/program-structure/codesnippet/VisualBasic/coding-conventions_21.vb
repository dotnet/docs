    Dim customerOrders = From customer In customers 
                         Join order In orders 
                           On customer.CustomerID Equals order.CustomerID 
                         Select Customer = customer, Order = order