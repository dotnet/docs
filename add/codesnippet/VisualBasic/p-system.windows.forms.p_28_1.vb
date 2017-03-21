Private Sub PropertyGrid1_PropertyTabChanged(sender as Object, e as PropertyTabChangedEventArgs) _ 
     Handles PropertyGrid1.PropertyTabChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "OldTab", e.OldTab)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "NewTab", e.NewTab)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"PropertyTabChanged Event")

End Sub