Private Sub ListControl1_Format(sender as Object, e as ListControlConvertEventArgs) _ 
     Handles ListControl1.Format

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ListItem", e.ListItem)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Value", e.Value)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "DesiredType", e.DesiredType)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Format Event")

End Sub