Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected dataGrid1 As DataGrid
    
    ' <Snippet1>
    Private Sub SetAllowNull()
        Dim myGridColumn As DataGridBoolColumn = CType(dataGrid1.TableStyles(0).GridColumnStyles(0), DataGridBoolColumn)
        myGridColumn.AllowNull = False
    End Sub 'SetAllowNull
    ' </Snippet1>
End Class 'Form1 

