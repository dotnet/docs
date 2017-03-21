 Private Sub CheckForErrors(dataSet As DataSet)
     ' Invoke GetChanges on the DataSet to create a reduced set.
     Dim thisDataSet As DataSet = dataSet.GetChanges()

     ' Check each table's HasErrors property.
     Dim table As DataTable
     For Each table In thisDataSet.Tables
         ' If HasErrors is true, reconcile errors.
         If table.HasErrors Then
             ' Insert code to reconcile errors.
         End If
     Next table
 End Sub