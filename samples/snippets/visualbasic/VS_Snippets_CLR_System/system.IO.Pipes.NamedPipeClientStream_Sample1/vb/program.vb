'<snippet01>
Imports System
Imports System.IO
Imports System.IO.Pipes
Imports System.Security.Principal

Class PipeClient

    Shared Sub Main(ByVal args As String())

        Dim pipeClient As New NamedPipeClientStream("localhost", _
                    "testpipe", PipeDirection.In, PipeOptions.None)

        ' Connect to the pipe or wait until the pipe is available.
        Console.WriteLine("Attempting to connect to the pipe...")
        pipeClient.Connect()

        Console.WriteLine("Connect to the pipe.")
        Console.WriteLine("There are currently {0} pipe server instances open.", _
                          pipeClient.NumberOfServerInstances)

        Dim sr As New StreamReader(pipeClient)
        Dim temp As String

        temp = sr.ReadLine()
        While Not temp Is Nothing
            Console.WriteLine("Received from server: {0}", temp)
            temp = sr.ReadLine()
        End While
        Console.Write("Press Enter to continue...")
        Console.ReadLine()
    End Sub
End Class
'</snippet01>
