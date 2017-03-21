Private Sub BindingManagerBase1_DataError(sender as Object, e as BindingManagerDataErrorEventArgs) _ 
     Handles BindingManagerBase1.DataError

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Exception", e.Exception)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DataError Event")

End Sub