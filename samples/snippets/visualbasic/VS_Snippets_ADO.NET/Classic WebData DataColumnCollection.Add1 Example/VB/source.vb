imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet

' <Snippet1>
Private Sub AddColumn()
    ' Get the DataColumnCollection of a table in a DataSet.
    Dim columns As DataColumnCollection = _
        DataSet1.Tables("Orders").Columns

    ' Add a new column and return it.
    Dim column As DataColumn = _
        columns.Add("Total", System.Type.GetType( _
        "System.Decimal"), "Price + Tax")
    column.ReadOnly = True
    column.Unique = False
 End Sub
 ' </Snippet1>

End Class
