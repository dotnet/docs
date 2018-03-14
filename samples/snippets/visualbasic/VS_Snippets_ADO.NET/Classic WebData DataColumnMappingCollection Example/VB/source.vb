Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits Form
    Protected tableMapping As DataTableMapping
    
' <Snippet1>
 Public Sub ShowColumnMappings()
     ' ...
     ' create tableMapping
     ' ...
     tableMapping.ColumnMappings.Add( _
        "Category Name", "DataCategory")
     tableMapping.ColumnMappings.Add( _
        "Description", "DataDescription")
     tableMapping.ColumnMappings.Add( _
        "Picture", "DataPicture")
     Console.WriteLine("Column Mappings:")
     Dim i As Integer
     For i = 0 To tableMapping.ColumnMappings.Count - 1
         Console.WriteLine("  {0} {1}", i, _
            tableMapping.ColumnMappings(i).ToString())
     Next i
 End Sub
' </Snippet1>
End Class
