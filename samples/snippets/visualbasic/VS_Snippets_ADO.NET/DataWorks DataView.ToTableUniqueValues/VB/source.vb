Option Explicit
Option Strict

Imports System
Imports System.Data

    
Module Module1

    Sub Main()
        DemonstrateDataView()
    End Sub
' <Snippet1>
    Private Sub DemonstrateDataView()
        ' Create a DataTable with three columns.
        Dim table As DataTable = New DataTable("NewTable")
        Console.WriteLine("Original table name: " & table.TableName)
        Dim column As DataColumn = New DataColumn("ID", GetType(System.Int32))
        table.Columns.Add(column)

        column = New DataColumn("Category", GetType(System.String))
        table.Columns.Add(column)

        column = New DataColumn("Product", GetType(System.String))
        table.Columns.Add(column)

        column = New DataColumn("QuantityInStock", GetType(System.Int32))
        table.Columns.Add(column)


        ' Add some items.
        Dim row As DataRow = table.NewRow()
        row.ItemArray = New Object() {1, "Fruit", "Apple", 14}
        table.Rows.Add(row)

        row = table.NewRow()
        row.ItemArray = New Object() {2, "Fruit", "Orange", 27}
        table.Rows.Add(row)

        row = table.NewRow()
        row.ItemArray = New Object() {3, "Bread", "Muffin", 23}
        table.Rows.Add(row)

        row = table.NewRow()
        row.ItemArray = New Object() {4, "Fish", "Salmon", 12}
        table.Rows.Add(row)

        row = table.NewRow()
        row.ItemArray = New Object() {5, "Fish", "Salmon", 15}
        table.Rows.Add(row)

        row = table.NewRow()
        row.ItemArray = New Object() {6, "Bread", "Croissant", 23}
        table.Rows.Add(row)

        ' Mark all rows as "accepted". Not required
        ' for this particular example.
        table.AcceptChanges()

        ' Print current table values.
        PrintTableOrView(table, "Current Values in Table")

        Dim view As DataView = New DataView(table)
        view.Sort = "Category"
        PrintTableOrView(view, "Current Values in View")

        Dim newTable As DataTable = view.ToTable( _
            True, "Category", "QuantityInStock")
        PrintTableOrView(newTable, "Table created from sorted DataView")
        Console.WriteLine("New table name: " & newTable.TableName)

        Console.WriteLine("Press any key to continue.")
        Console.ReadKey()
    End Sub

    Private Sub PrintTableOrView(ByVal dv As DataView, ByVal label As String)
        Dim sw As System.IO.StringWriter
        Dim output As String
        Dim table As DataTable = dv.Table

        Console.WriteLine(label)

        ' Loop through each row in the view.
        For Each rowView As DataRowView In dv
            sw = New System.IO.StringWriter

            ' Loop through each column.
            For Each col As DataColumn In table.Columns
                ' Output the value of each column's data.
                sw.Write(rowView(col.ColumnName).ToString() & ", ")
            Next
            output = sw.ToString
            ' Trim off the trailing ", ", so the output looks correct.
            If output.Length > 2 Then
                output = output.Substring(0, output.Length - 2)
            End If
            ' Display the row in the console window.
            Console.WriteLine(output)
        Next
        Console.WriteLine()
    End Sub

    Private Sub PrintTableOrView(ByVal table As DataTable, ByVal label As String)
        Dim sw As System.IO.StringWriter
        Dim output As String

        Console.WriteLine(label)

        ' Loop through each row in the table.
        For Each row As DataRow In table.Rows
            sw = New System.IO.StringWriter
            ' Loop through each column.
            For Each col As DataColumn In table.Columns
                ' Output the value of each column's data.
                sw.Write(row(col).ToString() & ", ")
            Next
            output = sw.ToString
            ' Trim off the trailing ", ", so the output looks correct.
            If output.Length > 2 Then
                output = output.Substring(0, output.Length - 2)
            End If
            ' Display the row in the console window.
            Console.WriteLine(output)
        Next
        Console.WriteLine()
    End Sub
' </Snippet1>
End Module

