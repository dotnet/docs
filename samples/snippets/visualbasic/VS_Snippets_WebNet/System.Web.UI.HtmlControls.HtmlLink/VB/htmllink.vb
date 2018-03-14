' <snippet2>
Partial Class HtmlLinkvb_aspx

    Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)

        ' Create an instance of HtmlLink.
        Dim myHtmlLink As HtmlLink = New HtmlLink()
        myHtmlLink.Href = "StyleSheet.css"
        myHtmlLink.Attributes.Add("rel", "stylesheet")
        myHtmlLink.Attributes.Add("type", "text/css")

        ' Add the instance of HtmlLink to the <HEAD> section of the page.
        head1.Controls.Add(myHtmlLink)

    End Sub

End Class
' </snippet2>
