Private Sub ScrollableControl1_Scroll(sender as Object, e as ScrollEventArgs) _ 
     Handles ScrollableControl1.Scroll

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ScrollOrientation", e.ScrollOrientation)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Type", e.Type)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "NewValue", e.NewValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OldValue", e.OldValue)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Scroll Event")

End Sub