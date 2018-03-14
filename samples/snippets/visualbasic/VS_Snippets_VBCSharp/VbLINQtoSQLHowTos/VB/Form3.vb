Public Class Form3

  Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '<Snippet1>
    Dim db As New northwindDataContext

    ' Display the results of the Sales_by_Year stored procedure.
    DataGridView1.DataSource = 
        db.Sales_by_Year(#1/1/1996#, #1/1/2007#).ToList()
    '</Snippet1>

    '<Snippet2>
    ' Display the results of the Ten_Most_Expensive_Products
    ' stored procedure.

    DataGridView1.DataSource = 
        db.Ten_Most_Expensive_Products.ToList()
    '</Snippet2>

  End Sub
End Class
