        Try
            ' A 'Socket' object has been created.
            Dim httpSocket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            
            ' The IPaddress of the unknown uri is resolved using the 'Dns.Resolve' method. 
	         ' which leads to the 'SocketException' exception. 
            
            Dim hostEntry As IPHostEntry = Dns.Resolve("http://www.contoso.com")
            
            Dim serverAddress As IPAddress = hostEntry.AddressList(0)
            Dim endPoint As New IPEndPoint(serverAddress, 80)
            httpSocket.Connect(endPoint)
            Console.WriteLine("Connection created successfully")
            httpSocket.Close()
        Catch e As SocketException
            Dim exp As [String] = e.Message
            ' Throw the WebException with no parameters.
            Throw New WebException()
        End Try
