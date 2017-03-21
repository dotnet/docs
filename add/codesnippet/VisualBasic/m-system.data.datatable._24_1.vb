Private Sub ComputeBySalesSalesID(ByVal dataSet As DataSet)
    ' Presumes a DataTable named "Orders" that has a column named "Total."
    Dim table As DataTable
    table = dataSet.Tables("Orders")

    ' Declare an object variable.
    Dim sumObject As Object
    sumObject = table.Compute("Sum(Total)", "EmpID = 5")
 End Sub