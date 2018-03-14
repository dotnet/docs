Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected mappings As DataColumnMappingCollection    
    
' <Snippet1>
 Public Sub RemoveDataColumnMapping()
     ' ...
     ' create mappings
     ' ...
     If mappings.Contains(7) Then
         mappings.RemoveAt(7)
     End If
 End Sub
' </Snippet1>
End Class
