Private Sub RemoveTables()
    ' Presuming a DataGrid is displaying more than one table, 
    ' get its DataSet.
    Dim thisDataSet As DataSet = CType(DataGrid1.DataSource, DataSet)
    Do While thisDataSet.Tables.Count > 0
       Dim table As DataTable = thisDataSet.Tables(0)
       If thisDataSet.Tables.CanRemove(table) Then
          thisDataSet.Tables.Remove(table)
       End If
    Loop
End Sub