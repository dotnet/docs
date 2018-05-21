    Dim db As New northwindDataContext

    Dim minimumOrders = Aggregate cust In db.Customers
                        Where cust.City = "London"
                        Into Min(cust.Orders.Count)

    MsgBox("Minimum Orders from a London Customer: " & minimumOrders)

    Dim maximumOrdersByCountry = From cust In db.Customers
                                 Group By cust.Country
                                   Into MaxOrders = Max(cust.Orders.Count)

    DataGridView1.DataSource = maximumOrdersByCountry