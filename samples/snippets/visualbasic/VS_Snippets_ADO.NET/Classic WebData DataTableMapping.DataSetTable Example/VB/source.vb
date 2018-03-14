Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
' <Snippet1>
 Public Sub CreateDataTableMapping()
     Dim mapping As New DataTableMapping()
     mapping.SourceTable = "Categories"
     mapping.DataSetTable = "DataCategories"
 End Sub
' </Snippet1>
End Class
