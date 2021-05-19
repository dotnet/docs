'<snippet01>
Imports System.IO
Imports System.IO.Pipes
Imports System.Text
Imports System.Threading

Public Class PipeServer
    Private Shared numThreads As Integer = 4

    Public Shared Sub Main()
        Dim i As Integer
        Dim servers(numThreads) As Thread

        Console.WriteLine(vbCrLf + "*** Named pipe server stream with impersonation example ***" + vbCrLf)
        Console.WriteLine("Waiting for client connect..." + vbCrLf)
        For i = 0 To numThreads - 1
            servers(i) = New Thread(AddressOf ServerThread)
            servers(i).Start()
        Next i
        Thread.Sleep(250)
        While i > 0
            For j As Integer = 0 To numThreads - 1
                If Not (servers(j) Is Nothing) Then
                    If servers(j).Join(250) Then
                        Console.WriteLine("Server thread[{0}] finished.", servers(j).ManagedThreadId)
                        servers(j) = Nothing
                        i -= 1    ' decrement the thread watch count
                    End If
                End If
            Next j
        End While
        Console.WriteLine(vbCrLf + "Server threads exhausted, exiting.")
    End Sub

    Private Shared Sub ServerThread(data As Object)
        Dim pipeServer As New _
            NamedPipeServerStream("testpipe", PipeDirection.InOut, numThreads)

        Dim threadId As Integer = Thread.CurrentThread.ManagedThreadId

        ' Wait for a client to connect
        pipeServer.WaitForConnection()

        Console.WriteLine("Client connected on thread[{0}].", threadId)
        Try
            '<snippet2>
            ' Read the request from the client. Once the client has
            ' written to the pipe its security token will be available.

            Dim ss As new StreamString(pipeServer)

            ' Verify our identity to the connected client using a
            ' string that the client anticipates.

            ss.WriteString("I am the one true server!")
            Dim filename As String = ss.ReadString()

            ' Read in the contents of the file while impersonating the client.
            Dim fileReader As New ReadFileToStream(ss, filename)

            ' Display the name of the user we are impersonating.
            Console.WriteLine("Reading file: {0} on thread[{1}] as user: {2}.",
                filename, threadId, pipeServer.GetImpersonationUserName())
            pipeServer.RunAsClient(AddressOf fileReader.Start)
            '</snippet2>
            ' Catch the IOException that is raised if the pipe is broken
            ' or disconnected.
        Catch e As IOException
            Console.WriteLine("ERROR: {0}", e.Message)
        End Try
        pipeServer.Close()
    End Sub
End Class

' Defines the data protocol for reading and writing strings on our stream
Public Class StreamString
    Private ioStream As Stream
    Private streamEncoding As UnicodeEncoding

    Public Sub New(ioStream As Stream)
        Me.ioStream = ioStream
        streamEncoding = New UnicodeEncoding(False, False)
    End Sub

    Public Function ReadString() As String
        Dim len As Integer = 0
        len = CType(ioStream.ReadByte(), Integer) * 256
        len += CType(ioStream.ReadByte(), Integer)
        Dim inBuffer As Array = Array.CreateInstance(GetType(Byte), len)
        ioStream.Read(inBuffer, 0, len)

        Return streamEncoding.GetString(CType(inBuffer, Byte()))
    End Function

    Public Function WriteString(outString As String) As Integer
        Dim outBuffer() As Byte = streamEncoding.GetBytes(outString)
        Dim len As Integer = outBuffer.Length
        If len > UInt16.MaxValue Then
            len = CType(UInt16.MaxValue, Integer)
        End If
        ioStream.WriteByte(CType(len \ 256, Byte))
        ioStream.WriteByte(CType(len And 255, Byte))
        ioStream.Write(outBuffer, 0, outBuffer.Length)
        ioStream.Flush()

        Return outBuffer.Length + 2
    End Function
End Class

' Contains the method executed in the context of the impersonated user
Public Class ReadFileToStream
    Private fn As String
    Private ss As StreamString

    Public Sub New(str As StreamString, filename As String)
        fn = filename
        ss = str
    End Sub

    Public Sub Start()
        Dim contents As String = File.ReadAllText(fn)
        ss.WriteString(contents)
    End Sub
End Class
'</snippet01>
