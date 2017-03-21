private void ListView1_ColumnWidthChanging(Object sender, ColumnWidthChangingEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "NewWidth", e.NewWidth );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnWidthChanging Event" );
}