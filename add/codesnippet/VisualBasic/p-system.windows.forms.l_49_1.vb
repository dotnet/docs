Private Sub Control1_Layout(sender as Object, e as LayoutEventArgs) _ 
     Handles Control1.Layout

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "AffectedComponent", e.AffectedComponent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AffectedControl", e.AffectedControl)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AffectedProperty", e.AffectedProperty)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Layout Event")

End Sub