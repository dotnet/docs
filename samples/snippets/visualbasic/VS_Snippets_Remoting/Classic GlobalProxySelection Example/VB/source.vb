Imports System
Imports System.Net



Public Class Class1
    
    Public Sub Method1()
        ' <Snippet1>
        Dim proxyURI As New Uri("http://webproxy:80")
        GlobalProxySelection.Select = New WebProxy(proxyURI)
        ' </Snippet1>
    End Sub 'Method1 
End Class 'Class1
