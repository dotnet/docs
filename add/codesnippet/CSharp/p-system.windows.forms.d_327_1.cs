private void DataGridView1_RowPostPaint(Object sender, DataGridViewRowPostPaintEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ClipBounds", e.ClipBounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ErrorText", e.ErrorText );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "InheritedRowStyle", e.InheritedRowStyle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "IsFirstDisplayedRow", e.IsFirstDisplayedRow );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "IsLastVisibleRow", e.IsLastVisibleRow );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowBounds", e.RowBounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "State", e.State );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowPostPaint Event" );
}