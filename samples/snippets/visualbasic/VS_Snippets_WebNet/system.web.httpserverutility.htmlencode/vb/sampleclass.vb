' <snippet2>
Public Class SampleClass
    Public Function GetEncodedText() As String
        Return HttpContext.Current.Server.HtmlEncode("<script>unsafe</script>")
    End Function
End Class
' </snippet2>