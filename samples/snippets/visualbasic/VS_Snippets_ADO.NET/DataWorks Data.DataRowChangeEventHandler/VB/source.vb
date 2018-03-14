Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
' <Snippet1>
 Private dataTable As DataTable    
    
 Private Sub [AddHandler]()
     dataTable = New DataTable("dataTable")
     AddHandler dataTable.RowChanged, AddressOf dataTable_Changed
 End Sub    
    
 Private Sub dataTable_Changed _
    (sender As Object, e As System.Data.DataRowChangeEventArgs)
 
     Console.WriteLine("Row Changed", e.Action, _
        e.Row(dataGrid1.CurrentCell.ColumnNumber))
 End Sub
' </Snippet1>
End Class

