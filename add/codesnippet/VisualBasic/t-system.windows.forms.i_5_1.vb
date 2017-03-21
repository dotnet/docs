Private Sub Control1_Invalidated(sender as Object, e as InvalidateEventArgs) _ 
     Handles Control1.Invalidated

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "InvalidRect", e.InvalidRect)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Invalidated Event")

End Sub