imports System
imports System.Xml
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
 Private Sub PrintChildRelationRows()
    ' Declare variable to hold the row values.
    Dim rowValues As String
    Dim dataSet As DataSet

    ' Get the DataSet of a DataGrid that is displaying data 
    ' of at least two tables.
    Dim table As DataTable = CType(DataGrid1.DataSource, DataTable)

    ' Navigate using the Relations.
    Dim relation As DataRelation
    Dim row As DataRow
    Dim column As DataColumn

    ' Print the names of each column in each table.
    For Each relation In dataSet.Relations
       For Each column in relation.ChildTable.Columns
           rowValues &= column.ColumnName & " "
       Next
     Next

     ' Display results.
     Console.WriteLine(rowValues)
    End Sub
' </Snippet1>

End Class
