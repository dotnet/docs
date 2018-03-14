Imports System
Imports System.Net

Public Class Sample
    
    
    Public Shared Sub Main()

        ' <Snippet1>

        Dim myReq As HttpWebRequest = _
            WebRequest.Create("http://www.contoso.com/")

        ' </Snippet1>
    End Sub
End Class

