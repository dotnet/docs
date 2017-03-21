Private Sub DataGridView1_UserDeletedRow(sender as Object, e as DataGridViewRowEventArgs) _ 
     Handles DataGridView1.UserDeletedRow

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Row", e.Row)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"UserDeletedRow Event")

End Sub