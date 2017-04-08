Imports System
Imports System.Data
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections



Public Class Form1
    Inherits Page
    Protected ItemsGrid As DataGrid
    
    ' <Snippet1>
    Sub Page_Init(sender As Object, e As EventArgs)
        Dim myList As New ArrayList()
        Dim myColumnCollection As New DataGridColumnCollection(ItemsGrid, myList)
    End Sub 'Page_Init
    ' </Snippet1>
End Class 'Form1 

