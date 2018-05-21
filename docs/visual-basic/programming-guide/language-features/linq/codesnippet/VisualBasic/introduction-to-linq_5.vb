        Dim queryResults = From cust In customers
                       Where cust.Country = "Canada"
                       Select cust.CompanyName, cust.Country