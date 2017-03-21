private void ListView1_DrawColumnHeader(Object sender, DrawListViewColumnHeaderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "DrawDefault", e.DrawDefault );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Bounds", e.Bounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Header", e.Header );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "State", e.State );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ForeColor", e.ForeColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "BackColor", e.BackColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Font", e.Font );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DrawColumnHeader Event" );
}