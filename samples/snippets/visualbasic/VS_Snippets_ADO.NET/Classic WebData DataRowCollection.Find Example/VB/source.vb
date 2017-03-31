imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
 Private Sub FindInPrimaryKeyColumn(ByVal table As DataTable, _
    ByVal pkValue As Long)
    ' Find the number pkValue in the primary key 
    ' column of the table.
    Dim foundRow As DataRow = table.Rows.Find(pkValue)

    ' Print the value of column 1 of the found row.
    If Not (foundRow Is Nothing) Then
        Console.WriteLine(foundRow(1).ToString())
    End If
End Sub
' </Snippet1>

End Class
