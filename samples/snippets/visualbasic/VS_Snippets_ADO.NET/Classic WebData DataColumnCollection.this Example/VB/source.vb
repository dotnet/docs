Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    
' <Snippet1>
Private Sub PrintColumnNamesByIndex(table As DataTable)
    ' Get the DataColumnCollection from a DataTable in a DataSet.
    Dim columns As DataColumnCollection = table.Columns

    ' Print each column's name using the Index.
    Dim i As Integer
    For i = 0 To columns.Count - 1
        Console.WriteLine(columns(i))
    Next i
End Sub
' </Snippet1>
End Class
