Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel



Public Class Form1
    Inherits Form
    Protected dataGrid1 As DataGrid
    
    ' <Snippet1>
    Private Sub SetGridLineAttributes()
        dataGrid1.GridLineStyle = DataGridLineStyle.None
    End Sub
    ' </Snippet1>
End Class
