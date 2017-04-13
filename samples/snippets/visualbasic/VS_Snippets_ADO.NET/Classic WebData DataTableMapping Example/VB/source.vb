Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
    Protected tableMappings As DataTableMappingCollection
    
' <Snippet1>
 Public Sub AddDataTableMapping()
     ' ...
     ' create tableMappings
     ' ...
     Dim mapping As New DataTableMapping( _
        "Categories", "DataCategories")
     tableMappings.Add(CType(mapping, Object))
     Console.WriteLine( _
        "Table {0} added to {1} table mapping collection.", _
        mapping.ToString(), tableMappings.ToString())
 End Sub
' </Snippet1>
End Class

