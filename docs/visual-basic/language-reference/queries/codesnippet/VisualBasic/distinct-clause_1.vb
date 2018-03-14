    Dim customerOrders = From cust In customers, ord In orders
                         Where cust.CustomerID = ord.CustomerID
                         Select cust.CompanyName, ord.OrderDate
                         Distinct