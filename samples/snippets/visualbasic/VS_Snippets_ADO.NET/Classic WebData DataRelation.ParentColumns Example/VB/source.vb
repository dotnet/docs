imports System
imports System.Data
imports System.Diagnostics
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet

' <Snippet1>
Private Sub GetChildCols()
    ' Get the DataRelation of a DataSet.
    Dim relation As DataRelation = _
        DataSet1.Relations("CustomerOrders")

    ' Get the parent columns.
    Dim parentColumns() As DataColumn = relation.ParentColumns

    ' Print the ColumnName of each column.
    Dim i As Integer
    For i = 0 to parentColumns.GetUpperBound(0)
       Console.Writeline(parentColumns(i).ColumnName.ToString())
    Next i
End Sub
' </Snippet1>

End Class
