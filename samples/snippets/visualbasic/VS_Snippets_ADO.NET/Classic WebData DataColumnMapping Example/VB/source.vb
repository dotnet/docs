Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected columnMappings As DataColumnMappingCollection
    
' <Snippet1>
 Public Sub AddDataColumnMapping()
     ' ...
     ' create columnMappings
     ' ...
     Dim mapping As New DataColumnMapping( _
        "Description", "DataDescription")
     columnMappings.Add(CType(mapping, Object))
     Console.WriteLine("Column {0} added to column mapping collection {1}.", _
        mapping.ToString(), columnMappings.ToString())
 End Sub
' </Snippet1>
End Class

