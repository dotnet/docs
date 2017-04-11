imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet

' <Snippet1>
 Private Sub GetTable(ByVal row As DataRow)
    ' Get the DataTable of a DataRow
    Dim table As DataTable = row.Table

    ' Print the DataType of each column in the table.
    Dim column As DataColumn
    For Each column in table.Columns
       Console.WriteLine(column.DataType)
    Next
 End Sub
' </Snippet1>

End Class
