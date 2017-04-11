imports System
imports System.Data
imports System.Diagnostics
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet

' <Snippet1>
Private Sub GetChildColumns()
    ' Get the DataRelation of a DataSet.
    Dim relation As DataRelation = _
        DataSet1.Relations("CustomerOrders")

    ' Get the child columns.
    Dim childArray() As DataColumn = relation.ChildColumns

    ' Print the ColumnName of each column.
    Dim i As Integer
    For i = 0 to childArray.GetUpperBound(0)
       Debug.Write(childArray(i).ColumnName)
    Next i
End Sub
' </Snippet1>

End Class
