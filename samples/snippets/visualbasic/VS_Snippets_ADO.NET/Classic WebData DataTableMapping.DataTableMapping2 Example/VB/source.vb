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
     Dim columns1() As DataColumnMapping
     mappings.CopyTo(columns1, 0)
     Dim mapping As New DataTableMapping _
        ("Categories", "DataCategories", columns1)
        
     Dim columns2() As DataColumnMapping
     mapping.ColumnMappings.CopyTo(columns2, 0)
 End Sub
' </Snippet1>
End Class
