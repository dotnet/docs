    Dim customerNames = From cust In customers 
                        Select cust.CompanyName

    Dim customerInfo As IEnumerable(Of Customer) =
      From cust In customers
      Select New Customer With {.CompanyName = cust.CompanyName,
                                 .Address = cust.Address,
                                 .City = cust.City,
                                 .Region = cust.Region,
                                 .Country = cust.Country}