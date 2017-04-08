Imports System
Imports System.Data
Imports System.Data.Common

Public Class Form1
    Protected mappings As DataColumnMappingCollection    
    
' <Snippet1>
 Public Function PushIntoArray() As Boolean
     ' ...
     ' create mappings
     ' ...
     Dim columns As DataColumnMapping()
     mappings.CopyTo(columns, 0)
     mappings.Clear()
     PushIntoArray = True
 End Function
' </Snippet1>
End Class
