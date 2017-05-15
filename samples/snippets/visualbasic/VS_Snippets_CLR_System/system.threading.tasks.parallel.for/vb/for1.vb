' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim result As ParallelLoopResult = Parallel.For(0, 100, Sub(ctr)
                                                                 Dim rnd As New Random(ctr * 100000)
                                                                 Dim bytes(99) As Byte
                                                                 rnd.NextBytes(bytes)
                                                                 Dim sum As Integer
                                                                 For Each byt In bytes
                                                                    sum += byt
                                                                 Next
                                                                 Console.WriteLine("Iteration {0,2}: {1:N0}", ctr, sum)
                                                              End Sub)
      Console.WriteLine("Result: {0}", If(result.IsCompleted, "Completed Normally", 
                                                             String.Format("Completed to {0}", result.LowestBreakIteration)))
   End Sub
End Module
' The following is a portion of the output displayed by the example:
'       Iteration  0: 12,509
'       Iteration 50: 12,823
'       Iteration 51: 11,275
'       Iteration 52: 12,531
'       Iteration  1: 13,007
'       Iteration 53: 13,799
'       Iteration  4: 12,945
'       Iteration  2: 13,246
'       Iteration 54: 13,008
'       Iteration 55: 12,727
'       Iteration 56: 13,223
'       Iteration 57: 13,717
'       Iteration  5: 12,679
'       Iteration  3: 12,455
'       Iteration 58: 12,669
'       Iteration 59: 11,882
'       Iteration  6: 13,167
'       ...
'       Iteration 92: 12,275
'       Iteration 93: 13,282
'       Iteration 94: 12,745
'       Iteration 95: 11,957
'       Iteration 96: 12,455
'       Result: Completed Normally
' </Snippet1>
