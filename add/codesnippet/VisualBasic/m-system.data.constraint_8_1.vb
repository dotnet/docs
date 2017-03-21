 Public Shared Sub ClearConstraints(dataSet As DataSet) 
    Dim table As DataTable
    For Each table In dataSet.Tables
      table.Constraints.Clear()
    Next
 End Sub