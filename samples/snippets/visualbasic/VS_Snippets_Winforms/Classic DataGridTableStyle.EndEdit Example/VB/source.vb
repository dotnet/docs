Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class Form1
    Inherits Form
    Protected myDataGrid As DataGrid
    Protected myDataSet As DataSet
    
    ' <Snippet1>
    Private Sub EditTable()
        Dim dgt As DataGridTableStyle = myDataGrid.TableStyles(0)
        Dim myCol As DataGridColumnStyle = dgt.GridColumnStyles(0)
        
        dgt.BeginEdit(myCol, 1)
        dgt.EndEdit(myCol, 1, True)
    End Sub 'EditTable
    ' </Snippet1>
End Class 'Form1
