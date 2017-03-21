 
   	  ' Send the data. 
        Dim ASCII As Encoding = Encoding.ASCII
        Dim requestPage As String = "GET /nhjj.htm HTTP/1.1" + ControlChars.Lf + ControlChars.Cr + "Host: " + connectUri + ControlChars.Lf + ControlChars.Cr + "Connection: Close" + ControlChars.Lf + ControlChars.Cr + ControlChars.Lf + ControlChars.Cr
        Dim byteGet As [Byte]() = ASCII.GetBytes(requestPage)
        Dim recvBytes(256) As [Byte]
        
        ' Create an 'IPEndPoint' object.
        Dim hostEntry As IPHostEntry = Dns.Resolve(connectUri)
        Dim serverAddress As IPAddress = hostEntry.AddressList(0)
        Dim endPoint As New IPEndPoint(serverAddress, 80)
        
        ' Create a 'Socket' object  for sending data.
        Dim connectSocket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        
        ' Connect to host using 'IPEndPoint' object.
        connectSocket.Connect(endPoint)
        
        ' Sent the 'requestPage' text to the host.
        connectSocket.Send(byteGet, byteGet.Length, 0)
        
        ' Receive the information sent by the server.
        Dim bytesReceived As Int32 = connectSocket.Receive(recvBytes, recvBytes.Length, 0)
        Dim headerString As [String] = ASCII.GetString(recvBytes, 0, bytesReceived)
       
        ' Check whether 'status 404' is there or not in the information sent by server.
        If headerString.IndexOf("404") <> False Then
            bytesReceived = connectSocket.Receive(recvBytes, recvBytes.Length, 0)
            Dim memoryStream As New MemoryStream(recvBytes)
            getStream = CType(memoryStream, Stream)
            
            ' Create a 'WebResponse' object.
            Dim myWebResponse As WebResponse = CType(New HttpConnect(getStream), WebResponse)
            Dim myException As New Exception("File Not found")
            
            ' Throw the 'WebException' object with a message string, message status,InnerException and WebResponse.
            Throw New WebException("The Requested page is not found.", myException, WebExceptionStatus.ProtocolError, myWebResponse)
        End If 

        connectSocket.Close()
      
