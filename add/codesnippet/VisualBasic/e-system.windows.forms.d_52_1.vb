   Private Sub CallEventLoader()
      AddHandler Load, AddressOf DataGridTableStyle_RowHeaderWidth_Load
   End Sub 'CallEventLoader
   
   
   Public Sub AttachRowHeaderWidthChanged()
      AddHandler myDataGridTableStyle.RowHeaderWidthChanged, AddressOf MyDelegateRowHeaderChanged
   End Sub 'AttachRowHeaderWidthChanged
   
    Private Sub MyDelegateRowHeaderChanged(ByVal sender As Object, ByVal e As EventArgs)
        MessageBox.Show("Row header width is changed")
    End Sub 'MyDelegateRowHeaderChanged
   
   
   Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
      myDataGridTableStyle.RowHeaderWidth = 30
   End Sub 'button1_Click
   
   
   Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
      MessageBox.Show("Row header width is: " & myDataGridTableStyle.RowHeaderWidth)
   End Sub 'button2_Click