Private Sub ToolStripControlHost1_Validating(sender as Object, e as CancelEventArgs) _ 
     Handles ToolStripControlHost1.Validating

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Validating Event")

End Sub