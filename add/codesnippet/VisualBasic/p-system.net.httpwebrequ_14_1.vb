            ' Create a new request to the mentioned URL.				
            Dim myWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.microsoft.com"), HttpWebRequest)

			      ' Obtain the 'Proxy' of the  Default browser.  
			      Dim proxy as IWebProxy = CType(myWebRequest.Proxy, IWebProxy)
			      ' Print the Proxy Url to the console.
            If Not proxy Is Nothing Then
                Console.WriteLine("Proxy: {0}", proxy.GetProxy(myWebRequest.RequestUri))
            Else
                Console.WriteLine("Proxy is null; no proxy will be used")
            End If

            Dim myProxy As New WebProxy()

            Console.WriteLine(ControlChars.Cr + "Please enter the new Proxy Address that is to be set ")
            Console.WriteLine("(Example:http://myproxy.example.com:port)")
            Dim proxyAddress As String
            Try
                proxyAddress = Console.ReadLine()
                If proxyAddress.Length = 0 Then
                    myWebRequest.Proxy = myProxy
                Else
                    Console.WriteLine(ControlChars.Cr + "Please enter the Credentials (may not be needed)")
                    Console.WriteLine("Username:")
                    Dim username As String
                    username = Console.ReadLine()
                    Console.WriteLine(ControlChars.Cr + "Password:")
                    Dim password As String
                    password = Console.ReadLine()
                    ' Create a new Uri object.
                    Dim newUri As New Uri(proxyAddress)
                    ' Associate the newUri object to 'myProxy' object so that new myProxy settings can be set.
                    myProxy.Address = newUri
                    ' Create a NetworkCredential object and associate it with the Proxy property of request object.
                    myProxy.Credentials = New NetworkCredential(username, password)
                    myWebRequest.Proxy = myProxy
                End If
                Console.WriteLine(ControlChars.Cr + "The Address of the  new Proxy settings are {0}", myProxy.Address)
                Dim myWebResponse As HttpWebResponse = CType(myWebRequest.GetResponse(), HttpWebResponse)