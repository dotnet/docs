Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected dataGrid1 As DataGrid
    
    ' <Snippet1>
    Private Sub SetGridColors()
        dataGrid1.BackColor = System.Drawing.Color.Red
        dataGrid1.AlternatingBackColor = System.Drawing.Color.AliceBlue
        dataGrid1.BackgroundColor = System.Drawing.Color.Yellow
    End Sub 'SetGridColors
    ' </Snippet1>
End Class 'Form1 

