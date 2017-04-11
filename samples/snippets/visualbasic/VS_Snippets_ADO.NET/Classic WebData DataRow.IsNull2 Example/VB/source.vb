imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet

' <Snippet1>
Private Sub PrintRows(dataSet As DataSet)
    Dim table As DataTable
    Dim column As DataColumn
    Dim row As DataRow
    For Each table In dataSet.Tables
       For Each row In table.Rows
          For Each column In table.Columns
             If Not row.IsNull(column) Then 
                Console.WriteLine(row(column).ToString())
             End If
          Next column
       Next row
     Next table
End Sub
' </Snippet1>

End Class
