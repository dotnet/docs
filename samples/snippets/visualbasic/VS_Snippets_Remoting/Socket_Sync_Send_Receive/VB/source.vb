
Imports System
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading



Public Class Sync_Send_Receive
    
    '<Snippet1>
    ' Displays sending with a connected socket
    ' using the overload that takes a buffer.
    Public Shared Function SendReceiveTest1(ByVal server As Socket) As Integer 
        Dim msg As Byte() = Encoding.UTF8.GetBytes("This is a test")
        Dim bytes(255) As Byte
        Try
            ' Blocks until send returns.
            Dim i As Integer = server.Send(msg)
            Console.WriteLine("Sent {0} bytes.", i)
            
            ' Get reply from the server.
            i = server.Receive(bytes)
            Console.WriteLine(Encoding.UTF8.GetString(bytes))
        Catch e As SocketException
            Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode)
            Return e.ErrorCode
        End Try
        Return 0
    
    End Function 'SendReceiveTest1
    
    '</Snippet1>
    
    ' Displays receiving from a connected tcp socket
    ' using the overload that takes a buffer.
    Public Shared Function ReceiveTest1(ByVal client As Socket) As Integer 
        
        Dim bytes(255) As Byte
        Try
            ' It is usually preferable to use the overload
            ' that allows you to specify the maximum bytes returned.
            If client.Available > 256 Then
                Throw New ApplicationException("This test socket only takes messages < 256 bytes.")
            End If
            ' Blocks until read returns.
            Dim byteCount As Integer = client.Receive(bytes)
            If byteCount > 0 Then
                Console.WriteLine(Encoding.UTF8.GetString(bytes))
            End If 
            ' Send reply to the client.
            client.Send(Encoding.UTF8.GetBytes("Bye."))
        Catch e As SocketException
            Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode)
            Return e.ErrorCode
        End Try
        Return 0
    
    End Function 'ReceiveTest1
    
    
    
    '<Snippet2>
    ' Displays sending with a connected socket
    ' using the overload that takes a buffer and socket flags.
    Public Shared Function SendReceiveTest2(ByVal server As Socket) As Integer 
        Dim msg As Byte() = Encoding.UTF8.GetBytes("This is a test")
        Dim bytes(255) As Byte
        Try
            ' Blocks until send returns.
            Dim byteCount As Integer = server.Send(msg, SocketFlags.None)
            Console.WriteLine("Sent {0} bytes.", byteCount)
            
            ' Get reply from the server.
            byteCount = server.Receive(bytes, SocketFlags.None)
            If byteCount > 0 Then
                Console.WriteLine(Encoding.UTF8.GetString(bytes))
            End If
        Catch e As SocketException
            Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode)
            Return e.ErrorCode
        End Try
        Return 0
    
    End Function 'SendReceiveTest2
    
    '</Snippet2>
    '<Snippet3>
    ' Displays sending with a connected socket
    ' using the overload that takes a buffer, message size, and socket flags.
    Public Shared Function SendReceiveTest3(ByVal server As Socket) As Integer 
        Dim msg As Byte() = Encoding.UTF8.GetBytes("This is a test")
        Dim bytes(255) As Byte
        Try
            ' Blocks until send returns.
            Dim i As Integer = server.Send(msg, msg.Length, SocketFlags.None)
            Console.WriteLine("Sent {0} bytes.", i)
            
            ' Get reply from the server.
            Dim byteCount As Integer = server.Receive(bytes, server.Available, SocketFlags.None)
            If byteCount > 0 Then
                Console.WriteLine(Encoding.UTF8.GetString(bytes))
            End If
        Catch e As SocketException
            Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode)
            Return e.ErrorCode
        End Try
        Return 0
    
    End Function 'SendReceiveTest3
    
    '</Snippet3>
    '<Snippet4>
    ' Displays sending with a connected socket
    ' using the overload that takes a buffer, offset, message size, and socket flags.
    Public Shared Function SendReceiveTest4(ByVal server As Socket) As Integer 
        Dim msg As Byte() = Encoding.UTF8.GetBytes("This is a test")
        Dim bytes(255) As Byte
        Try
            ' Blocks until send returns.
            Dim byteCount As Integer = server.Send(msg, 0, msg.Length, SocketFlags.None)
            Console.WriteLine("Sent {0} bytes.", byteCount)
            
            ' Get reply from the server.
            byteCount = server.Receive(bytes, 0, server.Available, SocketFlags.None)
            
            If byteCount > 0 Then
                Console.WriteLine(Encoding.UTF8.GetString(bytes))
            End If
        Catch e As SocketException
            Console.WriteLine("{0} Error code: {1}.", e.Message, e.ErrorCode)
            Return e.ErrorCode
        End Try
        Return 0
    
    End Function 'SendReceiveTest4
    
    '</Snippet4>
    '<Snippet5>
    Public Shared Sub SendTo1() 
        Dim hostEntry As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
        Dim endPoint As New IPEndPoint(hostEntry.AddressList(0), 11000)
        
        Dim s As New Socket(endPoint.Address.AddressFamily, SocketType.Dgram, ProtocolType.Udp)
        
        Dim msg As Byte() = Encoding.ASCII.GetBytes("This is a test")
        Console.WriteLine("Sending data.")
        ' This call blocks. 
        s.SendTo(msg, endPoint)
        s.Close()
    
    End Sub 'SendTo1
    
    '</Snippet5>
    '<Snippet6>  
    Public Shared Sub SendTo2() 
        Dim hostEntry As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
        Dim endPoint As New IPEndPoint(hostEntry.AddressList(0), 11000)
        
        Dim s As New Socket(endPoint.Address.AddressFamily, SocketType.Dgram, ProtocolType.Udp)
        
        Dim msg As Byte() = Encoding.ASCII.GetBytes("This is a test")
        Console.WriteLine("Sending data.")
        ' This call blocks. 
        s.SendTo(msg, SocketFlags.None, endPoint)
        s.Close()
    
    End Sub 'SendTo2
    
    '</Snippet6>
    '<Snippet7>	
    Public Shared Sub SendTo3() 
        Dim hostEntry As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
        Dim endPoint As New IPEndPoint(hostEntry.AddressList(0), 11000)
        
        Dim s As New Socket(endPoint.Address.AddressFamily, SocketType.Dgram, ProtocolType.Udp)
        
        Dim msg As Byte() = Encoding.ASCII.GetBytes("This is a test")
        Console.WriteLine("Sending data.")
        ' This call blocks. 
        s.SendTo(msg, msg.Length, SocketFlags.None, endPoint)
        s.Close()
    
    End Sub 'SendTo3
    
    '</Snippet7>
    '<Snippet8>
    Public Shared Sub SendTo4() 
        Dim hostEntry As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
        Dim endPoint As New IPEndPoint(hostEntry.AddressList(0), 11000)
        
        Dim s As New Socket(endPoint.Address.AddressFamily, SocketType.Dgram, ProtocolType.Udp)
        
        Dim msg As Byte() = Encoding.ASCII.GetBytes("This is a test")
        Console.WriteLine("Sending data.")
        ' This call blocks. 
        s.SendTo(msg, 0, msg.Length, SocketFlags.None, endPoint)
        s.Close()
    
    End Sub 'SendTo4
    
    
    '</Snippet8>
    ' The ReceiveFroms
    '<Snippet9>
    Public Shared Sub ReceiveFrom1() 
        Dim hostEntry As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
        Dim endPoint As New IPEndPoint(hostEntry.AddressList(0), 11000)
        
        Dim s As New Socket(endPoint.Address.AddressFamily, SocketType.Dgram, ProtocolType.Udp)
        
        ' Creates an IPEndPoint to capture the identity of the sending host.
        Dim sender As New IPEndPoint(IPAddress.Any, 0)
        Dim senderRemote As EndPoint = CType(sender, EndPoint)
        
        ' Binding is required with ReceiveFrom calls.
        s.Bind(endPoint)
        
        Dim msg() As Byte = New [Byte](255) {}
        Console.WriteLine("Waiting to receive datagrams from client...")
        
        ' This call blocks. 
        s.ReceiveFrom(msg, senderRemote)
        s.Close()
    
    End Sub 'ReceiveFrom1
    
    '</Snippet9>
    '<Snippet10>  
    Public Shared Sub ReceiveFrom2() 
        Dim hostEntry As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
        Dim endPoint As New IPEndPoint(hostEntry.AddressList(0), 11000)
        
        Dim s As New Socket(endPoint.Address.AddressFamily, SocketType.Dgram, ProtocolType.Udp)
        
        ' Creates an IpEndPoint to capture the identity of the sending host.
        Dim sender As New IPEndPoint(IPAddress.Any, 0)
        Dim senderRemote As EndPoint = CType(sender, EndPoint)
        
        ' Binding is required with ReceiveFrom calls.
        s.Bind(endPoint)
        
        Dim msg() As Byte = New [Byte](255) {}
        Console.WriteLine("Waiting to receive datagrams from client...")
        ' This call blocks. 
        s.ReceiveFrom(msg, SocketFlags.None, senderRemote)
        s.Close()
    
    End Sub 'ReceiveFrom2
    
    '</Snippet10>
    '<Snippet11>	
    Public Shared Sub ReceiveFrom3() 
        Dim hostEntry As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
        Dim endPoint As New IPEndPoint(hostEntry.AddressList(0), 11000)
        
        Dim s As New Socket(endPoint.Address.AddressFamily, SocketType.Dgram, ProtocolType.Udp)
        
        ' Creates an IPEndPoint to capture the identity of the sending host.
        Dim sender As New IPEndPoint(IPAddress.Any, 0)
        Dim senderRemote As EndPoint = CType(sender, EndPoint)
        
        ' Binding is required with ReceiveFrom calls.
        s.Bind(endPoint)
        
        Dim msg() As Byte = New [Byte](255) {}
        Console.WriteLine("Waiting to receive datagrams from client...")
        ' This call blocks. 
        s.ReceiveFrom(msg, msg.Length, SocketFlags.None, senderRemote)
        s.Close()
    
    End Sub 'ReceiveFrom3
    
    '</Snippet11>
    '<Snippet12>
    Public Shared Sub ReceiveFrom4() 
        Dim hostEntry As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
        Dim endPoint As New IPEndPoint(hostEntry.AddressList(0), 11000)
        
        Dim s As New Socket(endPoint.Address.AddressFamily, SocketType.Dgram, ProtocolType.Udp)
        
        ' Creates an IpEndPoint to capture the identity of the sending host.
        Dim sender As New IPEndPoint(IPAddress.Any, 0)
        Dim senderRemote As EndPoint = CType(sender, EndPoint)
        
        ' Binding is required with ReceiveFrom calls.
        s.Bind(endPoint)
        Dim msg() As Byte = New [Byte](255) {}
        Console.WriteLine("Waiting to receive datagrams from client...")
        ' This call blocks.  
        s.ReceiveFrom(msg, 0, msg.Length, SocketFlags.None, senderRemote)
        s.Close()
    
    End Sub 'ReceiveFrom4
    
    '</Snippet12>
    
    Public Shared Sub RunUdpTests() 
        ' Test the upd versions.
        Dim myThreadDelegate As New ThreadStart(AddressOf Sync_Send_Receive.ReceiveFrom1)
        Dim myThread1 As New Thread(myThreadDelegate)
        myThread1.Start()
        
        While myThread1.IsAlive = True
            SendTo1()
        End While
        myThread1.Join()
        
        Console.WriteLine("UDP test2")
        Dim myThread2 As New Thread(New ThreadStart(AddressOf Sync_Send_Receive.ReceiveFrom2))
        myThread2.Start()
        While myThread2.IsAlive = True
            SendTo2()
        End While
        myThread2.Join()
        
        Console.WriteLine("UDP test3")
        Dim myThread3 As New Thread(New ThreadStart(AddressOf Sync_Send_Receive.ReceiveFrom3))
        myThread3.Start()
        While myThread3.IsAlive = True
            SendTo3()
        End While
        myThread3.Join()
        
        Console.WriteLine("UDP test4")
        Dim myThread4 As New Thread(New ThreadStart(AddressOf Sync_Send_Receive.ReceiveFrom4))
        myThread4.Start()
        While myThread4.IsAlive = True
            SendTo4()
        End While
        myThread4.Join()
    
    End Sub 'RunUdpTests
     
    'Main tests the snippets.
    ' To test tcp - run 2 instances source /s runs server, source /c runs client.
    ' To test Upd run source /u.
    Public Shared Function Main(ByVal args() As String) As Integer 
        Dim host As String
        Dim isServer As Boolean
        
        Dim c As Char = args(0).ToLower()(1)
        If c = "c"c Then
            isServer = False
            host = "127.0.0.1"
        ElseIf c = "u"c Then
            RunUdpTests()
            Return 0
        Else
            host = "localhost"
            isServer = True
        End If 
        ' Set up the endpoint and create the socket.
        Dim hostEntry As IPHostEntry = Dns.GetHostEntry(host)
        Dim endPoint As New IPEndPoint(hostEntry.AddressList(0), 11000)
        
        ' Test the TCPIP snippets (Socket.Send and Socket.Receive)
        Dim s As New Socket(endPoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
        
        ' Send or receive the test messages.
        If isServer Then
            Dim sender As Socket = Nothing
            s.Bind(endPoint)
            s.Listen(1)
            While True
                sender = s.Accept()
                ' exchange messages with all clients tests 
                Dim i As Integer
                For i = 0 To 3
                    ReceiveTest1(sender)
                Next i
                sender.Close()
                s.Close()
                Environment.Exit(0)
            End While
        ' Its the client tcp tests.
        Else
            Try
                s.Connect(endPoint)
                SendReceiveTest1(s)
                SendReceiveTest2(s)
                SendReceiveTest3(s)
                SendReceiveTest4(s)
            Finally
                s.Close()
            End Try
        End If
        
        
        Return 0
    
    End Function 'Main 
End Class 'Sync_Send_Receive

