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
 Public Sub AddDataTableMapping()
     ' ...
     ' create mappings
     ' ...
     Dim mapping As New DataTableMapping("Categories", "DataCategories")
     mappings.Add(CType(mapping, Object))
     Console.WriteLine("Table " & mapping.ToString() & " added to " _
        & "table mapping collection " & mappings.ToString())
 End Sub
' </Snippet1>
End Class

