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
Private Sub DemonstrateMergeTable()
    ' Create a DataSet with one table, two columns, 
    ' and ten rows.
    Dim dataSet As New DataSet("dataSet")
    Dim table As New DataTable("Items")

    ' Add tables to the DataSet
    dataSet.Tables.Add(table)

    ' Add columns
    Dim c1 As New DataColumn("id", Type.GetType("System.Int32"), "")
    Dim c2 As New DataColumn("Item", Type.GetType("System.Int32"), "")
    table.Columns.Add(c1)
    table.Columns.Add(c2)

    ' DataColumn array to set primary key.
    Dim keyCol(1) As DataColumn

    ' Set primary key column.
    keyCol(0) = c1
    table.PrimaryKey = keyCol

    ' Add RowChanged event handler for the table.
    AddHandler table.RowChanged, AddressOf Row_Changed

    ' Add ten rows.
    Dim i As Integer
    Dim row As DataRow

    For i = 0 To 9
        row = table.NewRow()
        row("id") = i
        row("Item") = i
        table.Rows.Add(row)
    Next i

    ' Accept changes.
    dataSet.AcceptChanges()
    PrintValues(dataSet, "Original values")

    ' Create a second DataTable identical to the first.
    Dim t2 As DataTable
    t2 = table.Clone()

    ' Add three rows. Note that the id column can't be the 
    ' same as existing rows in the DataSet table.
    Dim newRow As DataRow
    newRow = t2.NewRow()
    newRow("id") = 14
    newRow("Item") = 774
    t2.Rows.Add(newRow)

    newRow = t2.NewRow()
    newRow("id") = 12
    newRow("Item") = 555
    t2.Rows.Add(newRow)

    newRow = t2.NewRow()
    newRow("id") = 13
    newRow("Item") = 665
    t2.Rows.Add(newRow)

    ' Merge the table into the DataSet.
    Console.WriteLine("Merging")
    dataSet.Merge(t2)
    PrintValues(dataSet, "Merged With Table")
 End Sub 
     
 Private Sub Row_Changed( _
    sender As Object, e As DataRowChangeEventArgs)
     Console.WriteLine("Row Changed " & e.Action.ToString() _
        & ControlChars.Tab & e.Row.ItemArray(0).ToString())
 End Sub 'Row_Changed
 
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
