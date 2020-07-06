'<snippet01>
Imports System.IO
Imports System.IO.Pipes
Imports System.Diagnostics

Class PipeServer
    Shared Sub Main()
        Dim pipeClient As New Process()

        pipeClient.StartInfo.FileName = "pipeClient.exe"

        Using pipeServer As New AnonymousPipeServerStream(PipeDirection.Out, _
            HandleInheritability.Inheritable)

            Console.WriteLine("[SERVER] Current TransmissionMode: {0}.",
                pipeServer.TransmissionMode)

            ' Pass the client process a handle to the server.
            pipeClient.StartInfo.Arguments = pipeServer.GetClientHandleAsString()
            pipeClient.StartInfo.UseShellExecute = false
            pipeClient.Start()

            pipeServer.DisposeLocalCopyOfClientHandle()

            Try
                ' Read user input and send that to the client process.
                Using sw As New StreamWriter(pipeServer)
                    sw.AutoFlush = true
                    ' Send a 'sync message' and wait for client to receive it.
                    sw.WriteLine("SYNC")
                    pipeServer.WaitForPipeDrain()
                    ' Send the console input to the client process.
                    Console.Write("[SERVER] Enter text: ")
                    sw.WriteLine(Console.ReadLine())
                End Using
            Catch e As IOException
                ' Catch the IOException that is raised if the pipe is broken
                ' or disconnected.
                Console.WriteLine("[SERVER] Error: {0}", e.Message)
            End Try
        End Using

        pipeClient.WaitForExit()
        pipeClient.Close()
        Console.WriteLine("[SERVER] Client quit. Server terminating.")
    End Sub
End Class
'</snippet01>
