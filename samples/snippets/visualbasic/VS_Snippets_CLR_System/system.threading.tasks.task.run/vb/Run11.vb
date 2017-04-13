' Visual Basic .NET Document
Option Strict On

' <Snippet11>
Imports System.Threading
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      ShowThreadInfo("Application")

      Dim t As Task = Task.Run(Sub() ShowThreadInfo("Task") )
      t.Wait()
   End Sub
   
   Private Sub ShowThreadInfo(s As String)
      Console.WriteLine("{0} Thread ID: {1}",
                        s, Thread.CurrentThread.ManagedThreadId)
   End Sub
End Module
' The example displays output like the following:
'    Application thread ID: 1
'    Task thread ID: 3
' </Snippet11>
