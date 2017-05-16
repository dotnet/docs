Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class Page1
    Inherits Page
    
' <Snippet1>
 Sub Page_Load(sender As Object, e As EventArgs)
     Dim index As Integer = 0
     Dim myItem As New RepeaterItem(index, ListItemType.Item)
 End Sub

' </Snippet1>
End Class

