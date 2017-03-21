Private Sub Control1_QueryContinueDrag(sender as Object, e as QueryContinueDragEventArgs) _ 
     Handles Control1.QueryContinueDrag

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyState", e.KeyState)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EscapePressed", e.EscapePressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"QueryContinueDrag Event")

End Sub