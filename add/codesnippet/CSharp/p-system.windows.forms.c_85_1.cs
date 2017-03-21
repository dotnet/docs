private void ListView1_ColumnWidthChanged(Object sender, ColumnWidthChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnWidthChanged Event" );
}