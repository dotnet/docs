'<snippet1>
Imports System.Diagnostics

Class PrintProcessClass

    Private WithEvents myProcess As Process
    Private eventHandled As TaskCompletionSource(Of Boolean)

    ' Print a file with any known extension.
    Async Function PrintDoc(ByVal fileName As String) As Task

        eventHandled = New TaskCompletionSource(Of Boolean)()
        myProcess = New Process
        Using myProcess
            Try
                ' Start a process to print a file and raise an event when done.
                myProcess.StartInfo.FileName = fileName
                myProcess.StartInfo.Verb = "Print"
                myProcess.StartInfo.CreateNoWindow = True
                myProcess.EnableRaisingEvents = True
                AddHandler myProcess.Exited, New EventHandler(AddressOf myProcess_Exited)
                myProcess.Start()

            Catch ex As Exception
                Console.WriteLine("An error occurred trying to print ""{0}"":" &
                vbCrLf & ex.Message, fileName)
                Return
            End Try

            ' Wait for Exited event, but not more than 30 seconds.
            Await Task.WhenAny(eventHandled.Task, Task.Delay(30000))
        End Using
    End Function

    ' Handle Exited event and display process information.
    Private Sub myProcess_Exited(ByVal sender As Object,
            ByVal e As System.EventArgs)

        Console.WriteLine("Exit time:    {0}" & vbCrLf &
            "Exit code:    {1}" & vbCrLf & "Elapsed time: {2}",
            myProcess.ExitTime, myProcess.ExitCode,
            Math.Round((myProcess.ExitTime - myProcess.StartTime).TotalMilliseconds))
        eventHandled.TrySetResult(True)
    End Sub

    Shared Sub Main(ByVal args As String())

        ' Verify that an argument has been entered.
        If args.Length <= 0 Then
            Console.WriteLine("Enter a file name.")
            Return
        End If

        ' Create the process and print the document.
        Dim myPrintProcess As New PrintProcessClass
        myPrintProcess.PrintDoc(args(0)).Wait()

    End Sub
End Class
'</snippet1>
