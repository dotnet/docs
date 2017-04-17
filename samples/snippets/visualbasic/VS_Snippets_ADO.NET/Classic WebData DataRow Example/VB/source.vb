imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub CreateNewDataRow()
    ' Use the MakeTable function below to create a new table.
    Dim table As DataTable
    table = MakeNamesTable()

    ' Once a table has been created, use the 
    ' NewRow to create a DataRow.
    Dim row As DataRow 
    row = table.NewRow()

    ' Then add the new row to the collection.
    row("fName") = "John"
    row("lName") = "Smith"
    table.Rows.Add(row)
    
    Dim column As DataColumn
    For Each column in table.Columns
       Console.WriteLine(column.ColumnName)
    Next
    DataGrid1.DataSource=table
 End Sub
 
 Private Function MakeNamesTable() As DataTable
    ' Create a new DataTable titled 'Names.'
    Dim namesTable As DataTable = new DataTable("Names") 

    ' Add three column objects to the table.
    Dim idColumn As DataColumn = new  DataColumn()
    idColumn.DataType = System.Type.GetType("System.Int32")
    idColumn.ColumnName = "id"
    idColumn.AutoIncrement = True
    namesTable.Columns.Add(idColumn)

    Dim fNameColumn As DataColumn = New DataColumn()
    fNameColumn.DataType = System.Type.GetType("System.String")
    fNameColumn.ColumnName = "Fname"
    fNameColumn.DefaultValue = "Fname"
    namesTable.Columns.Add(fNameColumn)

    Dim lNameColumn As DataColumn = new DataColumn()
    lNameColumn.DataType = System.Type.GetType("System.String")
    lNameColumn.ColumnName = "LName"
    namesTable.Columns.Add(lNameColumn)

    ' Create an array for DataColumn objects.
    Dim keys(0) As DataColumn 
    keys(0) = idColumn
    namesTable.PrimaryKey = keys

    ' Return the new DataTable.
    MakeNamesTable = namesTable
 End Function
 ' </Snippet1>

End Class
