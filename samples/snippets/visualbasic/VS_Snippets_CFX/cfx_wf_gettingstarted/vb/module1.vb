Imports System.Activities
'<snippet3>
Imports System.Threading
'</snippet3>

Module Module1
    '<snippet12>
    Sub Main()
        Dim syncEvent As New AutoResetEvent(False)
        '<snippet8>
        Dim idleEvent As New AutoResetEvent(False)
        '</snippet8>

        '<snippet6>
        Dim inputs As New Dictionary(Of String, Object)
        inputs.Add("MaxNumber", 100)

        Dim wfApp As New WorkflowApplication(New Workflow1(), inputs)
        '</snippet6>

        '<snippet7>
        wfApp.Completed =
            Sub(e As WorkflowApplicationCompletedEventArgs)
                Dim Turns As Integer = Convert.ToInt32(e.Outputs("Turns"))
                Console.WriteLine("Congratulations, you guessed the number in {0} turns.", Turns)

                syncEvent.Set()
            End Sub
        '</snippet7>

        wfApp.Aborted =
            Sub(e As WorkflowApplicationAbortedEventArgs)
                Console.WriteLine(e.Reason)
                syncEvent.Set()
            End Sub

        wfApp.OnUnhandledException =
            Function(e As WorkflowApplicationUnhandledExceptionEventArgs)
                Console.WriteLine(e.UnhandledException)
                Return UnhandledExceptionAction.Terminate
            End Function

        '<snippet9>
        wfApp.Idle =
            Sub(e As WorkflowApplicationIdleEventArgs)
                idleEvent.Set()
            End Sub
        '</snippet9>

        wfApp.Run()

        '<snippet11>
        ' Loop until the workflow completes.
        Dim waitHandles As WaitHandle() = New WaitHandle() {syncEvent, idleEvent}
        Do While WaitHandle.WaitAny(waitHandles) <> 0
            'Gather the user input and resume the bookmark.
            Dim validEntry As Boolean = False
            Do While validEntry = False
                Dim Guess As Integer
                If Int32.TryParse(Console.ReadLine(), Guess) = False Then
                    Console.WriteLine("Please enter an integer.")
                Else
                    validEntry = True
                    wfApp.ResumeBookmark("EnterGuess", Guess)
                End If
            Loop
        Loop
        '</snippet11>
    End Sub
    '</snippet12>
End Module
