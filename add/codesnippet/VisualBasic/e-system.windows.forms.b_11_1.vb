Private Sub BindingsCollection1_CollectionChanging(sender as Object, e as CollectionChangeEventArgs) _ 
     Handles BindingsCollection1.CollectionChanging

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Element", e.Element)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CollectionChanging Event")

End Sub