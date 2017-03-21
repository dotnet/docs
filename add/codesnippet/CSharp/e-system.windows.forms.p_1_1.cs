private void PictureBox1_LoadCompleted(Object sender, AsyncCompletedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Cancelled", e.Cancelled );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Error", e.Error );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "UserState", e.UserState );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "LoadCompleted Event" );
}