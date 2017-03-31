imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form


' <Snippet1>
Private Sub AddColumn(ByVal table As DataTable)
    ' Add a DataColumn to the collection and set its properties.
    ' The constructor sets the ColumnName of the column.
    Dim column As DataColumn = table.Columns.Add("Total")
    column.DataType = System.Type.GetType("System.Decimal")
    column.ReadOnly = True
    column.Expression = "UnitPrice * Quantity"
    column.Unique = False
End Sub
' </Snippet1>

End Class
