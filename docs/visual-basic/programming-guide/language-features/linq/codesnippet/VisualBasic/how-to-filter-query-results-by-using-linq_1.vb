    Dim db As New northwindDataContext

    Dim customers_London = From cust In db.Customers 
                           Where cust.City = "London" 
                           Select cust.CustomerID, cust.CompanyName, 
                                  OrderCount = cust.Orders.Count, 
                                  cust.City, cust.Country

    DataGridView1.DataSource = customers_London