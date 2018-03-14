' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Collections.Generic
Imports System.Threading
Imports System.Threading.Tasks

Module Example
   Const LOWERBOUND As Integer = 0
   Const UPPERBOUND As Integer = 1001
   
   Dim lockObj As New Object()
   Dim rnd As New Random()
   
   Dim totalCount As Integer = 0
   Dim totalMidpoint As Integer = 0
   Dim midpointCount As Integer = 50000

   Public Sub Main()
      Dim tasks As New List(Of Task)()

      ' Start three tasks. 
      For ctr As Integer = 0 To 2
         tasks.Add( Task.Run(Sub() 
                                Dim midpoint As Integer = (upperBound - lowerBound) \ 2
                                Dim value As Integer = 0
                                Dim total As Integer = 0
                                Dim midpt As Integer = 0
                                Do
                                   SyncLock lockObj
                                      value = rnd.Next(lowerBound, upperBound)
                                   End SyncLock
                                   If value = midpoint Then 
                                      Interlocked.Decrement(midpointCount)
                                      midpt += 1
                                   End If
                                   total += 1    
                                Loop While midpointCount > 0
                              
                                Interlocked.Add(totalCount, total)
                                Interlocked.Add(totalMidpoint, midpt)
                              
                                Dim s As String = String.Format("Task {0}:", Task.CurrentId) + vbCrLf +
                                                  String.Format("   Random Numbers: {0:N0}", total) + vbCrLf +
                                                  String.Format("   Midpoint values: {0:N0} ({1:P3})", midpt, midpt/total)
                                Console.WriteLine(s)
                             End Sub ))
      Next
      Task.WaitAll(tasks.ToArray())
      Console.WriteLine()
      Console.WriteLine("Total midpoint values:  {0,10:N0} ({1:P3})",
                        totalMidpoint, totalMidpoint/totalCount)
      Console.WriteLine("Total number of values: {0,10:N0}", 
                        totalCount)                  
   End Sub
End Module
' The example displays output like the following:
'       Task 1:
'          Random Numbers: 24,530,624
'          Midpoint values: 24,675 (0.101 %)
'       Task 2:
'          Random Numbers: 7,079,718
'          Midpoint values: 7,093 (0.100 %)
'       Task 3:
'          Random Numbers: 18,284,617
'          Midpoint values: 18,232 (0.100 %)
'       
'       Total midpoint values:      50,000 (0.100 %)
'       Total number of values: 49,894,959
' </Snippet2>
