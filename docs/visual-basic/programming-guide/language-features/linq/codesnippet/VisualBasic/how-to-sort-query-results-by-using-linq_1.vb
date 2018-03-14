    Dim db As New northwindDataContext

    Dim q = From cust In db.Customers
            Where cust.Orders.Count > 0
            Select cust.CustomerID, cust.CompanyName,
                   OrderCount = cust.Orders.Count, cust.Country
            Order By OrderCount Descending, CompanyName

    DataGridView1.DataSource = q