Private Sub TestAndRemove(ByVal colToRemove As DataColumn)
    ' Get the DataColumnCollection from a DataTable in a DataSet.
    Dim columns As DataColumnCollection = _
        DataSet1.Tables("Orders").Columns
 
    If columns.Contains(colToRemove.ColumnName) Then
       columns.Remove(colToRemove)
    End If
End Sub