Private Sub Form1_FormClosing(sender as Object, e as FormClosingEventArgs) _ 
     Handles Form1.FormClosing

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"FormClosing Event")

End Sub