Private Sub ListView1_AfterLabelEdit(sender as Object, e as LabelEditEventArgs) _ 
     Handles ListView1.AfterLabelEdit

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Label", e.Label)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CancelEdit", e.CancelEdit)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"AfterLabelEdit Event")

End Sub