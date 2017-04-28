' Visual Basic .NET Document
Option Strict On

' <Snippet27>
Imports System.Threading
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim task1 = Task.Factory.StartNew(Sub()
                                           Throw New CustomException("task1 faulted.")
                                        End Sub).
                  ContinueWith(Sub(t)
                                  Console.WriteLine("{0}: {1}",
                                                    t.Exception.InnerException.GetType().Name,
                                                    t.Exception.InnerException.Message)
                               End Sub, TaskContinuationOptions.OnlyOnFaulted)

      Thread.Sleep(500)
   End Sub
End Module

Class CustomException : Inherits Exception
   Public Sub New(s As String)
      MyBase.New(s)
   End Sub
End Class
' The example displays output like the following:
'       CustomException: task1 faulted.
' </Snippet27>
