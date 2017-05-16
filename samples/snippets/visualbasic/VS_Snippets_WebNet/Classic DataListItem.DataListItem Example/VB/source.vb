Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls



Public Class Form1
    Inherits Page
    
    ' <Snippet1>
    Sub Page_Load(sender As Object, e As EventArgs)
        Dim index As Integer = 0
        Dim myItem As New DataListItem(index, ListItemType.Item)
    End Sub 'Page_Load
    ' </Snippet1>
End Class 'Form1 

