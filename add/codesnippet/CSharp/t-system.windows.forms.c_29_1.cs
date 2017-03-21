private void ListView1_ColumnReordered(Object sender, ColumnReorderedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "OldDisplayIndex", e.OldDisplayIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "NewDisplayIndex", e.NewDisplayIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Header", e.Header );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnReordered Event" );
}