Public Class Form8

    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '<Snippet15>
        Dim db As New northwindDataContext

        Dim customerList =
          From cust In db.Customers
          Where cust.CompanyName.StartsWith("L")
          Select New CustomerInfo With {.CompanyName = cust.CompanyName,
                                        .ContactName = cust.ContactName}

        DataGridView1.DataSource = customerList
        '</Snippet15>
    End Sub
End Class

'<Snippet16>
Public Class CustomerInfo
    Public Property CompanyName As String
    Public Property ContactName As String
End Class
'</Snippet16>
