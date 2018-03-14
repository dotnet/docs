imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form


' <Snippet1>
Private Sub AddColumn(table As DataTable )
    ' Create a new column and set its properties.
    Dim column As DataColumn = New DataColumn("ID", _
        Type.GetType("System.Int32"), "", MappingType.Attribute)
    column.DataType = Type.GetType("System.String")
    column.ColumnMapping = MappingType.Element

    ' Add the column the table's columns collection.
    table.Columns.Add(column)
End Sub
' </Snippet1>

End Class
