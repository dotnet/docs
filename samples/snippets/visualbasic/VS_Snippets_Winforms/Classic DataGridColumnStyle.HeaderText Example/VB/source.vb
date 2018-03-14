Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected dataGrid1 As DataGrid
    Protected dataSet1 As DataSet
    
    ' <Snippet1>
    Private Sub SetHeaderText()
        Dim dgCol As DataGridColumnStyle
        Dim dataCol1 As DataColumn
        Dim dataTable1 As DataTable
        dgCol = dataGrid1.TableStyles(0).GridColumnStyles(0)
        dataTable1 = dataSet1.Tables(dataGrid1.DataMember)
        dataCol1 = dataTable1.Columns(dgCol.MappingName)
        dgCol.HeaderText = dataCol1.Caption
    End Sub 'SetHeaderText
    ' </Snippet1>
End Class 'Form1 

