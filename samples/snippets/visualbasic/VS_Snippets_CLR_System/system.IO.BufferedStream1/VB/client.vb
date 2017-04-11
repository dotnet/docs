' <Snippet1>
' Compile using /r:System.dll.
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Globalization
Imports System.Net
Imports System.Net.Sockets

Public Class Client 

    Const dataArraySize As Integer    =   100
    Const streamBufferSize As Integer =  1000
    Const numberOfLoops As Integer    = 10000

    Shared Sub Main(args As String()) 
    
        ' Check that an argument was specified when the 
        ' program was invoked.
        If args.Length = 0 Then
            Console.WriteLine("Error: The name of the host " & _
                "computer must be specified when the program " & _ 
                "is invoked.")
            Return
        End If

        Dim remoteName As String = args(0)

        ' Create the underlying socket and connect to the server.
        Dim clientSocket As New Socket(AddressFamily.InterNetwork, _
            SocketType.Stream, ProtocolType.Tcp)

        clientSocket.Connect(New IPEndPoint( _
            Dns.Resolve(remoteName).AddressList(0), 1800))

        Console.WriteLine("Client is connected." & vbCrLf)

        ' <Snippet2>
        ' Create a NetworkStream that owns clientSocket and then 
        ' create a BufferedStream on top of the NetworkStream.
        Dim netStream As New NetworkStream(clientSocket, True)
        Dim bufStream As New _
            BufferedStream(netStream, streamBufferSize)
        ' </Snippet2>
        
        Try
            ' <Snippet3>
            ' Check whether the underlying stream supports seeking.
            If bufStream.CanSeek Then
                Console.WriteLine("NetworkStream supports" & _
                    "seeking." & vbCrLf)
            Else
                Console.WriteLine("NetworkStream does not " & _
                    "support seeking." & vbCrLf)
            End If
            ' </Snippet3>

            ' Send and receive data.
            ' <Snippet4>
            If bufStream.CanWrite Then
                SendData(netStream, bufStream)
            End If            
            ' </Snippet4>
            ' <Snippet5>
            If bufStream.CanRead Then
                ReceiveData(netStream, bufStream)
            End If
            ' </Snippet5>
        Finally

            ' <Snippet8>
            ' When bufStream is closed, netStream is in turn 
            ' closed, which in turn shuts down the connection 
            ' and closes clientSocket.
            Console.WriteLine(vbCrLf & "Shutting down the connection.")
            bufStream.Close()
            ' </Snippet8>
        End Try
    End Sub

    Shared Sub SendData(netStream As Stream, bufStream As Stream)
    
        Dim startTime As DateTime 
        Dim networkTime As Double, bufferedTime As Double 

        ' Create random data to send to the server.
        Dim dataToSend(dataArraySize - 1) As Byte
        Dim randomGenerator As New Random()
        randomGenerator.NextBytes(dataToSend)

        ' Send the data using the NetworkStream.
        Console.WriteLine("Sending data using NetworkStream.")
        startTime = DateTime.Now
        For i As Integer = 1 To numberOfLoops
            netStream.Write(dataToSend, 0, dataToSend.Length)
        Next i
        networkTime = DateTime.Now.Subtract(startTime).TotalSeconds
        Console.WriteLine("{0} bytes sent in {1} seconds." & vbCrLf, _
            numberOfLoops * dataToSend.Length, _
            networkTime.ToString("F1"))

        ' <Snippet6>
        ' Send the data using the BufferedStream.
        Console.WriteLine("Sending data using BufferedStream.")
        startTime = DateTime.Now
        For i As Integer = 1 To numberOfLoops
            bufStream.Write(dataToSend, 0, dataToSend.Length)
        Next i
        
        bufStream.Flush()
        bufferedTime = DateTime.Now.Subtract(startTime).TotalSeconds
        Console.WriteLine("{0} bytes sent In {1} seconds." & vbCrLf, _
            numberOfLoops * dataToSend.Length, _
            bufferedTime.ToString("F1"))
        ' </Snippet6>

        ' Print the ratio of write times.
        Console.Write("Sending data using the buffered " & _
            "network stream was {0}", _
            (networkTime/bufferedTime).ToString("P0"))
        If bufferedTime < networkTime Then
            Console.Write(" faster")
        Else
            Console.Write(" slower")
        End If
        Console.WriteLine(" than using the network stream alone.")
    End Sub

    Shared Sub ReceiveData(netStream As Stream, bufStream As Stream)
    
        Dim startTime As DateTime 
        Dim networkTime As Double, bufferedTime As Double = 0

        Dim bytesReceived As Integer = 0
        Dim receivedData(dataArraySize - 1) As Byte

        ' Receive data using the NetworkStream.
        Console.WriteLine("Receiving data using NetworkStream.")
        startTime = DateTime.Now
        While bytesReceived < numberOfLoops * receivedData.Length
            bytesReceived += netStream.Read( _
                receivedData, 0, receivedData.Length)
        End While
        networkTime = DateTime.Now.Subtract(startTime).TotalSeconds
        Console.WriteLine("{0} bytes received in {1} " & _
            "seconds." & vbCrLf, _
            bytesReceived.ToString(), _
            networkTime.ToString("F1"))

        ' <Snippet7>
        ' Receive data using the BufferedStream.
        Console.WriteLine("Receiving data using BufferedStream.")
        bytesReceived = 0
        startTime = DateTime.Now

        Dim numBytesToRead As Integer = receivedData.Length
        Dim n As Integer
        Do While numBytesToRead > 0

            'Read my return anything from 0 to numBytesToRead
            n = bufStream.Read(receivedData, 0, receivedData.Length)
            'The end of the file is reached.
            If n = 0 Then
                Exit Do
            End If

            bytesReceived += n
            numBytesToRead -= n
        Loop

        bufferedTime = DateTime.Now.Subtract(startTime).TotalSeconds
        Console.WriteLine("{0} bytes received in {1} " & _
            "seconds." & vbCrLf, _
            bytesReceived.ToString(), _
            bufferedTime.ToString("F1"))
        ' </Snippet7>

        ' Print the ratio of read times.
        Console.Write("Receiving data using the buffered " & _
            "network stream was {0}", _
            (networkTime/bufferedTime).ToString("P0"))
        If bufferedTime < networkTime Then
            Console.Write(" faster")
        Else
            Console.Write(" slower")
        End If
        Console.WriteLine(" than using the network stream alone.")
    End Sub
End Class
' </Snippet1>