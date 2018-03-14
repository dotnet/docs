' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Threading

Module Example
   Const LOWERBOUND As Integer = 0
   Const UPPERBOUND As Integer = 1001
   
   Dim lockObj As New Object()
   Dim rnd As New Random()
   Dim cte As CountdownEvent
   
   Dim totalCount As Integer = 0
   Dim totalMidpoint As Integer = 0
   Dim midpointCount As Integer = 10000

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
            Interlocked.Decrement(midpointCount)
            midpt += 1
         End If
         total += 1    
      Loop While midpointCount > 0
      
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
'          Random Numbers: 3,204,021
'          Midpoint values: 3,156 (0.099 %)
'       Thread Thread0:
'          Random Numbers: 4,073,592
'          Midpoint values: 4,015 (0.099 %)
'       Thread Thread1:
'          Random Numbers: 2,828,192
'          Midpoint values: 2,829 (0.100 %)
'       
'       Total midpoint values:      10,000 (0.099 %)
'       Total number of values: 10,105,805
' </Snippet1>
