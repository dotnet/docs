' <snippet2>
Public Class SampleClass
    Public Function GetFilePath() As String
        Return HttpContext.Current.Server.MapPath("/UploadedFiles")
    End Function
End Class
' </snippet2>