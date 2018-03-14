' <snippet2>
Public Class SampleClass
    Public Function GetUrl() As String
        Dim destinationURL = "http://www.contoso.com/default.aspx?user=test"

        Return "~/Finish?url=" + HttpContext.Current.Server.UrlEncode(destinationURL)
    End Function
End Class
' </snippet2>