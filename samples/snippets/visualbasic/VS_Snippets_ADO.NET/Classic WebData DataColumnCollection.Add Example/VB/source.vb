imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet

' <Snippet1>
Private Sub AddDataColumn()
    ' Get the DataColumnCollection from a DataTable in a DataSet.
    Dim columns As DataColumnCollection = _
        DataSet1.Tables("Orders").Columns
 
    Dim column As DataColumn = New DataColumn
    With column
       .DataType = System.Type.GetType("System.Decimal")
       .ColumnName = "ItemPrice"
       .Caption = "Price"
       .ReadOnly = False
       .Unique = False
       .DefaultValue = 0
    End With
    columns.Add(column)
End Sub
' </Snippet1>

End Class
