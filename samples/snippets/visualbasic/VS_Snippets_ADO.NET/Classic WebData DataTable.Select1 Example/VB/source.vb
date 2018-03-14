imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub GetRowsByFilter()
    
    Dim table As DataTable = DataSet1.Tables("Orders")

    ' Presuming the DataTable has a column named Date.
    Dim expression As String
    expression = "Date > #1/1/00#"
    Dim foundRows() As DataRow

    ' Use the Select method to find all rows matching the filter.
    foundRows = table.Select(expression)

    Dim i As Integer
    ' Print column 0 of each returned row.
    For i = 0 to foundRows.GetUpperBound(0)
       Console.WriteLine(foundRows(i)(0))
    Next i
End Sub
' </Snippet1>

End Class
