    Dim londonCustOrders = From cust In db.Customers,
                                ord In cust.Orders
                           Where cust.City = "London"
                           Order By ord.OrderID
                           Select cust.City, ord.OrderID, ord.OrderDate

    DataGridView1.DataSource = londonCustOrders