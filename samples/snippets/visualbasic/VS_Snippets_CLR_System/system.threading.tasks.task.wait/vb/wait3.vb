' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet3>
Imports System.Threading
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim ts As New CancellationTokenSource()

      Dim t = Task.Run( Sub()
                           Console.WriteLine("Calling Cancel...")
                           ts.Cancel()
                           Task.Delay(5000).Wait()
                           Console.WriteLine("Task ended delay...")
                        End Sub)
      Try
         Console.WriteLine("About to wait for the task to complete...")
         t.Wait(ts.Token)
      Catch e As OperationCanceledException
         Console.WriteLine("{0}: The wait has been canceled. Task status: {1:G}",
                           e.GetType().Name, t.Status)
         Thread.Sleep(6000)
         Console.WriteLine("After sleeping, the task status:  {0:G}", t.Status)
      End Try
      ts.Dispose()
   End Sub
End Module
' The example displays output like the following:
'    About to wait for the task to complete...
'    Calling Cancel...
'    OperationCanceledException: The wait has been canceled. Task status: Running
'    Task ended delay...
'    After sleeping, the task status:  RanToCompletion
' </Snippet3>
