
Partial Class _Default
    Inherits System.Web.UI.Page

    ' <Snippet51>
    ' The Handles keyword binds Page_Load to the Load event.
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Write("Hello world")
    End Sub
    ' </Snippet51>
End Class
