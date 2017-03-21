Private Sub PictureBox1_LoadProgressChanged(sender as Object, e as ProgressChangedEventArgs) _ 
     Handles PictureBox1.LoadProgressChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ProgressPercentage", e.ProgressPercentage)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "UserState", e.UserState)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"LoadProgressChanged Event")

End Sub