imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
 Private Sub BindDataGrid()
    Dim table As New DataTable

    ' Insert code to populate a DataTable with data.

    ' Bind DataGrid to DataTable
    DataGrid1.DataSource = table
 End Sub 
 
 Private Sub ChangeRowFilter()
    Dim gridTable As DataTable = _
        CType(dataGrid1.DataSource, DataTable)

    ' Set the RowFilter to display a company names 
    ' that begin with A through I.
    gridTable.DefaultView.RowFilter = "CompanyName < 'I'"
 End Sub
' </Snippet1>

End Class
