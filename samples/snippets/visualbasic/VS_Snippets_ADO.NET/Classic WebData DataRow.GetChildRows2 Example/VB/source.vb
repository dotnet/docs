imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet

' <Snippet1>
Private Sub GetChildRowsFromDataRelation(table As DataTable)
    Dim relation As DataRelation
    Dim arrRows() As DataRow
    Dim row As DataRow
    Dim i As Integer
    Dim column As DataColumn 
 
    For Each relation In table.ChildRelations
      For Each row In table.Rows
          arrRows = row.GetChildRows(relation)
          ' Print values of rows.
          For i = 0 To arrRows.GetUpperBound(0)
             For Each column in table.Columns
                Console.WriteLine(arrRows(i)(column))
             Next column
          Next i
       Next row
    Next relation
 End Sub
' </Snippet1>

End Class
