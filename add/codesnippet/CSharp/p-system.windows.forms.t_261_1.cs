private void TabControl1_Selected(Object sender, TabControlEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "TabPage", e.TabPage );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "TabPageIndex", e.TabPageIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Selected Event" );
}