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
Private Sub DemonstrateMergeMissingSchema()
    ' Create a DataSet with one table, two columns, 
    ' and three rows.
    Dim dataSet As New DataSet("dataSet")
    Dim table As New DataTable("Items")
    Dim idColumn As New DataColumn("id", _
        Type.GetType("System.Int32"))
    idColumn.AutoIncrement = True
    Dim itemColumn As New DataColumn("Item", _
        Type.GetType("System.Int32"))

    ' DataColumn array to set primary key.
    Dim keyColumn(1) As DataColumn
    Dim row As DataRow

    ' Create variable for temporary DataSet. 
    Dim changeDataSet As DataSet

    ' Add RowChanged event handler for the table.
    AddHandler table.RowChanged, AddressOf Row_Changed
    dataSet.Tables.Add(table)
    table.Columns.Add(idColumn)
    table.Columns.Add(itemColumn)

    ' Set primary key column.
    keyColumn(0) = idColumn
    table.PrimaryKey = keyColumn

    ' Add ten rows.
    Dim i As Integer
    For i = 0 To 9
        row = table.NewRow()
        row("Item") = i
        table.Rows.Add(row)
    Next i

    ' Accept changes.
    dataSet.AcceptChanges()
    PrintValues(dataSet, "Original values")

    ' Change row values.
    table.Rows(0)("Item") = 50
    table.Rows(1)("Item") = 111

    ' Add one row.
    row = table.NewRow()
    row("Item") = 74
    table.Rows.Add(row)

    ' Insert code for error checking. Set one row in error.
    table.Rows(1).RowError = "over 100"
    PrintValues(dataSet, "Modified and New Values")
    ' If the table has changes or errors, 
    ' create a subset DataSet.
    If dataSet.HasChanges(DataRowState.Modified Or DataRowState.Added) _
        And dataSet.HasErrors Then
        ' Use GetChanges to extract subset.
        changeDataSet = dataSet.GetChanges(DataRowState.Modified _
            Or DataRowState.Added)
        PrintValues(changeDataSet, "Subset values")
        ' Insert code to reconcile errors. In this case, reject changes.
        Dim changeTable As DataTable
        For Each changeTable In  changeDataSet.Tables
            If changeTable.HasErrors Then
                Dim changeRow As DataRow
                For Each changeRow In  changeTable.Rows
                    If CInt(changeRow("Item", _
                        DataRowVersion.Current)) > 100 Then
                        changeRow.RejectChanges()
                        changeRow.ClearErrors()
                    End If
                Next changeRow
            End If
        Next changeTable

        ' Add a column to the changeDataSet to change the schema.
        changeDataSet.Tables("Items").Columns.Add( _
            New DataColumn("newColumn"))
        PrintValues(changeDataSet, "Reconciled subset values")

        ' Add values to the rows for each column.
        Dim rowItem As DataRow
        For Each rowItem In  changeDataSet.Tables("Items").Rows
            rowItem("newColumn") = "my new schema value"
        Next rowItem

        ' Merge changes back to first DataSet.
        dataSet.Merge(changeDataSet, False, _
            System.Data.MissingSchemaAction.Add)
    End If
    PrintValues(dataSet, "Merged Values")
End Sub
    
Private Sub Row_Changed(sender As Object, _
    e As DataRowChangeEventArgs)
     Console.WriteLine("Row Changed " & e.Action.ToString() _
        & ControlChars.Tab & e.Row.ItemArray(0).ToString())
End Sub
 
Private Sub PrintValues(dataSet As DataSet, label As String)
    Console.WriteLine(ControlChars.Cr & label)
    Dim table As DataTable
    For Each table In  dataSet.Tables
        Console.WriteLine("TableName: " & table.TableName)
        Dim row As DataRow
        For Each row In  table.Rows
            Dim column As DataColumn
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
