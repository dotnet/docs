' <Snippet2>
Partial Class cookieparam2vb_aspx
    Inherits System.Web.UI.Page
    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        ' These cookies might be added by a login form.
        ' They are added here for simplicity.
        If (Not IsPostBack) Then
            Dim cookie As HttpCookie

            cookie = New HttpCookie("lname", "davolio")
            Response.Cookies.Add(cookie)

            cookie = New HttpCookie("loginname", "ndavolio")
            Response.Cookies.Add(cookie)

            cookie = New HttpCookie("lastvisit", DateTime.Now.ToString())
            Response.Cookies.Add(cookie)


            ' You can add a CookieParameter to the SqlDataSource control's
            ' SelectParameters collection programmatically.
            Dim cookieParam As New CookieParameter()
            cookieParam.Name = "lastname"
            cookieParam.Type = TypeCode.String
            cookieParam.CookieName = "lname"

            SqlDataSource1.SelectParameters.Add(cookieParam)

        End If
    End Sub ' Page_Load
End Class
' </Snippet2>