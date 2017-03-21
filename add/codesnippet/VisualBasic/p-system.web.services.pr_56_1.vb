        Dim math As New MyMath.Math()
        
        ' Set the proxy server to proxyserver, set the port to 80, and specify
        ' to bypass the proxy server for local addresses.
        Dim proxyObject As New WebProxy("http://proxyserver:80", True)
        math.Proxy = proxyObject
        
        ' Call the Add XML Web service method.
        Dim total As Integer = math.Add(8, 5)