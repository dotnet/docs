Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected mappings As DataColumnMappingCollection
    Protected mapping As DataColumnMapping   
    
' <Snippet1>
 Public Sub FindDataColumnMapping()
     ' ...
     ' create mappings and mapping
     ' ...
     If mappings.Contains("Description") Then
         mapping = _
            DataColumnMappingCollection.GetColumnMappingBySchemaAction _
            (mappings, "Description", MissingMappingAction.Ignore)
     End If
 End Sub
' </Snippet1>
End Class
