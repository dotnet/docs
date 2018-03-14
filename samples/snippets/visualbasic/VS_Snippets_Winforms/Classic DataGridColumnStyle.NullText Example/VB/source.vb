Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected dataGrid1 As DataGrid
    
    ' <Snippet1>
    Private Sub SetNullText()
        Dim myGridColumn As DataGridColumnStyle
        myGridColumn = dataGrid1.TableStyles(0).GridColumnStyles(0)
        myGridColumn.NullText = "Null Text"
    End Sub 'SetNullText
    ' </Snippet1>
End Class 'Form1 

