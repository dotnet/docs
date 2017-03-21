Private Sub PropertyGrid1_SelectedGridItemChanged(sender as Object, e as SelectedGridItemChangedEventArgs) _ 
     Handles PropertyGrid1.SelectedGridItemChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "NewSelection", e.NewSelection)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OldSelection", e.OldSelection)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"SelectedGridItemChanged Event")

End Sub