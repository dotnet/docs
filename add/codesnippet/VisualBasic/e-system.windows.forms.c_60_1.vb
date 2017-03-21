Private Sub CheckedListBox1_ItemCheck(sender as Object, e as ItemCheckEventArgs) _ 
     Handles CheckedListBox1.ItemCheck

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Index", e.Index)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "NewValue", e.NewValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CurrentValue", e.CurrentValue)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ItemCheck Event")

End Sub