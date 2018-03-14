imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form


' <Snippet1>
Private Sub AddDataColumn(ByVal table As DataTable)
    Dim column As DataColumn = New DataColumn()

    ' Set various properties.
    With column
       .ColumnName = "id"
       .DataType = System.Type.GetType("System.Int32")
       .AutoIncrement = True
       .AutoIncrementSeed = 1
       .AutoIncrementStep = 1
       .ReadOnly = True
     End With

    ' Add to Columns collection.
    table.Columns.Add(column)
End Sub
 ' </Snippet1>

End Class
