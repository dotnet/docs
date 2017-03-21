private void Control1_Invalidated(Object sender, InvalidateEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "InvalidRect", e.InvalidRect );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Invalidated Event" );
}