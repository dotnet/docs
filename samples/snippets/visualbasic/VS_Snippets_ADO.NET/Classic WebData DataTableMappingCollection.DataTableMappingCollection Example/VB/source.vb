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
    
' <Snippet1>
 Public Sub CreateTableMappings()
     Dim mappings As New DataTableMappingCollection()
     mappings.Add("Categories", "DataCategories")
     mappings.Add("Orders", "DataOrders")
     mappings.Add("Products", "DataProducts")
     Dim message As String = "TableMappings:" & ControlChars.Cr
     Dim i As Integer
     For i = 0 To mappings.Count - 1
         message &= i.ToString() & " " + mappings(i).ToString() _
            & ControlChars.Cr
     Next i
     Console.WriteLine(message)
 End Sub
' </Snippet1>
End Class
