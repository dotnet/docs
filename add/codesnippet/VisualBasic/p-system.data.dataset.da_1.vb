Private Sub CreateDataSet() 
    Dim dataSet As DataSet
    dataSet = New DataSet("SuppliersProducts")
    Console.WriteLine(dataSet.DataSetName)
End Sub