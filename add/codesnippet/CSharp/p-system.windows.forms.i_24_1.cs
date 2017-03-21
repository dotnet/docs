private void CurrencyManager1_ItemChanged(Object sender, ItemChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Index", e.Index );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ItemChanged Event" );
}