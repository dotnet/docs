Private Sub DataGridViewColumnCollection1_CollectionChanged(sender as Object, e as CollectionChangeEventArgs) _ 
     Handles DataGridViewColumnCollection1.CollectionChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Element", e.Element)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CollectionChanged Event")

End Sub