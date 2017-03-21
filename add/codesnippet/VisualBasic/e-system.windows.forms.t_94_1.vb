Private Sub ToolStripControlHost1_KeyPress(sender as Object, e as KeyPressEventArgs) _ 
     Handles ToolStripControlHost1.KeyPress

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyChar", e.KeyChar)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"KeyPress Event")

End Sub