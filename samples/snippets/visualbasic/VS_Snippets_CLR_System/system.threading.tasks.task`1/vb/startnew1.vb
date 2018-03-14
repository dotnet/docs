' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet7>
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim t = Task(Of Integer).Factory.StartNew(Function()
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
' The example displays output like the following:
'       Finished 1,000,001 iterations
' </Snippet7>
