Imports System
Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.VisualBasic

Public Class Sample

' <Snippet1>
 Private Sub GetTables(dataSet As DataSet)
    ' Get Each DataTable in the DataTableCollection and 
    ' print each row value.
    Dim table As DataTable
    Dim row As DataRow
    Dim column As DataColumn
    For Each table In dataSet.Tables
       For Each row In table.Rows
          For Each column in table.Columns
             If Not (row(column) Is Nothing) Then
                Console.WriteLine(row(column))
             End If
          Next
       Next
    Next
 End Sub

 Private Sub CreateTable(dataSet As DataSet)
    Dim newTable As DataTable = new DataTable("table")
    newTable.Columns.Add("ID", Type.GetType("System.Int32"))
    newTable.Columns.Add("Name", Type.GetType("System.String"))
    dataSet.Tables.Add(newTable)
 End Sub
' </Snippet1>
End Class