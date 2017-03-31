' <snippet1>
Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim pathToFiles = Server.MapPath("/UploadedFiles")
    End Sub
End Class
' </snippet1>