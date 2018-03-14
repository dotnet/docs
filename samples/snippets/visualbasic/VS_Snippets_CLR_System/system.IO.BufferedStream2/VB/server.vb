' <Snippet1>
' Compile using /r:System.dll.
Imports Microsoft.VisualBasic
Imports System
Imports System.Net
Imports System.Net.Sockets

Public Class Server 

    Shared Sub Main() 
    
        ' This is a Windows Sockets 2 error code.
        Const WSAETIMEDOUT As Integer = 10060

        Dim serverSocket As Socket 
        Dim bytesReceived As Integer
        Dim totalReceived As Integer = 0
        Dim receivedData(2000000-1) As Byte

        ' Create random data to send to the client.
        Dim dataToSend(2000000-1) As Byte
        Dim randomGenerator As New Random()
        randomGenerator.NextBytes(dataToSend)

        Dim ipAddress As IPAddress = _
            Dns.Resolve(Dns.GetHostName()).AddressList(0)

        Dim ipEndpoint As New IPEndPoint(ipAddress, 1800)

        ' Create a socket and listen for incoming connections.
        Dim listenSocket As New Socket(AddressFamily.InterNetwork, _
            SocketType.Stream, ProtocolType.Tcp)
        
        Try
            listenSocket.Bind(ipEndpoint)
            listenSocket.Listen(1)

            ' Accept a connection and create a socket to handle it.
            serverSocket = listenSocket.Accept()
            Console.WriteLine("Server is connected." & vbCrLf)
        Finally
            listenSocket.Close()
        End Try

        Try
            ' Send data to the client.
            Console.Write("Sending data ... ")
            Dim bytesSent As Integer = serverSocket.Send( _
                dataToSend, 0, dataToSend.Length, SocketFlags.None)
            Console.WriteLine("{0} bytes sent." & vbCrLf, _
                bytesSent.ToString())

            ' Set the timeout for receiving data to 2 seconds.
            serverSocket.SetSocketOption(SocketOptionLevel.Socket, _
                SocketOptionName.ReceiveTimeout, 2000)

            ' Receive data from the client.
            Console.Write("Receiving data ... ")
            Try
                Do
                    bytesReceived = serverSocket.Receive( _
                        receivedData, 0, receivedData.Length, _
                        SocketFlags.None)
                    totalReceived += bytesReceived
                Loop While bytesReceived <> 0
            Catch e As SocketException
                If(e.ErrorCode = WSAETIMEDOUT)
                
                    ' Data was not received within the given time.
                    ' Assume that the transmission has ended.
                Else
                    Console.WriteLine("{0}: {1}" & vbCrLf, _
                        e.GetType().Name, e.Message)
                End If
            Finally
                Console.WriteLine("{0} bytes received." & vbCrLf, _
                    totalReceived.ToString())
            End Try
        Finally
            serverSocket.Shutdown(SocketShutdown.Both)
            Console.WriteLine("Connection shut down.")
            serverSocket.Close()
        End Try
    
    End Sub
End Class
' </Snippet1>