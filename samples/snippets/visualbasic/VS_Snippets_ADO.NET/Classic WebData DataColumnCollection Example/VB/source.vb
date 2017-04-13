imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet

' <Snippet1>
Private Sub PrintDataTableColumnInfo(table As DataTable)
    
    ' Use a DataTable object's DataColumnCollection.
    Dim columns As DataColumnCollection = table.Columns

    ' Print the ColumnName and DataType for each column.
    Dim column As DataColumn
    For Each column in columns
       Console.WriteLine(column.ColumnName)
       Console.WriteLine(column.DataType.ToString)
    Next
End Sub
   ' </Snippet1>

End Class
