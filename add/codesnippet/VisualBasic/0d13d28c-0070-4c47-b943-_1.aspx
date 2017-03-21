    Sub Page_Load(ByVal Sender As Object, ByVal e As EventArgs)
        Dim writer As System.IO.StringWriter = New System.IO.StringWriter()
        Server.Execute("Login.aspx", writer, True)
        Response.Write("<h3>Please Login:</h3><br />" + writer.ToString())
    End Sub