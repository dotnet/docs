Imports System.Threading
Imports System.Threading.Tasks
Imports System.IO

Module continuations
    Public Sub Main
    End Sub
    
    Class Program

        Shared Sub MultiTaskContinuations()
            Dim cts = New CancellationTokenSource()

            Task.Factory.StartNew(Sub()
                                      Console.WriteLine("Press c to cancel")
                                      If Console.ReadKey().KeyChar = "c"c Then
                                          cts.Cancel()
                                      End If
                                  End Sub)

            Dim task1 As Task(Of Integer) = New Task(Of Integer)(Function()
                                                                     ' Do some work...
                                                                     Return 34
                                                                 End Function)

            Dim task2 As Task(Of Integer) = New Task(Of Integer)(Function()
                                                                     ' Do some work...
                                                                     Return 8
                                                                 End Function)

            Dim tasks() As Task(Of Integer) = {task1, task2}

            Dim continuation = Task.Factory.ContinueWhenAll(tasks, Sub(antecedents)
                                                                       Dim answer As Integer = antecedents(0).Result + antecedents(1).Result
                                                                       Console.WriteLine("The answer is {0}", answer)


                                                                   End Sub)
            task1.Start()
            task2.Start()
            continuation.Wait()
            
            cts.Dispose()
        End Sub

    End Class


End Module

