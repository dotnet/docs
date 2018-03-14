' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Threading
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Console.WriteLine("Application thread ID: {0}",
                        Thread.CurrentThread.ManagedThreadId)
      Dim t As Task = Task.Run(Sub()
                                  Console.WriteLine("Task thread ID: {0}",
                                                    Thread.CurrentThread.ManagedThreadId)
                               End Sub)
      t.Wait()
   End Sub
End Module
' The example displays output like the following:
'    Application thread ID: 1
'    Task thread ID: 3
' </Snippet3>
