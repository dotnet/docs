    Dim newyorkCustomers2 = From cust In customers 
                            Where cust.City = "New York" 
                            Order By cust.LastName