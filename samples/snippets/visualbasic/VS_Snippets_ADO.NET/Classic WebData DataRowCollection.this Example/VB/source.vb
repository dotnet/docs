Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
' <Snippet1>
Private Sub PrintRows(table As DataTable)
     ' Print the first column for every row using the index.
     Dim i As Integer
     For i = 0 To table.Rows.Count - 1
         Console.WriteLine(table.Rows(i)(0))
     Next i
End Sub
' </Snippet1>
End Class
