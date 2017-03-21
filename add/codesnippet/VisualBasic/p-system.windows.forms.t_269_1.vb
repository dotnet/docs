Private Sub TabControl1_Selected(sender as Object, e as TabControlEventArgs) _ 
     Handles TabControl1.Selected

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "TabPage", e.TabPage)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "TabPageIndex", e.TabPageIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Selected Event")

End Sub