Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Web.UI
Imports System.Web.UI.WebControls



Public Class Page1
    Inherits Page
    
    ' <Snippet1>
    Sub Item_Created(sender As Object, e As DataGridItemEventArgs)
        Dim DG_event_arg As New DataGridItemEventArgs(e.Item)
    End Sub 'Item_Created
    ' </Snippet1>
End Class 'Page1 
