' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim t As Task(Of Integer) = Task.Run(Function()
                                  Dim max As Integer = 1000000
                                  Dim ctr As Integer
                                  For ctr = 0 to max
                                     If ctr = max \ 2 And Date.Now.Hour <= 12 Then
                                        ctr += 1
                                        Exit For
                                     End If
                                  Next
                                  Return ctr
                               End Function)
      Console.WriteLine("Finished {0:N0} iterations.", t.Result)
   End Sub
End Module
' The example displays the following output:
'       Finished 1,000,001 loop iterations
' </Snippet6>
