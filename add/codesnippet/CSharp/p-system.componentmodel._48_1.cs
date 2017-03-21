private void AutoCompleteStringCollection1_CollectionChanged(Object sender, CollectionChangeEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Element", e.Element );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CollectionChanged Event" );
}