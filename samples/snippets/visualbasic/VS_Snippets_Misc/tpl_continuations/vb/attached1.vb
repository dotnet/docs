' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet9>
Imports System
Imports System.Threading
Imports System.Threading.Tasks

Public Module Example
   Public Sub Main()
      Dim t = Task.Factory.StartNew( Sub()
                                        Console.WriteLine("Running antecedent task {0}...",
                                                          Task.CurrentId)
                                        Console.WriteLine("Launching attached child tasks...")
                                        For ctr As Integer = 1 To 5
                                           Dim index As Integer = ctr
                                           Task.Factory.StartNew( Sub(value)
                                                                     Console.WriteLine("   Attached child task #{0} running",
                                                                                       value)
                                                                     Thread.Sleep(1000)
                                                                  End Sub, index, TaskCreationOptions.AttachedToParent)
                                        Next
                                        Console.WriteLine("Finished launching attached child tasks...")
                                     End Sub)
      Dim continuation = t.ContinueWith( Sub(antecedent)
                                            Console.WriteLine("Executing continuation of Task {0}",
                                                              antecedent.Id)
                                         End Sub)
      continuation.Wait()
   End Sub
End Module
' The example displays the following output:
'       Running antecedent task 1...
'       Launching attached child tasks...
'       Finished launching attached child tasks...
'          Attached child task #5 running
'          Attached child task #1 running
'          Attached child task #2 running
'          Attached child task #3 running
'          Attached child task #4 running
'       Executing continuation of Task 1
' </Snippet9>
