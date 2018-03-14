Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    ' <Snippet1>
    Private dataGrid1 As System.Windows.Forms.DataGrid
    
    
    Private Sub CreateDataGrid()
        dataGrid1 = New DataGrid()
        ' Add the handler for the DataSourceChanged event.
        AddHandler dataGrid1.DataSourceChanged, AddressOf DataGrid1_DataSourceChanged
    End Sub 'CreateDataGrid
     
    
    Private Sub DataGrid1_DataSourceChanged(sender As Object, e As EventArgs)
        Dim thisGrid As DataGrid = CType(sender, DataGrid)
    End Sub 'DataGrid1_DataSourceChanged
    ' </Snippet1>
End Class 'Form1 

