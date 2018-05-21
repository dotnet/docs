        Dim londonCusts3 = From cust In customers
                           Where cust.City = "London"
                           Order By cust.Name Ascending
                           Select cust.Name