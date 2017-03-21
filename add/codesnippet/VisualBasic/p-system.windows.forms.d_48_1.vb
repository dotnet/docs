Private Sub DataGridView1_CellParsing(sender as Object, e as DataGridViewCellParsingEventArgs) _ 
     Handles DataGridView1.CellParsing

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "InheritedCellStyle", e.InheritedCellStyle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ParsingApplied", e.ParsingApplied)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Value", e.Value)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "DesiredType", e.DesiredType)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellParsing Event")

End Sub