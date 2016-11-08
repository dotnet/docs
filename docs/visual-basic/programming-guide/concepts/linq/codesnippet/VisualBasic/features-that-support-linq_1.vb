        Dim londonCusts = From cust In customers
                          Where cust.City = "London"
                          Order By cust.Name Ascending
                          Select cust.Name, cust.Phone