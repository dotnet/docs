Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
    Protected mappings As DataTableMappingCollection
    
' <Snippet1>
 Public Sub FindDataTableMapping()
     ' ...
     ' create mappings
     ' ...
     If Not mappings.Contains("Categories") Then
         Console.WriteLine("Error: no such table in collection")
     Else
         Console.WriteLine("Name: " & mappings("Categories").ToString() _
            & ControlChars.Cr + "Index: " _
            & mappings.IndexOf("Categories").ToString())
     End If
 End Sub
' </Snippet1>
End Class

