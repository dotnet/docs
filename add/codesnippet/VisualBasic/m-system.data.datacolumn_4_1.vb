 Private Sub RemoveColumnAtIndex(thisIndex As Integer)
    ' Get the DataColumnCollection from a DataTable in a DataSet.
    Dim columns As DataColumnCollection = _
        DataSet1.Tables("Orders").Columns

    If columns.CanRemove(columns(thisIndex)) Then 
       columns.RemoveAt(thisIndex)
    End If
 End Sub