Private Sub Form1_FormClosed(sender as Object, e as FormClosedEventArgs) _ 
     Handles Form1.FormClosed

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"FormClosed Event")

End Sub