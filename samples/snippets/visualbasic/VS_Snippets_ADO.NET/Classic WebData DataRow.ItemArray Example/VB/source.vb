imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet

' <Snippet1>
Private Sub CreateRowsWithItemArray()
    ' Make a DataTable using the function below.
    Dim dt As DataTable = MakeTableWithAutoIncrement()
    Dim relation As DataRow

    ' Declare the array variable.
    Dim rowArray(1) As Object

    ' Create 10 new rows and add to DataRowCollection.
    Dim i As Integer
    For i = 0 to 9
       rowArray(0) = DBNull.Value
       rowArray(1)= "item " & i.ToString()
       relation = dt.NewRow()
       relation.ItemArray = rowArray
       dt.Rows.Add(relation)
    Next
    PrintTable(dt)
End Sub
 
Private Function MakeTableWithAutoIncrement() As DataTable
    ' Make a table with one AutoIncrement column.
    Dim table As DataTable = New DataTable("table")
    Dim idColumn As DataColumn = New DataColumn("id", _
        Type.GetType("System.Int32"))
    idColumn.AutoIncrement = True
    idColumn.AutoIncrementSeed = 10
    table.Columns.Add (idColumn)
    
    Dim firstNameColumn As DataColumn = New DataColumn( _
        "Item", Type.GetType("System.String"))
    table.Columns.Add(firstNameColumn)
    MakeTableWithAutoIncrement = table
End Function
 
Private Sub PrintTable(table As DataTable)
    Dim row As DataRow
    Dim column As DataColumn
    For Each row in table.Rows
       For Each column in table.Columns
          Console.WriteLine(row(column))
       Next
    Next
End Sub
' </Snippet1>

End Class
