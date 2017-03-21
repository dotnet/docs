
        Try
            ' A 'Socket' object has been created.
            Dim httpSocket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            
            ' The IPaddress of the unknown uri is resolved using the 'Dns.Resolve' method. 
 	         
            Dim hostEntry As IPHostEntry = Dns.Resolve(connectUri)
            
            Dim serverAddress As IPAddress = hostEntry.AddressList(0)
            Dim endPoint As New IPEndPoint(serverAddress, 80)
            httpSocket.Connect(endPoint)
            Console.WriteLine("Connection created successfully")
            httpSocket.Close()
        Catch e As SocketException
            Console.WriteLine((ControlChars.Cr + "Exception thrown." + ControlChars.Cr + "The Original Message is: " + e.Message))
            ' Throw the 'WebException' object with a message string specific to the situation.
            Throw New WebException("Unable to locate the Server with 'www.contoso.com' Uri.")
        End Try