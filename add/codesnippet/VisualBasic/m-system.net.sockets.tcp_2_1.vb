      Dim tcpClient As New TcpClient()
      ' Uses the GetStream public method to return the NetworkStream.

         Dim netStream As NetworkStream = tcpClient.GetStream()
         If netStream.CanWrite Then
            Dim sendBytes As [Byte]() = Encoding.UTF8.GetBytes("Is anybody there?")
            netStream.Write(sendBytes, 0, sendBytes.Length)
         Else
            Console.WriteLine("You cannot write data to this stream.")
            tcpClient.Close()
            ' Closing the tcpClient instance does not close the network stream.
            netStream.Close()
            Return
         End If
         If netStream.CanRead Then
            
            ' Reads the NetworkStream into a byte buffer.
            Dim bytes(tcpClient.ReceiveBufferSize) As Byte
            ' Read can return anything from 0 to numBytesToRead. 
            ' This method blocks until at least one byte is read.
            netStream.Read(bytes, 0, CInt(tcpClient.ReceiveBufferSize))
            
            ' Returns the data received from the host to the console.
            Dim returndata As String = Encoding.ASCII.GetString(bytes)
            Console.WriteLine(("This is what the host returned to you: " + returndata))
         Else
            Console.WriteLine("You cannot read data from this stream.")
            tcpClient.Close()
            ' Closing the tcpClient instance does not close the network stream.
            netStream.Close()
            Return
         End If
 
      ' Uses the Close public method to close the network stream and socket.
      tcpClient.Close()
   End Sub 'MyTcpClientCommunicator