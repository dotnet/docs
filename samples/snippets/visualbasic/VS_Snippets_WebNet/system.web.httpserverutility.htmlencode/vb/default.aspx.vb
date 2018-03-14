' <snippet1>
Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Result.Text = Server.HtmlEncode("<script>unsafe</script>")
    End Sub
End Class
' </snippet1>