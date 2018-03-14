Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits Form
    Protected columnMappings As DataColumnMappingCollection
    
' <Snippet1>
 Public Sub FindDataColumnMapping()
     ' ...
     ' create columnMappings
     ' ...
     If Not columnMappings.Contains("Description") Then
         Console.WriteLine("Error: no such table in collection.")
     Else
        Console.WriteLine("Name: {0}", _
            columnMappings("Description").ToString())
        Console.WriteLine("Index: {0}", _
            columnMappings.IndexOf("Description").ToString())
     End If
 End Sub
' </Snippet1>
End Class
