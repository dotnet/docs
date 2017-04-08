' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Threading

Public Class Example
   <ThreadStatic> Shared previous As Double = 0.0
   <ThreadStatic> Shared sum As Double = 0.0
   <ThreadStatic> Shared calls As Integer = 0
   <ThreadStatic> Shared abnormal As Boolean
   Shared totalNumbers As Integer = 0
   Shared countdown As CountdownEvent
   Private Shared lockObj As Object
   Dim rand As Random

   Public Sub New()
      rand = New Random()
      lockObj = New Object()
      countdown = New CountdownEvent(1)
   End Sub

   Public Shared Sub Main()
      Dim ex As New Example()
      Thread.CurrentThread.Name = "Main"
      ex.Execute()
      countdown.Wait()
      Console.WriteLine("{0:N0} random numbers were generated.", totalNumbers)
   End Sub

   Private Sub Execute()
      For threads As Integer = 1 To 10
         Dim newThread As New Thread(New ThreadStart(AddressOf GetRandomNumbers))
         countdown.AddCount()
         newThread.Name = threads.ToString()
         newThread.Start()
      Next
      Me.GetRandomNumbers()
   End Sub

   Private Sub GetRandomNumbers()
      Dim result As Double = 0.0
      
       
      For ctr As Integer = 1 To 2000000
         SyncLock lockObj
            result = rand.NextDouble()
            calls += 1
            Interlocked.Increment(totalNumbers)
            ' We should never get the same random number twice.
            If result = previous Then
               abnormal = True
               Exit For
            Else
               previous = result
               sum += result
            End If   
         End SyncLock
      Next
      ' Get last result.
      If abnormal Then
         Console.WriteLine("Result is {0} in {1}", previous, Thread.CurrentThread.Name)
      End If       
      
      Console.WriteLine("Thread {0} finished random number generation.", Thread.CurrentThread.Name)
      Console.WriteLine("Sum = {0:N4}, Mean = {1:N4}, n = {2:N0}", sum, sum/calls, calls)
      Console.WriteLine()        
      countdown.Signal()
   End Sub
End Class
' The example displays output similar to the following:
'    Thread 1 finished random number generation.
'    Total = 1,000,556.7483, Mean = 0.5003, n = 2,000,000
'    
'    Thread 6 finished random number generation.
'    Total = 999,704.3865, Mean = 0.4999, n = 2,000,000
'    
'    Thread 2 finished random number generation.
'    Total = 999,680.8904, Mean = 0.4998, n = 2,000,000
'    
'    Thread 10 finished random number generation.
'    Total = 999,437.5132, Mean = 0.4997, n = 2,000,000
'    
'    Thread 8 finished random number generation.
'    Total = 1,000,663.7789, Mean = 0.5003, n = 2,000,000
'    
'    Thread 4 finished random number generation.
'    Total = 999,379.5978, Mean = 0.4997, n = 2,000,000
'    
'    Thread 5 finished random number generation.
'    Total = 1,000,011.0605, Mean = 0.5000, n = 2,000,000
'    
'    Thread 9 finished random number generation.
'    Total = 1,000,637.4556, Mean = 0.5003, n = 2,000,000
'    
'    Thread Main finished random number generation.
'    Total = 1,000,676.2381, Mean = 0.5003, n = 2,000,000
'    
'    Thread 3 finished random number generation.
'    Total = 999,951.1025, Mean = 0.5000, n = 2,000,000
'    
'    Thread 7 finished random number generation.
'    Total = 1,000,844.5217, Mean = 0.5004, n = 2,000,000
'    
'    22,000,000 random numbers were generated.
' </Snippet1>
