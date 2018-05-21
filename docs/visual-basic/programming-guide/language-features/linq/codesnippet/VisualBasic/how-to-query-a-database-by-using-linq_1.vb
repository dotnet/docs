    Dim db As New northwindDataContext

    Dim londonCusts = From cust In db.Customers
                      Where cust.City = "London"
                      Select cust

    DataGridView1.DataSource = londonCusts