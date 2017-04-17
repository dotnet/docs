' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Threading
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim ts As New CancellationTokenSource()
      Dim thread As New Thread(AddressOf CancelToken)
      thread.Start(ts)

      Dim t As Task = Task.Run( Sub()
                                   Task.Delay(5000).Wait()
                                    Console.WriteLine("Task ended delay...")
                                End Sub)
      Try
         Console.WriteLine("About to wait completion of task {0}", t.Id)
         Dim result As Boolean = t.Wait(1510, ts.Token)
         Console.WriteLine("Wait completed normally: {0}", result)
         Console.WriteLine("The task status:  {0:G}", t.Status)
      Catch e As OperationCanceledException
         Console.WriteLine("{0}: The wait has been canceled. Task status: {1:G}",
                           e.GetType().Name, t.Status)
         Thread.Sleep(4000)
         Console.WriteLine("After sleeping, the task status:  {0:G}", t.Status)
         ts.Dispose()
      End Try
   End Sub

   Private Sub CancelToken(obj As Object)
      Thread.Sleep(1500)
      Console.WriteLine("Canceling the cancellation token from thread {0}...",
                        Thread.CurrentThread.ManagedThreadId)

      If TypeOf obj Is CancellationTokenSource Then
         Dim source As CancellationTokenSource = CType(obj, CancellationTokenSource)
         source.Cancel()
      End If
   End Sub
End Module
' The example displays output like the following if the wait is canceled by
' the cancellation token:
'    About to wait completion of task 1
'    Canceling the cancellation token from thread 3...
'    OperationCanceledException: The wait has been canceled. Task status: Running
'    Task ended delay...
'    After sleeping, the task status:  RanToCompletion
' The example displays output like the following if the wait is canceled by
' the timeout interval expiring:
'    About to wait completion of task 1
'    Wait completed normally: False
'    The task status:  Running
'    Canceling the cancellation token from thread 3...
' </Snippet4>


