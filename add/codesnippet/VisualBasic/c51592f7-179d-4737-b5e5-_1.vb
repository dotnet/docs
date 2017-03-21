
 Private Sub CreateRelation()
    ' Code to get the DataSet not shown here.
    ' Get the DataColumn objects from two DataTable 
    ' objects in a DataSet.
    Dim parentCols() As DataColumn = New DataColumn() _
        {DataSet1.Tables("Customers").Columns("CustID"), _
        DataSet1.Tables("Customers").Columns("OrdID")}
    Dim childCols() As DataColumn = New DataColumn() _
        {DataSet1.Tables("Orders").Columns("CustID"), _
        DataSet1.Tables("Orders").Columns("OrdID")}

    ' Create DataRelation.
    Dim CustOrderRel As DataRelation = New DataRelation( _
        "CustomersOrders", parentCols, childCols)

    ' Add the relation to the DataSet.
    DataSet1.Relations.Add(CustOrderRel)
End Sub