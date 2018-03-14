Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
    Protected dataSet As DataSet
    Protected mapping As DataTableMapping
    
' <Snippet1>
 Public Sub CreateDataTable()
     ' ...
     ' create dataSet and mapping
     ' ...
     Dim table As DataTable = mapping.GetDataTableBySchemaAction _
        (dataSet, MissingSchemaAction.Ignore)
 End Sub
' </Snippet1>
End Class

