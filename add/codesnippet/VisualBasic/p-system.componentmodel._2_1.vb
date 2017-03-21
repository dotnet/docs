Private Sub BindingSource1_ListChanged(sender as Object, e as ListChangedEventArgs) _ 
     Handles BindingSource1.ListChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ListChangedType", e.ListChangedType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "NewIndex", e.NewIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OldIndex", e.OldIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "PropertyDescriptor", e.PropertyDescriptor)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ListChanged Event")

End Sub