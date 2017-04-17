Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected dataGrid1 As DataGrid
    Protected dataSet1 As DataSet
    
    ' <Snippet1>
    Private Sub SetReadOnly()
        Dim myColumn As DataGridColumnStyle
        Dim myDataColumns As DataColumnCollection
        ' Get the columns for a table bound to a DataGrid.
        myDataColumns = dataSet1.Tables("Suppliers").Columns
        Dim dataColumn As DataColumn
        For Each dataColumn In myDataColumns
            dataGrid1.TableStyles(0).GridColumnStyles(dataColumn.ColumnName).ReadOnly = dataColumn.ReadOnly
        Next dataColumn
    End Sub 'SetReadOnly
    ' </Snippet1>
End Class 'Form1 

