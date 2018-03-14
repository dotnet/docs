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
    Dim table1 As New DataTable("Items")

    ' Add columns
    Dim idColumn As New DataColumn("id", GetType(System.Int32))
    Dim itemColumn As New DataColumn("item", GetType(System.Int32))
    table1.Columns.Add(idColumn)
    table1.Columns.Add(itemColumn)

    ' Set the primary key column.
    table1.PrimaryKey = New DataColumn() {idColumn}

    ' Add RowChanged event handler for the table.
    AddHandler table1.RowChanged, AddressOf Row_Changed

    ' Add some rows.
    Dim row As DataRow
    For i As Integer = 0 To 3
      row = table1.NewRow()
      row("id") = i
      row("item") = i
      table1.Rows.Add(row)
    Next i

    ' Accept changes.
    table1.AcceptChanges()
    PrintValues(table1, "Original values")

    ' Create a second DataTable identical to the first.
    Dim table2 As DataTable = table1.Clone()

    ' Add column to the second column, so that the 
    ' schemas no longer match.
    table2.Columns.Add("newColumn", GetType(System.String))

    ' Add three rows. Note that the id column can't be the 
    ' same as existing rows in the original table.
    row = table2.NewRow()
    row("id") = 14
    row("item") = 774
    row("newColumn") = "new column 1"
    table2.Rows.Add(row)

    row = table2.NewRow()
    row("id") = 12
    row("item") = 555
    row("newColumn") = "new column 2"
    table2.Rows.Add(row)

    row = table2.NewRow()
    row("id") = 13
    row("item") = 665
    row("newColumn") = "new column 3"
    table2.Rows.Add(row)

    ' Merge table2 into the table1.
    Console.WriteLine("Merging")
    table1.Merge(table2, False, MissingSchemaAction.Add)
    PrintValues(table1, "Merged With table1, Schema added")
  End Sub

  Private Sub Row_Changed(ByVal sender As Object, _
        ByVal e As DataRowChangeEventArgs)
    Console.WriteLine("Row changed {0}{1}{2}", _
      e.Action, ControlChars.Tab, e.Row.ItemArray(0))
  End Sub

  Private Sub PrintValues(ByVal table As DataTable, _
        ByVal label As String)
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



