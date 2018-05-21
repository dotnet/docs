    Dim custs = From cust In db.Customers 
                Where cust.Country = "France" And
                    (cust.CompanyName.StartsWith("F") Or
                     cust.CompanyName.StartsWith("V"))
                Order By cust.CompanyName
                Select cust.CompanyName, cust.City

    DataGridView1.DataSource = custs