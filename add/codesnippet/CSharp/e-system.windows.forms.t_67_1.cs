private void TableLayoutPanel1_CellPaint(Object sender, TableLayoutCellPaintEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "CellBounds", e.CellBounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Row", e.Row );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Column", e.Column );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ClipRectangle", e.ClipRectangle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellPaint Event" );
}