Private Sub DataGridView1_RowPrePaint(sender as Object, e as DataGridViewRowPrePaintEventArgs) _ 
     Handles DataGridView1.RowPrePaint

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ClipBounds", e.ClipBounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ErrorText", e.ErrorText)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "InheritedRowStyle", e.InheritedRowStyle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "IsFirstDisplayedRow", e.IsFirstDisplayedRow)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "IsLastVisibleRow", e.IsLastVisibleRow)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "PaintParts", e.PaintParts)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowBounds", e.RowBounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "State", e.State)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowPrePaint Event")

End Sub