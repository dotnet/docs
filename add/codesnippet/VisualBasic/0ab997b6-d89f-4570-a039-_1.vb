Private Sub DataGridView1_CellStyleContentChanged(sender as Object, e as DataGridViewCellStyleContentChangedEventArgs) _ 
     Handles DataGridView1.CellStyleContentChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "CellStyle", e.CellStyle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CellStyleScope", e.CellStyleScope)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellStyleContentChanged Event")

End Sub