private void PropertyGrid1_SelectedGridItemChanged(Object sender, SelectedGridItemChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "NewSelection", e.NewSelection );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "OldSelection", e.OldSelection );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "SelectedGridItemChanged Event" );
}