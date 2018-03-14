Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
' <Snippet1>
Private Sub DemonstrateMergeTableAddSchema()
    ' Create a DataSet with one table, two columns, 
    'and ten rows.
    Dim dataSet As New DataSet("dataSet")
    Dim table As New DataTable("Items")

    ' Add tables to the DataSet
    dataSet.Tables.Add(table)

    ' Create and add two columns to the DataTable
    Dim idColumn As New DataColumn("id", _
        Type.GetType("System.Int32"), "")
    idColumn.AutoIncrement = True
    Dim itemColumn As New DataColumn("Item", _
        Type.GetType("System.Int32"), "")
    table.Columns.Add(idColumn)
    table.Columns.Add(itemColumn)

    ' DataColumn array to set primary key.
    Dim keyCol(1) As DataColumn

    ' Set primary key column.
    keyCol(0) = idColumn
    table.PrimaryKey = keyCol

    ' Add RowChanged event handler for the table.
    AddHandler table.RowChanged, AddressOf Row_Changed

    ' Add ten rows.
    Dim i As Integer
    Dim row As DataRow

    For i = 0 To 9
        row = table.NewRow()
        row("Item") = i
        table.Rows.Add(row)
    Next i

    ' Accept changes.
    dataSet.AcceptChanges()
    PrintValues(dataSet, "Original values")

    ' Create a second DataTable identical to the first
    ' with one extra column using the Clone method.
    Dim cloneTable As New DataTable
    cloneTable = table.Clone()

    ' Add column.
    cloneTable.Columns.Add("extra", _
        Type.GetType("System.String"))

    ' Add two rows. Note that the id column can't be the 
    ' same as existing rows in the DataSet table.
    Dim newRow As DataRow
    newRow = cloneTable.NewRow()
    newRow("id") = 12
    newRow("Item") = 555
    newRow("extra") = "extra Column 1"
    cloneTable.Rows.Add(newRow)
        
    newRow = cloneTable.NewRow()
    newRow("id") = 13
    newRow("Item") = 665
    newRow("extra") = "extra Column 2"
    cloneTable.Rows.Add(newRow)

    ' Merge the table into the DataSet.
    Console.WriteLine("Merging")
    dataSet.Merge(cloneTable, False, MissingSchemaAction.Add)
    PrintValues(dataSet, "Merged With Table, Schema Added")
End Sub
  
Private Sub Row_Changed(sender As Object, _
    e As DataRowChangeEventArgs)
    Console.WriteLine("Row Changed " & e.Action.ToString() _
        & ControlChars.Tab & e.Row.ItemArray(0).ToString())
End Sub
    
Private Sub PrintValues(dataSet As DataSet, label As String)
    Console.WriteLine(ControlChars.Cr & label)
    Dim table As DataTable
    Dim row As DataRow
    Dim column As DataColumn
    For Each table In  dataSet.Tables
        Console.WriteLine("TableName: " & table.TableName)
        For Each row In  table.Rows             
            For Each column In  table.Columns
                Console.Write(ControlChars.Tab & " " _
                    & row(column).ToString())
            Next column
            Console.WriteLine()
        Next row
    Next table
 End Sub
' </Snippet1>
End Class 
