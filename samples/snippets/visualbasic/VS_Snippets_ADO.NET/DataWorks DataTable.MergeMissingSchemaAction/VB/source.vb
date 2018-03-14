Option Explicit
Option Strict

Imports System
Imports System.Data

    
Module Module1

  Sub Main()
    DemonstrateMergeTable()
    Console.WriteLine("Press any key to continue.")
    Console.ReadKey()
  End Sub
' <Snippet1>
  Private Sub DemonstrateMergeTable()
    Dim itemsTable As New DataTable("Items")

    ' Add columns
    Dim idColumn As New DataColumn("id", GetType(System.Int32))
    Dim itemColumn As New DataColumn("item", GetType(System.Int32))
    itemsTable.Columns.Add(idColumn)
    itemsTable.Columns.Add(itemColumn)

    ' Set the primary key column.
    itemsTable.PrimaryKey = New DataColumn() {idColumn}

    ' Add RowChanged event handler for the table.
    AddHandler itemsTable.RowChanged, AddressOf Row_Changed

    ' Add some rows.
    Dim row As DataRow
    For i As Integer = 0 To 3
      row = itemsTable.NewRow()
      row("id") = i
      row("item") = i
      itemsTable.Rows.Add(row)
    Next i

    ' Accept changes.
    itemsTable.AcceptChanges()
    PrintValues(itemsTable, "Original values")

    ' Create a second DataTable identical to the first.
    Dim itemsClone As DataTable = itemsTable.Clone()

    ' Add column to the second column, so that the 
    ' schemas no longer match.
    itemsClone.Columns.Add("newColumn", GetType(System.String))

    ' Add three rows. Note that the id column can't be the 
    ' same as existing rows in the original table.
    row = itemsClone.NewRow()
    row("id") = 14
    row("item") = 774
    row("newColumn") = "new column 1"
    itemsClone.Rows.Add(row)

    row = itemsClone.NewRow()
    row("id") = 12
    row("item") = 555
    row("newColumn") = "new column 2"
    itemsClone.Rows.Add(row)

    row = itemsClone.NewRow()
    row("id") = 13
    row("item") = 665
    row("newColumn") = "new column 3"
    itemsClone.Rows.Add(row)

    ' Merge itemsClone into the itemsTable.
    Console.WriteLine("Merging")
    itemsTable.Merge(itemsClone, False, MissingSchemaAction.Add)
    PrintValues(itemsTable, "Merged With itemsTable, Schema added")
  End Sub

  Private Sub Row_Changed(ByVal sender As Object, _
    ByVal e As DataRowChangeEventArgs)
    Console.WriteLine("Row changed {0}{1}{2}", _
      e.Action, ControlChars.Tab, e.Row.ItemArray(0))
  End Sub

  Private Sub PrintValues(ByVal table As DataTable, ByVal label As String)
    ' Display the values in the supplied DataTable:
    Console.WriteLine(label)
    For Each row As DataRow In table.Rows
      For Each col As DataColumn In table.Columns
        Console.Write(ControlChars.Tab + " " + row(col).ToString())
      Next col
      Console.WriteLine()
    Next row
  End Sub
' </Snippet1>
End Module

