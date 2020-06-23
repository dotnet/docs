' Visual Basic .NET Document
'Option Strict On

' <Snippet8>
Imports System.Threading
Imports System.Threading.Tasks

Module Example
    Public Sub Main()
        Dim cts As New CancellationTokenSource()
        Dim token As CancellationToken = cts.Token
        cts.Cancel()

        Dim t As Task = Task.FromCanceled(token)
        Dim continuation As Task = t.ContinueWith(Sub(antecedent)
                                                      Console.WriteLine("The continuation is running.")
                                                  End Sub, TaskContinuationOptions.NotOnCanceled)
        Try
            t.Wait()
        Catch e As AggregateException
            For Each ie In e.InnerExceptions
                Console.WriteLine("{0}: {1}", ie.GetType().Name, ie.Message)
            Next
            Console.WriteLine()
        Finally
            cts.Dispose()
        End Try

        Console.WriteLine("Task {0}: {1:G}", t.Id, t.Status)
        Console.WriteLine("Task {0}: {1:G}", continuation.Id,
                          continuation.Status)
    End Sub
End Module
' The example displays the following output:
'       TaskCanceledException: A task was canceled.
'
'       Task 1: Canceled
'       Task 2: Canceled
' </Snippet8>
