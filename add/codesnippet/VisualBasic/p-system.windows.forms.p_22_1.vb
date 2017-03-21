Private Sub PropertyGrid1_PropertyValueChanged(sender as Object, e as PropertyValueChangedEventArgs) _ 
     Handles PropertyGrid1.PropertyValueChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ChangedItem", e.ChangedItem)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OldValue", e.OldValue)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"PropertyValueChanged Event")

End Sub