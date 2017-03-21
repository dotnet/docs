Private Sub PictureBox1_LoadCompleted(sender as Object, e as AsyncCompletedEventArgs) _ 
     Handles PictureBox1.LoadCompleted

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancelled", e.Cancelled)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Error", e.Error)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "UserState", e.UserState)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"LoadCompleted Event")

End Sub