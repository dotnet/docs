    Dim companies_H = From cust In db.Customers 
                      Where cust.Orders.Count > 0 And
                            cust.CompanyName.StartsWith("H") 
                      Select cust.CustomerID, cust.CompanyName, 
                             OrderCount = cust.Orders.Count, 
                             cust.Country

    Dim customers_USA = From cust In db.Customers 
                        Where cust.Orders.Count > 15 And
                              cust.Country = "USA" 
                        Select cust.CustomerID, cust.CompanyName, 
                               OrderCount = cust.Orders.Count, 
                               cust.Country