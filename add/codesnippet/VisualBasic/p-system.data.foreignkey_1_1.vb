 Private Sub GetRelatedTables()
    Dim relation As DataRelation
    Dim dataTable As DataTable
    
    ' Get the DataRelation from a DataSet.
    For Each relation In DataSet1.Relations
       If relation.GetType.ToString = _
        "System.Data.ForeignKeyConstraint" Then
          dataTable = relation.ParentTable
          Console.WriteLine(dataTable.TableName, _
            dataTable.Columns.Count, dataTable.Rows.Count)
       End If
    Next
 End Sub