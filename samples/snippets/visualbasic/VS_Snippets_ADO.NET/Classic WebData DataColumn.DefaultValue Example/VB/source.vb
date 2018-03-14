imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form


' <Snippet1>
Private Sub CreateColumns()
    Dim column As DataColumn
    Dim table As New DataTable
 
    column = New DataColumn
    With column
       .DataType = System.Type.GetType("System.String")
       .DefaultValue = "Address"
       .Unique = False
    End With
    table.Columns.Add(column)
    
    column = New DataColumn
    With column
       .DataType = System.Type.GetType("System.Int32")
       .DefaultValue = 100
    End With
    table.Columns.Add(column)
 
    column = New DataColumn
    With column
       .DataType = System.Type.GetType("System.DateTime")
       .DefaultValue = "1/1/2001"
    End With
    table.Columns.Add(column)
 
    Dim row As DataRow
    ' Add one row. Since it has default values, 
    ' no need to set values yet.
    row = table.NewRow
   
    table.Rows.Add(row)
 End Sub
' </Snippet1>

End Class
