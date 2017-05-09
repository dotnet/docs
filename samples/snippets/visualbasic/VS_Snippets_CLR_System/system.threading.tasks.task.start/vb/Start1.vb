' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Threading
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim t As New Task(Sub()
                           Console.WriteLine("Task {0} running on thread {1}",
                                             Task.CurrentId, Thread.CurrentThread.ManagedThreadId )
                           For ctr As Integer = 1 To 10
                              Console.WriteLine("   Iteration {0}", ctr)
                           Next   
                        End Sub)
      t.Start
      t.Wait()   
   End Sub
End Module
' The example displays output like the following:
'     Task 1 running on thread 3
'        Iteration 1
'        Iteration 2
'        Iteration 3
'        Iteration 4
'        Iteration 5
'        Iteration 6
'        Iteration 7
'        Iteration 8
'        Iteration 9
'        Iteration 10
' </Snippet1>
