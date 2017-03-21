    Private Sub Page_Load(sender As Object, e As EventArgs)
        ' Check whether the current request has been
        ' authenticated. If it has not, redirect the 
        ' user to the Login.aspx page.
        If (Request.IsAuthenticated = False) Then
            Response.Redirect("Login.aspx")
        End If
    End Sub