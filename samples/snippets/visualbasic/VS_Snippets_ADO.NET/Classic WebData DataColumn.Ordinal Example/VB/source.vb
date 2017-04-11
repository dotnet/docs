imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form


' <Snippet1>
Private Sub PrintColumnDetails(ByVal column As DataColumn)
    ' Print the Ordinal, ColumnName, and 
    ' DataType of the column.
    Console.WriteLine(column.Ordinal)
    Console.WriteLine(column.ColumnName)
    Console.WriteLine(column.DataType)
End Sub
' </Snippet1>

End Class
