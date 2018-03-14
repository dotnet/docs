' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Threading

Module Example
   Const LOWERBOUND As Integer = 0
   Const UPPERBOUND As Integer = 1001
   
   Dim lockObj As New Object()
   Dim rnd As New Random()
   Dim cte As CountdownEvent
   
   Dim totalCount As Integer = 0
   Dim totalMidpoint As Integer = 0
   Dim midpointCount As Integer = 0

   Public Sub Main()
      cte = New CountdownEvent(1)
      ' Start three threads. 
      For ctr As Integer = 0 To 2
         cte.AddCount()
         Dim th As New Thread(AddressOf GenerateNumbers)
         th.Name = "Thread" + ctr.ToString()
         th.Start()
      Next
      cte.Signal()
      cte.Wait()
      Console.WriteLine()
      Console.WriteLine("Total midpoint values:  {0,10:N0} ({1:P3})",
                        totalMidpoint, totalMidpoint/totalCount)
      Console.WriteLine("Total number of values: {0,10:N0}", 
                        totalCount)                  
   End Sub
   
   Private Sub GenerateNumbers()
      Dim midpoint As Integer = (upperBound - lowerBound) \ 2
      Dim value As Integer = 0
      Dim total As Integer = 0
      Dim midpt As Integer = 0
      Do
         SyncLock lockObj
            value = rnd.Next(lowerBound, upperBound)
         End SyncLock
         If value = midpoint Then 
            Interlocked.Increment(midpointCount)
            midpt += 1
         End If
         total += 1    
      Loop While midpointCount < 10000
      
      Interlocked.Add(totalCount, total)
      Interlocked.Add(totalMidpoint, midpt)
      
      Dim s As String = String.Format("Thread {0}:", Thread.CurrentThread.Name) + vbCrLf +
                        String.Format("   Random Numbers: {0:N0}", total) + vbCrLf +
                        String.Format("   Midpoint values: {0:N0} ({1:P3})", midpt, midpt/total)
      Console.WriteLine(s)
      cte.Signal()
   End Sub
End Module
' The example displays output like the following:
'       Thread Thread2:
'          Random Numbers: 2,776,674
'          Midpoint values: 2,773 (0.100 %)
'       Thread Thread1:
'          Random Numbers: 4,876,100
'          Midpoint values: 4,873 (0.100 %)
'       Thread Thread0:
'          Random Numbers: 2,312,310
'          Midpoint values: 2,354 (0.102 %)
'       
'       Total midpoint values:      10,000 (0.100 %)
'       Total number of values:  9,965,084
' </Snippet3>
