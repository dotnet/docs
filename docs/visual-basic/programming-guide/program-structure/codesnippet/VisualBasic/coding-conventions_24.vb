    Dim newyorkCustomers = From cust In customers 
                           Where cust.City = "New York" 
                           Select cust.LastName, cust.CompanyName