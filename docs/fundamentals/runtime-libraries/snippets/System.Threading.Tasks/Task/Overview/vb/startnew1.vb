' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Imports System.Threading.Tasks

Module Example3
    Public Sub Main()
        Dim t As Task = Task.Factory.StartNew(Sub()
                                                  ' Just loop.
                                                  Dim ctr As Integer = 0
                                                  For ctr = 0 To 1000000
                                                  Next
                                                  Console.WriteLine("Finished {0} loop iterations",
                                                    ctr)
                                              End Sub)
        t.Wait()
    End Sub
End Module
' The example displays the following output:
'       Finished 1000001 loop iterations
' </Snippet7>
