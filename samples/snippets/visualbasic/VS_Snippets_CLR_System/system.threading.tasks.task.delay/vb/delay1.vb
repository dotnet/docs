' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim t = Task.Run(Async Function()
                                Await Task.Delay(1000)
                                Return 42
                       End Function)
      t.Wait()
      Console.WriteLine("Task t Status: {0}, Result: {1}",
                        t.Status, t.Result)
   End Sub
End Module
' The example displays the following output:
'       Task t Status: RanToCompletion, Result: 42
' </Snippet1>
