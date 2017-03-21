Private Sub ToolStripDropDown1_Closed(sender as Object, e as ToolStripDropDownClosedEventArgs) _ 
     Handles ToolStripDropDown1.Closed

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Closed Event")

End Sub