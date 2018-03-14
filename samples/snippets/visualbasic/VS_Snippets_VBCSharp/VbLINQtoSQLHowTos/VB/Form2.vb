Public Class Form2

  Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '<Snippet3>
    Dim db As New northwindDataContext

    Dim londonCusts = From cust In db.Customers
                      Where cust.City = "London"
                      Select cust

    DataGridView1.DataSource = londonCusts
    '</Snippet3>

    '<Snippet4>
    Dim londonCustOrders = From cust In db.Customers,
                                ord In cust.Orders
                           Where cust.City = "London"
                           Order By ord.OrderID
                           Select cust.City, ord.OrderID, ord.OrderDate

    DataGridView1.DataSource = londonCustOrders
    '</Snippet4>

    '<Snippet5>
    Dim custs = From cust In db.Customers 
                Where cust.Country = "France" And
                    (cust.CompanyName.StartsWith("F") Or
                     cust.CompanyName.StartsWith("V"))
                Order By cust.CompanyName
                Select cust.CompanyName, cust.City

    DataGridView1.DataSource = custs
    '</Snippet5>
  End Sub
End Class