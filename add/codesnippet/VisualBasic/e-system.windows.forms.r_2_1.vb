Private Sub RichTextBox1_DragEnter(sender as Object, e as DragEventArgs) _ 
     Handles RichTextBox1.DragEnter

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Data", e.Data)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyState", e.KeyState)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AllowedEffect", e.AllowedEffect)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Effect", e.Effect)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DragEnter Event")

End Sub