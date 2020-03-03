
Partial Class Sales
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '<Snippet170>
        If Page.RouteData.Values("locale") Is Nothing Then
            LocaleLiteral.Text = "All locales"
        Else
            LocaleLiteral.Text = Page.RouteData.Values("locale").ToString()
        End If
        '</Snippet170>

        '<Snippet171>
        YearLiteral.Text = Page.RouteData.Values("year").ToString()
        '</Snippet171>

    End Sub
End Class
