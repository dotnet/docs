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
    ' Demonstrate merging, within and without
    ' preserving changes.

    ' In this example, take these actions:
    ' 1. Create a DataTable (table1) and fill the table with data.
    ' 2. Create a copy of table1, and modify its data (modifiedTable).
    ' 3. Modify data in table1.
    ' 4. Make a copy of table1 (table1Copy).
    ' 5. Merge the data from modifiedTable into table1 and table1Copy, 
    '    showing the difference between setting the preserveChanges 
    '    parameter to true and false.

    ' Create a new DataTable.
    Dim table1 As New DataTable("Items")

    ' Add two columns to the table:
    Dim column As New DataColumn("id", GetType(System.Int32))
    column.AutoIncrement = True
    table1.Columns.Add(column)

    column = New DataColumn("item", GetType(System.String))
    table1.Columns.Add(column)

    ' Set primary key column.
    table1.PrimaryKey = New DataColumn() {table1.Columns(0)}

    ' Add some rows.
    Dim row As DataRow
    For i As Integer = 0 To 3
      row = table1.NewRow()
      row("item") = "Item " & i
      table1.Rows.Add(row)
    Next i

    ' Accept changes.
    table1.AcceptChanges()
    PrintValues(table1, "Original values")

    ' Using the same schema as the original table, 
    ' modify the data for later merge.
    Dim modifiedTable As DataTable = table1.Copy()
    For Each row In modifiedTable.Rows
      row("item") = row("item").ToString() & " modified"
    Next
    modifiedTable.AcceptChanges()

    ' Change row values, and add a new row:
    table1.Rows(0)("item") = "New Item 0"
    table1.Rows(1)("item") = "New Item 1"

    row = table1.NewRow()
    row("id") = 4
    row("item") = "Item 4"
    table1.Rows.Add(row)

    ' Get a copy of the modified data:
    Dim table1Copy As DataTable = table1.Copy()
    PrintValues(table1, "Modified and New Values")
    PrintValues(modifiedTable, "Data to be merged into table1")


    ' Merge new data into the modified data.
    table1.Merge(modifiedTable, True)
    PrintValues(table1, "Merged data (preserve changes)")

    table1Copy.Merge(modifiedTable, False)
    PrintValues(modifiedTable, "Merged data (don't preserve changes)")

  End Sub

  Private Sub PrintValues(ByVal table As DataTable, _
    ByVal label As String)

    ' Display the values in the supplied DataTable:
    Console.WriteLine(label)
    For Each row As DataRow In table.Rows
      For Each column As DataColumn In table.Columns
        Console.Write("{0}{1}", ControlChars.Tab, row(column, _
            DataRowVersion.Current))
      Next column
      Console.WriteLine()
    Next row
  End Sub
' </Snippet1>
End Module

