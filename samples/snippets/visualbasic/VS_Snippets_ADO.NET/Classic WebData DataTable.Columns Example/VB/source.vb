imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub PrintValues(ByVal table As DataTable)
    Dim row As DataRow
    Dim column As DataColumn
    For Each row in table.Rows
       For Each column In table.Columns
          Console.WriteLine(row(column))
       Next
    Next
End Sub
' </Snippet1>

End Class
