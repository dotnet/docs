        ' Returns a list of customers. The query ignores all
        ' customers until the first customer for whom
        ' IsSubscriber returns false. That customer and all
        ' remaining customers are returned.
        Dim customerList = From cust In customers
                           Skip While IsSubscriber(cust)