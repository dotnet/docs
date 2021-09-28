' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Threading.Tasks

Module Example
    Public Sub Main()
        Dim t = Task.Run(Function()
                             Dim dat As DateTime = DateTime.Now
                             If dat = DateTime.MinValue Then
                                 Throw New ArgumentException("The clock is not working.")
                             End If

                             If dat.Hour > 17 Then
                                 Return "evening"
                             Else If dat.Hour > 12 Then
                                 Return "afternoon"
                             Else
                                 Return "morning"
                             End If
                         End Function)
        Dim c = t.ContinueWith(Sub(antecedent)
                                   Console.WriteLine("Good {0}!",
                                                     antecedent.Result)
                                   Console.WriteLine("And how are you this fine {0}?",
                                                     antecedent.Result)
                               End Sub, TaskContinuationOptions.OnlyOnRanToCompletion)
        c.Wait()
    End Sub
End Module
' The example displays output like the following:
'       Good afternoon!
'       And how are you this fine afternoon?
' </Snippet2>

