    Dim db As New northwindDataContext

    Dim customerList =
      From cust In db.Customers
      Where cust.CompanyName.StartsWith("L")
      Select New CustomerInfo With {.CompanyName = cust.CompanyName,
                                    .ContactName = cust.ContactName}

    DataGridView1.DataSource = customerList