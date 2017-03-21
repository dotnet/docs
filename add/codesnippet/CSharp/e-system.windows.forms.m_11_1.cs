private void MenuItem1_MeasureItem(Object sender, MeasureItemEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Index", e.Index );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ItemHeight", e.ItemHeight );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ItemWidth", e.ItemWidth );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MeasureItem Event" );
}