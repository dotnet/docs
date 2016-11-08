        ' Outside a query.
        Dim product = New With {.Name = "paperclips", .Price = 1.29}

        ' Inside a query.
        ' You can use the existing member names of the selected fields, as was
        ' shown previously in the Query Expressions section of this topic.
        Dim londonCusts1 = From cust In customers
                           Where cust.City = "London"
                           Select cust.Name, cust.Phone

        ' Or you can specify new names for the selected fields.
        Dim londonCusts2 = From cust In customers
                           Where cust.City = "London"
                           Select CustomerName = cust.Name,
                           CustomerPhone = cust.Phone