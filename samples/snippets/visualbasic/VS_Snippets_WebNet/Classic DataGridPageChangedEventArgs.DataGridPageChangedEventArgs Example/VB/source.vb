Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Web.UI
Imports System.Web.UI.WebControls



Public Class Form1
    Inherits Page
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Sub Grid_Change(sender As Object, e As DataGridPageChangedEventArgs)
        Dim page_change_args As New DataGridPageChangedEventArgs(e.CommandSource, e.NewPageIndex)
    End Sub 'Grid_Change
    ' </Snippet1>
End Class 'Form1 

