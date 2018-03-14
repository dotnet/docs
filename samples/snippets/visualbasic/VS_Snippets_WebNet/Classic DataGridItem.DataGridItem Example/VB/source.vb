Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Web.UI
Imports System.Web.UI.WebControls



Public Class Page1
    Inherits Page
    
    ' <Snippet1>
    Sub Page_Load(sender As Object, e As EventArgs)
        Dim index As Integer = 0
        Dim setindex As Integer = 1
        Dim myItem As New DataGridItem(index, setindex, ListItemType.Item)
    End Sub 'Page_Load
    ' </Snippet1>
End Class 'Page1 
