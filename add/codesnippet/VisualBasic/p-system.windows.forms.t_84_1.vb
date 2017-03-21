Private Sub ToolStripDropDown1_Closing(sender as Object, e as ToolStripDropDownClosingEventArgs) _ 
     Handles ToolStripDropDown1.Closing

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Closing Event")

End Sub