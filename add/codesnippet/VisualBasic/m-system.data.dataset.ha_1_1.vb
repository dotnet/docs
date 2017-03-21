 Private Sub UpdateDataSet(ByVal dataSet As DataSet)
    ' Check for changes with the HasChanges method first.
    If Not dataSet.HasChanges(DataRowState.Modified) Then 
        Exit Sub
    End If

    ' Create temporary DataSet variable and
    ' GetChanges for modified rows only.
    Dim tempDataSet As DataSet = _
        dataSet.GetChanges(DataRowState.Modified)

    ' Check the DataSet for errors.
    If tempDataSet.HasErrors Then
       ' Insert code to resolve errors.
    End If

    ' After fixing errors, update the data source with   
    ' the DataAdapter used to create the DataSet.
    adapter.Update(tempDataSet)
 End Sub