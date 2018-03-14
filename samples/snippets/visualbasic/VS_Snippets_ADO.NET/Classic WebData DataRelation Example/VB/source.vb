imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet

' <Snippet1>
Private Sub CreateRelation()
    ' Get the DataColumn objects from two DataTable objects 
    ' in a DataSet. Code to get the DataSet not shown here.
    Dim parentColumn As DataColumn = _
        DataSet1.Tables("Customers").Columns("CustID")
    Dim childColumn As DataColumn = DataSet1.Tables( _
        "Orders").Columns("CustID")

    ' Create DataRelation.
    Dim relCustOrder As DataRelation
    relCustOrder = New DataRelation( _
        "CustomersOrders", parentColumn, childColumn)

    ' Add the relation to the DataSet.
    DataSet1.Relations.Add(relCustOrder)
End Sub
' </Snippet1>

End Class
