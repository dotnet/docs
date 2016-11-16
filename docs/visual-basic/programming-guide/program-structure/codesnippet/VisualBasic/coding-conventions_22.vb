    Dim customerOrders2 = From cust In customers 
                          Join ord In orders
                            On cust.CustomerID Equals ord.CustomerID 
                          Select CustomerName = cust.Name, 
                                 OrderID = ord.ID