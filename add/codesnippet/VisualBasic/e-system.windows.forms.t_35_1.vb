Private Sub ToolStripDropDown1_HelpRequested(sender as Object, e as HelpEventArgs) _ 
     Handles ToolStripDropDown1.HelpRequested

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePos", e.MousePos)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"HelpRequested Event")

End Sub