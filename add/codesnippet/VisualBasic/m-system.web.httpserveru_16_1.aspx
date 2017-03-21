    Sub Page_Load(ByVal Sender As Object, ByVal e As EventArgs)
        Server.Execute("updateinfo.aspx", True)
    End Sub