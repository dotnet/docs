    Dim allOrders = From cust In GetCustomerList()
                    From ord In cust.Orders
                    Select ord