'<snippet02>
Imports System.Threading
Imports System.Threading.Tasks

Module Test
    Sub Main()
        Dim tokenSource2 As New CancellationTokenSource()
        Dim ct As CancellationToken = tokenSource2.Token

        Dim t2 = Task.Factory.StartNew(Sub()
                                           ' Were we already canceled?
                                           ct.ThrowIfCancellationRequested()

                                           Dim moreToDo As Boolean = True
                                           While moreToDo = True
                                               ' Poll on this property if you have to do
                                               ' other cleanup before throwing.
                                               If ct.IsCancellationRequested Then

                                                   ' Clean up here, then...
                                                   ct.ThrowIfCancellationRequested()
                                               End If

                                           End While
                                       End Sub _
        , tokenSource2.Token) ' Pass same token to StartNew.

        ' Cancel the task.
        tokenSource2.Cancel()

        ' Just continue on this thread, or Wait/WaitAll with try-catch:
        Try
            t2.Wait()

        Catch e As AggregateException

            For Each item In e.InnerExceptions
                Console.WriteLine(e.Message & " " & item.Message)
            Next
        Finally
            tokenSource2.Dispose()
        End Try

        Console.ReadKey()
    End Sub
End Module
'</snippet02>
