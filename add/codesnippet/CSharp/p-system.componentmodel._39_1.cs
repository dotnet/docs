private void PictureBox1_LoadProgressChanged(Object sender, ProgressChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ProgressPercentage", e.ProgressPercentage );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "UserState", e.UserState );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "LoadProgressChanged Event" );
}