Imports System.Threading

' <LinkedTokenBasic>
Public Module LinkedTokenBasicDemo
    Public Async Function RunAsync(userToken As CancellationToken) As Task
        Using timeoutCts = New CancellationTokenSource(TimeSpan.FromMilliseconds(150)),
            linkedCts = CancellationTokenSource.CreateLinkedTokenSource(userToken, timeoutCts.Token)

            Await Task.Delay(500, linkedCts.Token)
        End Using
    End Function
End Module
' </LinkedTokenBasic>

' <LinkedTokenHelper>
Public Module TimeoutPolicy
    Public Async Function ExecuteWithLinkedTimeoutAsync(
        operation As Func(Of CancellationToken, Task),
        timeout As TimeSpan,
        userToken As CancellationToken) As Task

        Using timeoutCts = New CancellationTokenSource(timeout),
            linkedCts = CancellationTokenSource.CreateLinkedTokenSource(userToken, timeoutCts.Token)

            Await operation(linkedCts.Token)
        End Using
    End Function
End Module
' </LinkedTokenHelper>

' <WaitAsyncAlternative>
Public Module WaitOnlyTimeoutDemo
    Public Async Function RunAsync(userToken As CancellationToken) As Task
        Dim operation As Task = Task.Delay(500)

        Try
            Await operation.WaitAsync(TimeSpan.FromMilliseconds(100), userToken)
            Console.WriteLine("Operation completed before timeout.")
        Catch ex As TimeoutException
            Console.WriteLine("Timed out waiting without canceling operation.")
        Catch ex As OperationCanceledException
            Console.WriteLine("Canceled waiting because the caller token was canceled.")
        End Try
    End Function
End Module
' </WaitAsyncAlternative>

Module Program
    Sub Main()
        Console.WriteLine("=== Linked token basic ===")
        Using userCts = New CancellationTokenSource()
            Try
                LinkedTokenBasicDemo.RunAsync(userCts.Token).Wait()
            Catch ex As AggregateException When TypeOf ex.InnerException Is OperationCanceledException
                Console.WriteLine("Canceled by timeout or caller token.")
            End Try
        End Using

        Console.WriteLine()
        Console.WriteLine("=== Linked token helper ===")
        Using userCts = New CancellationTokenSource()
            Try
                TimeoutPolicy.ExecuteWithLinkedTimeoutAsync(
                    Async Function(token)
                        Await Task.Delay(500, token)
                    End Function,
                    TimeSpan.FromMilliseconds(120),
                    userCts.Token).Wait()
            Catch ex As AggregateException When TypeOf ex.InnerException Is OperationCanceledException
                Console.WriteLine("Helper canceled operation as expected.")
            End Try
        End Using

        Console.WriteLine()
        Console.WriteLine("=== WaitAsync alternative ===")
        Using userCts = New CancellationTokenSource()
            WaitOnlyTimeoutDemo.RunAsync(userCts.Token).Wait()
        End Using

        Console.WriteLine()
        Console.WriteLine("Done.")
    End Sub
End Module
