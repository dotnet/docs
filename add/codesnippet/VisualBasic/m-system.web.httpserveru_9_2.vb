Public Class SampleClass
    Public Function RetrievePassedUrl() As String
        Return HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.QueryString("url"))
    End Function
End Class