'<snippet01>
Imports System
Imports System.IO
Imports System.IO.Pipes

Class PipeServer

    Shared Sub Main()
        Dim pipeServer As New NamedPipeServerStream("testpipe", PipeDirection.Out)

        Console.WriteLine("NamedPipeServerStream object created.")

        ' Wait for a client to connect
        Console.Write("Waiting for a client connection...")
        pipeServer.WaitForConnection()

        Console.WriteLine("Client connected.")
        Try
            'Read user input and send that to the client process.
            Dim sw As New StreamWriter(pipeServer)
            sw.AutoFlush = True
            Console.Write("Enter Text: ")
            sw.WriteLine(Console.ReadLine())
        Catch ex As IOException
            ' Catch the IOException that is raised if the pipe is broken
            ' or disconnected
            Console.WriteLine("ERROR: {0}", ex.Message)
        End Try
    End Sub
End Class
'</snippet01>