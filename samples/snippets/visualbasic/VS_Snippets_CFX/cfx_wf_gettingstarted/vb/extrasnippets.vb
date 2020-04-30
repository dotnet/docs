Imports System.Activities
Imports System.Threading
'<snippet14>
Imports System.Activities.DurableInstancing
'</snippet14>

Public Class ExtraSnippets
    Sub snippet2()
        '<snippet2>
        WorkflowInvoker.Invoke(New Workflow1())
        '</snippet2>
    End Sub

    Sub snippet4()
        '<snippet4>
        Dim syncEvent As New AutoResetEvent(False)

        Dim wfApp As New WorkflowApplication(New Workflow1())

        wfApp.Completed = _
            Sub(e As WorkflowApplicationCompletedEventArgs)
                syncEvent.Set()
            End Sub

        wfApp.Aborted = _
            Sub(e As WorkflowApplicationAbortedEventArgs)
                Console.WriteLine(e.Reason)
                syncEvent.Set()
            End Sub

        wfApp.OnUnhandledException = _
            Function(e As WorkflowApplicationUnhandledExceptionEventArgs)
                Console.WriteLine(e.UnhandledException)
                Return UnhandledExceptionAction.Terminate
            End Function

        wfApp.Run()

        '<snippet10>
        syncEvent.WaitOne()
        '</snippet10>
        '</snippet4>
    End Sub

    Sub Step4Snippets()
        Dim idleEvent As New AutoResetEvent(False)

        '<snippet13>
        Const connectionString As String = "Server=.\\SQLEXPRESS;Initial Catalog=Persistence;Integrated Security=SSPI"
        '</snippet13>

        '<snippet15>
        Dim inputs As New Dictionary(Of String, Object)
        inputs.Add("MaxNumber", 100)

        Dim wfApp As New WorkflowApplication(New Workflow1(), inputs)

        Dim store As New SqlWorkflowInstanceStore(connectionString)
        wfApp.InstanceStore = store
        '</snippet15>

        '<snippet16>
        ' Replace the Idle handler with a PersistableIdle handler.
        'wfApp.Idle = _
        '    Sub(e As WorkflowApplicationIdleEventArgs)
        '        idleEvent.Set()
        '    End Sub

        wfApp.PersistableIdle = _
            Function(e As WorkflowApplicationIdleEventArgs)
                idleEvent.Set()
                Return PersistableIdleAction.Persist
            End Function
        '</snippet16>

        '<snippet17>
        Console.WriteLine("Press any key to continue . . .")
        Console.ReadKey()
        '</snippet17>
    End Sub
End Class
