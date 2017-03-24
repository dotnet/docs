Public Class Form4

  Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '<Snippet10>
    Dim db As New northwindDataContext

    Dim q = From cust In db.Customers
            Where cust.Orders.Count > 0
            Select cust.CustomerID, cust.CompanyName,
                   OrderCount = cust.Orders.Count, cust.Country
            Order By OrderCount Descending, CompanyName

    DataGridView1.DataSource = q
    '</Snippet10>
  End Sub
End Class