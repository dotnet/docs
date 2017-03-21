private void DataGridView1_AutoSizeColumnsModeChanged(Object sender, DataGridViewAutoSizeColumnsModeEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "PreviousModes", e.PreviousModes );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "AutoSizeColumnsModeChanged Event" );
}