                  ' Accepts the pending client connection and returns a socket for communciation.
                  Dim socket As Socket = tcpListener.AcceptSocket()
                  Console.WriteLine("Connection accepted.")
                  
                  Dim responseString As String = "You have successfully connected to me"
                  
                  'Forms and sends a response string to the connected client.
                  Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes(responseString)
                  Dim i As Integer = socket.Send(sendBytes)
                  Console.WriteLine(("Message Sent /> : " + responseString))