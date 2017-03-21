Private Sub CurrencyManager1_ItemChanged(sender as Object, e as ItemChangedEventArgs) _ 
     Handles CurrencyManager1.ItemChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Index", e.Index)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ItemChanged Event")

End Sub