' Visual Basic .NET Document
Option Strict On
Option Infer on

' <Snippet1>
Imports System.Threading
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Console.WriteLine("Application executing on thread {0}",
                        Thread.CurrentThread.ManagedThreadId)
      Dim asyncTask = Task.Run( Function()
                                   Console.WriteLine("Task {0} (asyncTask) executing on Thread {1}",
                                                     Task.CurrentId,
                                                     Thread.CurrentThread.ManagedThreadId)
                                   Dim sum As Long = 0
                                   For ctr As Integer = 1 To 1000000
                                      sum += ctr
                                   Next
                                   Return sum
                                End Function)
      Dim syncTask As New Task(Of Long)( Function()
                                            Console.WriteLine("Task {0} (syncTask) executing on Thread {1}",
                                                              Task.CurrentId,
                                                              Thread.CurrentThread.ManagedThreadId)
                                            Dim sum As Long = 0
                                            For ctr As Integer = 1 To 1000000
                                               sum += ctr
                                            Next
                                            Return sum
                                         End Function)
      syncTask.RunSynchronously()
      Console.WriteLine()
      Console.WriteLine("Task {0} returned {1:N0}", syncTask.Id, syncTask.Result)
      Console.WriteLine("Task {0} returned {1:N0}", asyncTask.Id, asyncTask.Result)
   End Sub
End Module
' The example displays the following output:
'       Application executing on thread 1
'       Task 1 (syncTask) executing on Thread 1
'       Task 2 (asyncTask) executing on Thread 3
'       1 status: RanToCompletion
'       2 status: RanToCompletion
'
'       Task 2 returned 500,000,500,000
'       Task 1 returned 500,000,500,000
' </Snippet1>

