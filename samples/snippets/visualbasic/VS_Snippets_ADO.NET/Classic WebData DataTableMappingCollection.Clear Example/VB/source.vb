Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
    Protected mappings As DataTableMappingCollection
    
' <Snippet1>
 Public Sub PushIntoArray()
     ' ...
     ' create DataTableMappingCollection collection mappings
     ' ...
     Dim tables() As DataTableMapping
     mappings.CopyTo(tables, 0)
     mappings.Clear()
 End Sub
' </Snippet1>
End Class
