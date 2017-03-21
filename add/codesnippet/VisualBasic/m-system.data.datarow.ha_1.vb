Private Sub CheckVersionBeforeAccept()
    ' Assuming the DataGrid is bound to a DataTable.
    Dim table As DataTable = CType(DataGrid1.DataSource, DataTable)
    Dim row As DataRow = table.Rows(DataGrid1.CurrentCell.RowNumber)
    row.BeginEdit
    row(1) = Edit1.Text
    If row.HasVersion(datarowversion.Proposed) Then
       If row(1, DataRowVersion.Current) Is _
            row(1, DataRowversion.Proposed) Then
          Console.WriteLine("The original and the proposed are the same")
          row.CancelEdit
          Exit Sub
       Else
          row.AcceptChanges
       End If
    Else
       Console.WriteLine("No new values proposed")
    End If
End Sub