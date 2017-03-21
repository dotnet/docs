Dim proxyObject As New WebProxy("http://proxyserver:80/", True)
Dim req As WebRequest = WebRequest.Create("http://www.contoso.com")
req.Proxy = proxyObject
