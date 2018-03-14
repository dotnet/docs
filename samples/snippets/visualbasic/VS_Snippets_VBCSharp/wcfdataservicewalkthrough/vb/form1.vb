Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' <Snippet3>
        Dim proxy As New ServiceReference1.northwindModel.northwindEntities _
 (New Uri("http://localhost:53161/NorthwindCustomers.svc/"))
        Me.CustomersBindingSource.DataSource = proxy.Customers
        ' </Snippet3>
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' <Snippet4>
        Dim proxy As New ServiceReference1.northwindModel.northwindEntities _
 (New Uri("http://localhost:53161/NorthwindCustomers.svc"))
        Dim city As String = TextBox1.Text

        If city <> "" Then
            Me.CustomersBindingSource.DataSource = From c In _
         proxy.Customers Where c.City = city
        End If
        ' </Snippet4>
    End Sub
End Class
