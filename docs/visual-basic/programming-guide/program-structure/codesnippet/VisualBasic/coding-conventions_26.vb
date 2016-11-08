    Dim customerList2 = From cust In customers 
                        Join order In orders 
                          On cust.CustomerID Equals order.CustomerID 
                        Select cust, order