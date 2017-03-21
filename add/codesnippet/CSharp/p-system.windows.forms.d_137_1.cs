private void DataGridView1_CellPainting(Object sender, DataGridViewCellPaintingEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "AdvancedBorderStyle", e.AdvancedBorderStyle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "CellBounds", e.CellBounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "CellStyle", e.CellStyle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ClipBounds", e.ClipBounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ErrorText", e.ErrorText );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "FormattedValue", e.FormattedValue );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "PaintParts", e.PaintParts );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "State", e.State );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Value", e.Value );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellPainting Event" );
}