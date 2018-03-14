Imports System
Imports System.Text
Imports System.Net
Imports System.Net.Sockets

Public Class MyTcpClientExample
   
   ' <Snippet1>
   '  MyTcpClientConstructor is just used to illustrate the different constructors available in in the TcpClient class
   Public Shared Sub MyTcpClientConstructor(myConstructorType As String)
      
      If myConstructorType = "IPAddressExample" Then
         ' <Snippet2>
         'Creates a TCPClient using a local endpoint.
         Dim ipAddress As IPAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList(0)
            Dim ipLocalEndPoint As New IPEndPoint(ipAddress, 0)

            Dim tcpClientA As New TcpClient(ipLocalEndPoint)
         
            ' </Snippet2> 
        Else
            If myConstructorType = "HostNameExample" Then
                ' <Snippet3>
                'Creates a TCPClient using hostname and port.

                Dim tcpClientB As New TcpClient("www.contoso.com", 11000)
                
                ' </Snippet3>
            Else
                If myConstructorType = "DefaultExample" Then
                    ' <Snippet4>
                    'Creates a TCPClient using the default constructor.
                    Dim tcpClientC As New TcpClient
                    ' </Snippet4>  
                Else
                    ' <Snippet15>
                    Dim tcpClientD As New TcpClient(AddressFamily.InterNetwork)
                    ' </Snippet15>
                End If ' do nothing
            End If
        End If
    End Sub 'MyTcpClientConstructor
    
   ' MyTcpClientConnection class is just used to illustrate the different connection methods of the TcpClient class.
   Public Shared Sub MyTcpClientConnection(myConnectionType As String)
      
      If myConnectionType = "HostnameExample" Then
         ' <Snippet5>
         'Uses a host name and port number to establish a socket connection.
         Dim tcpClient As New TcpClient()

            tcpClient.Connect("www.contoso.com", 11002)

            ' </Snippet5>
            tcpClient.Close()

        Else
            If myConnectionType = "IPAddressExample" Then
                ' <Snippet6>
                'Uses the IP address and port number to establish a socket connection.
                Dim tcpClient As New TcpClient
                Dim ipAddress As IPAddress = Dns.GetHostEntry("www.contoso.com").AddressList(0)
                tcpClient.Connect(ipAddress, 11003)
                ' </Snippet6>
                tcpClient.Close()
            Else
                If myConnectionType = "RemoteEndPointExample" Then
                    ' <Snippet7>
                    'Uses a remote endpoint to establish a socket connection.
                    Dim tcpClient As New TcpClient
                    Dim ipAddress As IPAddress = Dns.GetHostEntry("www.contoso.com").AddressList(0)
                    Dim ipEndPoint As New IPEndPoint(ipAddress, 11004)

                    tcpClient.Connect(ipEndPoint)
                    
                    ' </Snippet7>
                    tcpClient.Close()
                Else
                End If ' Do nothing.
            End If
        End If
    End Sub 'MyTcpClientConnection

    ' MyTcpClientPropertySetter is just used to illustrate setting and getting various properties of the TcpClient class.
    Public Shared Sub MyTcpClientPropertySetter()

      Dim tcpClient As New TcpClient()
      ' <Snippet8>
      ' Sets the receive buffer size using the ReceiveBufferSize public property.
      tcpClient.ReceiveBufferSize = 1024
      
      ' Gets the receive buffer size using the ReceiveBufferSize public property.
      If tcpClient.ReceiveBufferSize = 1024 Then
         Console.WriteLine(("The receive buffer was successfully set to " + tcpClient.ReceiveBufferSize.ToString()))
      End If
      ' </Snippet8>
      ' <Snippet9>
      'Sets the send buffer size using the SendBufferSize public property.
      tcpClient.SendBufferSize = 1024
      
      ' Gets the send buffer size using the SendBufferSize public property.
      If tcpClient.SendBufferSize = 1024 Then
         Console.WriteLine(("The send buffer was successfully set to " + tcpClient.SendBufferSize.ToString()))
      End If
      ' </Snippet9>
      ' <Snippet10>
      ' Sets the receive time out using the ReceiveTimeout public property.
      tcpClient.ReceiveTimeout = 5
      
      ' Gets the receive time out using the ReceiveTimeout public property.
      If tcpClient.ReceiveTimeout = 5 Then
         Console.WriteLine(("The receive time out limit was successfully set " + tcpClient.ReceiveTimeout.ToString()))
      End If
      ' </Snippet10>
      ' <Snippet11>
      ' Sets the send time out using the SendTimeout public property.
      tcpClient.SendTimeout = 5000
      
      ' Gets the send time out using the SendTimeout public property.
      If tcpClient.SendTimeout = 5000 Then
         Console.WriteLine(("The send time out limit was successfully set " + tcpClient.SendTimeout.ToString()))
      End If
      ' </Snippet11>
      ' <Snippet12>
      ' Sets the amount of time to linger after closing, using the LingerOption public property.
      Dim lingerOption As New LingerOption(True, 10)
      tcpClient.LingerState = lingerOption
      
      ' Gets the amount of linger time set, using the LingerOption public property.
      If tcpClient.LingerState.LingerTime = 10 Then
         Console.WriteLine(("The linger state setting was successfully set to " + tcpClient.LingerState.LingerTime.ToString()))
      End If
      ' </Snippet12>
      ' <Snippet13>
      ' Sends data immediately upon calling NetworkStream.Write.
      tcpClient.NoDelay = True
      
      ' Determines if the delay is enabled by using the NoDelay property.
      If tcpClient.NoDelay = True Then
         Console.WriteLine(("The delay was set successfully to " + tcpClient.NoDelay.ToString()))
      End If
      ' </Snippet13>
      tcpClient.Close()
   End Sub 'MyTcpClientPropertySetter
   
   
   Public Shared Sub MyTcpClientCommunicator()
      
      ' <Snippet14>
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
    ' </Snippet14>
   
   Public Shared Sub Main()
      
      ' Using the default constructor.
      MyTcpClientConstructor("DefaultExample")
      
      ' Establish a connection by using the hostname and port number.
      MyTcpClientConnection("HostnameExample")
      
      ' Set and verify all communication parameters before attempting communication.
      MyTcpClientPropertySetter()
      
      ' Send and receive data using tcpClient class.
      MyTcpClientCommunicator()
   End Sub 'Main 
End Class 'MyTcpClientExample 
' </Snippet1>

'end class


