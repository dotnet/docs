private void ListBox1_DrawItem(Object sender, DrawItemEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "BackColor", e.BackColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Bounds", e.Bounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Font", e.Font );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ForeColor", e.ForeColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Index", e.Index );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "State", e.State );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DrawItem Event" );
}