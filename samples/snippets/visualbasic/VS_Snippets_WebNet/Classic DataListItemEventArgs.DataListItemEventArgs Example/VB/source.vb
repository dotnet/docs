Imports System.Web.UI
Imports System.Web.UI.WebControls



Public Class Form1
    Inherits Page
    
    ' <Snippet1>
    Sub Item_Created(sender As Object, e As DataListItemEventArgs)
        Dim item_arg As New DataListItemEventArgs(e.Item)
    End Sub
    ' </Snippet1>
End Class
