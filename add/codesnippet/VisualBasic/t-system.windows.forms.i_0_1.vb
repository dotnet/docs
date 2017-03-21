Private Sub ListView1_ItemChecked(sender as Object, e as ItemCheckedEventArgs) _ 
     Handles ListView1.ItemChecked

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ItemChecked Event")

End Sub