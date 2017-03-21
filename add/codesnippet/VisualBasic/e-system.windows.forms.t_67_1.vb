Private Sub TableLayoutPanel1_CellPaint(sender as Object, e as TableLayoutCellPaintEventArgs) _ 
     Handles TableLayoutPanel1.CellPaint

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "CellBounds", e.CellBounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Row", e.Row)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClipRectangle", e.ClipRectangle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellPaint Event")

End Sub