Public Class Form1

Private Sub Order_DetailsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Order_DetailsBindingNavigatorSaveItem.Click
Me.Validate()
Me.Order_DetailsBindingSource.EndEdit()
Me.Order_DetailsTableAdapter1.Update(Me.NorthwindDataSet1.Order_Details)

End Sub

Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'TODO: This line of code loads data into the 'NorthwindDataSet1.Order_Details' table. You can move, or remove it, as needed.
Me.Order_DetailsTableAdapter1.Fill(Me.NorthwindDataSet1.Order_Details)

End Sub
End Class
