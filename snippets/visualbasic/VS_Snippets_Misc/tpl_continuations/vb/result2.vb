' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim t = Task.Run( Function()
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
      Dim c = t.ContinueWith( Sub(antecedent)
                                 If t.Status = TaskStatus.RanToCompletion Then
                                    Console.WriteLine("Good {0}!",
                                                      antecedent.Result)
                                    Console.WriteLine("And how are you this fine {0}?",
                                                      antecedent.Result)
                                 Else If t.Status = TaskStatus.Faulted Then
                                    Console.WriteLine(t.Exception.GetBaseException().Message)
                                 End If
                              End Sub)
   End Sub
End Module
' The example displays output like the following:
'       Good afternoon!
'       And how are you this fine afternoon?
' </Snippet7>

