Private Sub DataGridView1_CancelRowEdit(sender as Object, e as QuestionEventArgs) _ 
     Handles DataGridView1.CancelRowEdit

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Response", e.Response)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CancelRowEdit Event")

End Sub