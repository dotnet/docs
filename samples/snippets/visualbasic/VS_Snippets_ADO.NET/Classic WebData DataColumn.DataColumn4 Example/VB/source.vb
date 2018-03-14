imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

  protected DataSet1 As DataSet

' <Snippet1>
Private Sub CreateComputedColumn(ByVal table As DataTable)
    Dim column As DataColumn
    Dim decimalType As System.Type = _
        System.Type.GetType("System.Decimal")

    ' The expression multiplies the "Price" column value by the 
    ' "Quantity" to create the "Total" column.
    Dim expression As String = "Price * Quantity"

    ' Create the column, setting the type to Attribute.
    column = New DataColumn("Total", decimalType, _
        expression, MappingType.Attribute)

    ' Set various properties.
    column.AutoIncrement = False
    column.ReadOnly = True

    ' Add the column to a DataTable object's DataColumnCollection.
    DataSet1.Tables("OrderDetails").Columns.Add(column)
End Sub
' </Snippet1>

End Class
