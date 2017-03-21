Private Sub TabControl1_Deselecting(sender as Object, e as TabControlCancelEventArgs) _ 
     Handles TabControl1.Deselecting

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "TabPage", e.TabPage)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "TabPageIndex", e.TabPageIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Deselecting Event")

End Sub