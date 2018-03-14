Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits Form
    
' <Snippet1>
 Public Sub CreateColumnMappings()
     Dim mappings As New DataColumnMappingCollection()
     mappings.Add("Category Name", "DataCategory")
     mappings.Add("Description", "DataDescription")
     mappings.Add("Picture", "DataPicture")
     Dim message As String = "ColumnMappings:" + ControlChars.Cr
     Dim i As Integer
     For i = 0 To mappings.Count - 1
         message += i.ToString() + " " + mappings(i).ToString() _
            + ControlChars.Cr
     Next i
     Console.WriteLine(message)
 End Sub
' </Snippet1>
End Class
