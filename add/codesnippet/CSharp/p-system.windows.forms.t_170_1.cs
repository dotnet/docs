private void ToolStripDropDown1_Closed(Object sender, ToolStripDropDownClosedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Closed Event" );
}