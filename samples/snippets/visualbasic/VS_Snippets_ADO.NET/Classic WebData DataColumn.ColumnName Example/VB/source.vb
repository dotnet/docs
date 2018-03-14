imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form


' <Snippet1>
Private Sub PrintColumnNames(dataSet As DataSet)
    Dim table As DataTable
    Dim column As DataColumn 

    ' For each DataTable, print the ColumnName.
    For Each table in dataSet.Tables
        For Each column in table.Columns
        Console.WriteLine(column.ColumnName)
        Next
    Next
End Sub

Private Sub AddColumn(table As DataTable)
    Dim column As DataColumn
    column = New DataColumn()

    With column
        .ColumnName = "SupplierID"
        .DataType = System.Type.GetType("System.String")
        .Unique = True
        .AutoIncrement = False
        .Caption = "SupplierID"
        .ReadOnly = False
    End With

    ' Add the column to the table's columns collection.
    table.Columns.Add(column)
End Sub
 ' </Snippet1>

End Class
