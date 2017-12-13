    Dim customerList2 = From cust In customers 
                        Join ord In orders 
                          On cust.CustomerID Equals ord.CustomerID 
                        Select cust, ord
