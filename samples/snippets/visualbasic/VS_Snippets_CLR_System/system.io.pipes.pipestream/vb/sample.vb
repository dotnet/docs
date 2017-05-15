'<snippet1>
Imports System
Imports System.IO
Imports System.IO.Pipes
Imports System.Diagnostics

Class PipeStreamExample
    Private Shared matchSign() As Byte = {9, 0, 9, 0}

    Public Shared Sub Main()
        Dim args() As String = Environment.GetCommandLineArgs()
        If args.Length < 2 Then
            Dim clientProcess As New Process()

            clientProcess.StartInfo.FileName = Environment.CommandLine

            Using pipeServer As New AnonymousPipeServerStream( _
                PipeDirection.In, HandleInheritability.Inheritable)

                ' Pass the client process a handle to the server.
                clientProcess.StartInfo.Arguments = pipeServer.GetClientHandleAsString()
                clientProcess.StartInfo.UseShellExecute = false
                Console.WriteLine("[SERVER] Starting client process...")
                clientProcess.Start()

                pipeServer.DisposeLocalCopyOfClientHandle()

                Try
                    If WaitForClientSign(pipeServer) Then
                        Console.WriteLine("[SERVER] Valid sign code received!")
                    Else
                        Console.WriteLine("[SERVER] Invalid sign code received!")
                    End If
                Catch e As IOException
                    Console.WriteLine("[SERVER] Error: {0}", e.Message)
                End Try
            End Using
            clientProcess.WaitForExit()
            clientProcess.Close()
            Console.WriteLine("[SERVER] Client quit. Server terminating.")
        Else
            Using pipeClient As PipeStream = New AnonymousPipeClientStream(PipeDirection.Out, args(1))
                Try
                    Console.WriteLine("[CLIENT] Sending sign code...")
                    SendClientSign(pipeClient)
                Catch e As IOException
                    Console.WriteLine("[CLIENT] Error: {0}", e.Message)
                End Try
            End Using
            Console.WriteLine("[CLIENT] Terminating.")
        End If
    End Sub

    '<snippet2>
    Private Shared Function WaitForClientSign(inStream As PipeStream) As Boolean
        Dim inSign() As Byte = Array.CreateInstance(GetType(Byte), matchSign.Length)
        Dim len As Integer = inStream.Read(inSign, 0, matchSign.Length)
        Dim valid = len.Equals(matchSign.Length)

        While len > 0
            len -= 1
            valid = valid And (matchSign(len).Equals(inSign(len)))
        End While
        Return valid
    End Function
    '</snippet2>

    Private Shared Sub SendClientSign(outStream As PipeStream)
        outStream.Write(matchSign, 0, matchSign.Length)
    End Sub
End Class
'</snippet1>
