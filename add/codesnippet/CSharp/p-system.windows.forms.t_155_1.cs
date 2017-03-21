private void TabControl1_Selecting(Object sender, TabControlCancelEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "TabPage", e.TabPage );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "TabPageIndex", e.TabPageIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Selecting Event" );
}