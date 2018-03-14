imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form


' <Snippet1>
Private Sub AddNullAllowedColumn()
    Dim column As DataColumn
    column = New DataColumn("classID", _
        System.Type.GetType("System.Int32"))
    column.AllowDBNull = True

    ' Add the column to a new DataTable.
    Dim table As DataTable
    table = New DataTable
    table.Columns.Add(column)
End Sub
' </Snippet1>

End Class
