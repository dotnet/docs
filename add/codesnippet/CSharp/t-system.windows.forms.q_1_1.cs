private void DataGridView1_CancelRowEdit(Object sender, QuestionEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Response", e.Response );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CancelRowEdit Event" );
}