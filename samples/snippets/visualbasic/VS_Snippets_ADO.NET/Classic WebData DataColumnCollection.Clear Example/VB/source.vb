Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    
' <Snippet1>
 Private Sub ClearColumnsCollection(table As DataTable)
     Dim columns As DataColumnCollection
     ' Get the DataColumnCollection from a 
     ' DataTable in a DataSet.
     columns = table.Columns
     columns.Clear()
End Sub
' </Snippet1>
End Class
