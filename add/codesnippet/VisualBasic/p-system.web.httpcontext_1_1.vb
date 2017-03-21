    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (User.Identity.IsAuthenticated) Then
            Page.Title = "Home page for " + User.Identity.Name
        Else
            Page.Title = "Home page for guest user."
        End If
    End Sub