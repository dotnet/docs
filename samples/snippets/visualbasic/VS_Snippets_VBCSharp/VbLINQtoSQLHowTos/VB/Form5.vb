Public Class Form5

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '<Snippet11>
        Dim db As New northwindDataContext

        Dim customers_London = From cust In db.Customers
                               Where cust.City = "London"
                               Select cust.CustomerID, cust.CompanyName,
                                      OrderCount = cust.Orders.Count,
                                      cust.City, cust.Country

        DataGridView1.DataSource = customers_London
        '</Snippet11>

        '<Snippet12>
        Dim companies_H = From cust In db.Customers
                          Where cust.Orders.Count > 0 And
                                cust.CompanyName.StartsWith("H")
                          Select cust.CustomerID, cust.CompanyName,
                                 OrderCount = cust.Orders.Count,
                                 cust.Country

        Dim customers_USA = From cust In db.Customers
                            Where cust.Orders.Count > 15 And
                                  cust.Country = "USA"
                            Select cust.CustomerID, cust.CompanyName,
                                   OrderCount = cust.Orders.Count,
                                   cust.Country
        '</Snippet12>
    End Sub
End Class
