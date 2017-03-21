Private Sub RichTextBox1_ContentsResized(sender as Object, e as ContentsResizedEventArgs) _ 
     Handles RichTextBox1.ContentsResized

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "NewRectangle", e.NewRectangle)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ContentsResized Event")

End Sub