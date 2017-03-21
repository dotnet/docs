 Private Sub TryContainsDataMember(myDataSet As DataSet)
    Dim trueorfalse As Boolean
    trueorfalse = Me.BindingContext.Contains(myDataSet, "Suppliers")
    Console.WriteLine(trueorfalse.ToString())
 End Sub
