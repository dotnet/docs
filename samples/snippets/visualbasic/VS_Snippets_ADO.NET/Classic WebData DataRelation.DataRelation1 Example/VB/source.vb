imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet

' <Snippet1>

 Private Sub CreateRelation()
    ' Code to get the DataSet not shown here.
    ' Get the DataColumn objects from two DataTable 
    ' objects in a DataSet.
    Dim parentColumn As DataColumn = DataSet1.Tables( _
        "Customers").Columns("CustID")
    Dim childColumn As DataColumn = _
        DataSet1.Tables("Orders").Columns("CustID")

    ' Create DataRelation.
    Dim bConstraints As Boolean = True
    Dim customerOrdersRelation As DataRelation = _
        New DataRelation("CustomersOrders", _
        parentColumn, childColumn, bConstraints)

    ' Add the relation to the DataSet.
    DataSet1.Relations.Add(customerOrdersRelation)
End Sub
' </Snippet1>

End Class
