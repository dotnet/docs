Private Sub RichTextBox1_LinkClicked(sender as Object, e as LinkClickedEventArgs) _ 
     Handles RichTextBox1.LinkClicked

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "LinkText", e.LinkText)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"LinkClicked Event")

End Sub