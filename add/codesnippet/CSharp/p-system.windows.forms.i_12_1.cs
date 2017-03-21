private void CheckedListBox1_ItemCheck(Object sender, ItemCheckEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Index", e.Index );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "NewValue", e.NewValue );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "CurrentValue", e.CurrentValue );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ItemCheck Event" );
}