        Dim londonCusts5 = From cust In customers
                           Where cust.City = "London"
                           Order By cust.Name Ascending
                           Select New NamePhone With {.Name = cust.Name,
                                                      .Phone = cust.Phone}