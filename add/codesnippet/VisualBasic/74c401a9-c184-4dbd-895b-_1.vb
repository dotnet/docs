Private Sub CreateRelation()
    ' Code to get the DataSet not shown here.
    ' Get the DataColumn objects from two DataTable 
    ' objects in a DataSet.
    Dim parentColumns() As DataColumn
    Dim childColumns() As DataColumn
    parentColumns(0) = DataSet1.Tables( _
        "Customers").Columns("CustID")
    parentColumns(1) = DataSet1.Tables( _
        "Customers").Columns("OrdID")
 
    childColumns(0) = DataSet1.Tables( _
        "Orders").Columns("CustID")
    childColumns(1) = DataSet1.Tables( _
        "Orders").Columns("OrdID")

    ' Create DataRelation.
    Dim CustOrderRel As DataRelation = New DataRelation( _
        "CustomersOrders", parentColumns, childColumns)

    ' Add the relation to the DataSet.
    DataSet1.Relations.Add(CustOrderRel)
End Sub