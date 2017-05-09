'<snippet01>
Imports System
Imports System.IO
Imports System.IO.Pipes

Class PipeClient

    Shared Sub Main(ByVal args As String())
        If (args.Length > 0) Then

            Using pipeClient As New AnonymousPipeClientStream(args(0))

                Console.WriteLine("Current TransmissionMode: {0}.", _
                   pipeClient.TransmissionMode)

                ' Anonymous Pipes do not support Message mode.
                Try
                    Console.WriteLine("Setting ReadMode to 'Message'.")
                    pipeClient.ReadMode = PipeTransmissionMode.Message
                Catch e As NotSupportedException
                    Console.WriteLine("EXCEPTION: {0}", e.Message)
                End Try

                Using sr As New StreamReader(pipeClient)

                    ' Display the read text to the console
                    Dim temp As String
                    temp = sr.ReadLine()
                    While Not temp = Nothing
                        Console.WriteLine(temp)
                        temp = sr.ReadLine()
                    End While
                End Using
            End Using
        End If
        Console.Write("Press Enter to continue...")
        Console.ReadLine()
    End Sub
End Class
'</snippet01>
