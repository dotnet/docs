    Dim customerList = From cust In customers, ord In cust.Orders
                       Select Name = cust.CompanyName,
                              Total = ord.Total, ord.OrderID
                       Where Total > 500
                       Select Name, OrderID