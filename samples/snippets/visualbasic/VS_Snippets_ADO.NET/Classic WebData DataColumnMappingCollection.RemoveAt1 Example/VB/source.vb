Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected columnMappings As DataColumnMappingCollection
    
' <Snippet1>
 Public Sub RemoveDataColumnMapping()
     ' ...
     ' create columnMappings
     ' ...
     If columnMappings.Contains("Picture") Then
         columnMappings.RemoveAt("Picture")
     End If
 End Sub
' </Snippet1>
End Class
