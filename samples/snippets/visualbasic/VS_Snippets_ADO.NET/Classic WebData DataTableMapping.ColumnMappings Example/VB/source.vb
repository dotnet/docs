Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
    Protected mappings As DataColumnMappingCollection
    
' <Snippet1>
 Public Sub CreateDataTableMapping()
     ' ...
     ' create mappings
     ' ...
     Dim columns() As DataColumnMapping
     ' Copy mappings to array
     mappings.CopyTo(columns, 0)
     Dim mapping As New DataTableMapping _
        ("Categories", "DataCategories", columns)
 End Sub
' </Snippet1>
End Class

