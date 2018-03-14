        ' Returns the company name and ID value for each
        ' customer as a collection of a new anonymous type.
        Dim customerList = From cust In customers
                           Select cust.CompanyName, cust.CustomerID