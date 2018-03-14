Imports System
Imports System.Net

Public Class Sample  
    
    Private Sub sampleFunction()
        ' <Snippet1>
Dim proxyObject As New WebProxy("http://proxyserver:80/", True)
Dim req As WebRequest = WebRequest.Create("http://www.contoso.com")
req.Proxy = proxyObject

        ' </Snippet1>
    End Sub
End Class
