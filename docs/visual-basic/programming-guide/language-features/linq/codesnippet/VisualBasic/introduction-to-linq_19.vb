        ' Returns a list of customers. The first 10 customers
        ' are ignored and the remaining customers are
        ' returned.
        Dim customerList = From cust In customers
                           Skip 10