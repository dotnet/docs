' System.Diagnostics.Stopwatch

'<Snippet1>
Imports System
Imports System.Diagnostics

Class OperationsTimer
   
   Public Shared Sub Main()
      DisplayTimerProperties()
      
      Console.WriteLine()
      Console.WriteLine("Press the Enter key to begin:")
      Console.ReadLine()
      Console.WriteLine()
      
      TimeOperations()
   End Sub
   
   
'<Snippet2>
   Public Shared Sub DisplayTimerProperties()

      ' Display the timer frequency and resolution.
      If Stopwatch.IsHighResolution Then
         Console.WriteLine("Operations timed using the system's high-resolution performance counter.")
      Else
         Console.WriteLine("Operations timed using the DateTime class.")
      End If
      
      Dim frequency As Long = Stopwatch.Frequency
      Console.WriteLine("  Timer frequency in ticks per second = {0}", frequency)
      Dim nanosecPerTick As Long = 1000000000 / frequency
      Console.WriteLine("  Timer is accurate within {0} nanoseconds", nanosecPerTick)

   End Sub
   
'</Snippet2>
'<Snippet3>
   Private Shared Sub TimeOperations()

      Dim nanosecPerTick As Long = 1000000000 / Stopwatch.Frequency
      Const numIterations As Long = 10000
      
      ' Define the operation title names.
      Dim operationNames As String() =  _
        {"Operation: Int32.Parse(""0"")", _
         "Operation: Int32.TryParse(""0"")", _
         "Operation: Int32.Parse(""a"")", _
         "Operation: Int32.TryParse(""a"")"}
      
      ' Time four different implementations for parsing 
      ' an integer from a string. 

      Dim operation As Integer
      For operation = 0 To 3
         '<Snippet5>
         ' Define variables for operation statistics.
         Dim numTicks As Long = 0
         Dim numRollovers As Long = 0
         Dim maxTicks As Long = 0
         Dim minTicks As Long = Int64.MaxValue
         Dim indexFastest As Integer = - 1
         Dim indexSlowest As Integer = - 1
         Dim milliSec As Long = 0
         
         Dim time10kOperations As Stopwatch = Stopwatch.StartNew()
         
         ' Run the current operation 10001 times.
         ' The first execution time will be tossed
         ' out, since it can skew the average time.
         Dim i As Integer
         For i = 0 To numIterations
            '<Snippet4>
            Dim ticksThisTime As Long = 0
            Dim inputNum As Integer
            Dim timePerParse As Stopwatch
            
            Select Case operation
               Case 0
                  ' Parse a valid integer using
                  ' a try-catch statement.
                  ' Start a new stopwatch timer.
                  timePerParse = Stopwatch.StartNew()
                  
                  Try
                     inputNum = Int32.Parse("0")
                  Catch e As FormatException
                     inputNum = 0
                  End Try
                  
                  ' Stop the timer, and save the
                  ' elapsed ticks for the operation.
                  timePerParse.Stop()
                  ticksThisTime = timePerParse.ElapsedTicks
               Case 1
                  ' Parse a valid integer using
                  ' the TryParse statement.
                  ' Start a new stopwatch timer.
                  timePerParse = Stopwatch.StartNew()
                  
                  If Not Int32.TryParse("0", inputNum) Then
                     inputNum = 0
                  End If
                  
                  ' Stop the timer, and save the
                  ' elapsed ticks for the operation.
                  timePerParse.Stop()
                  ticksThisTime = timePerParse.ElapsedTicks
               Case 2
                  ' Parse an invalid value using
                  ' a try-catch statement.
                  ' Start a new stopwatch timer.
                  timePerParse = Stopwatch.StartNew()
                  
                  Try
                     inputNum = Int32.Parse("a")
                  Catch e As FormatException
                     inputNum = 0
                  End Try
                  
                  ' Stop the timer, and save the
                  ' elapsed ticks for the operation.
                  timePerParse.Stop()
                  ticksThisTime = timePerParse.ElapsedTicks
               Case 3
                  ' Parse an invalid value using
                  ' the TryParse statement.
                  ' Start a new stopwatch timer.
                  timePerParse = Stopwatch.StartNew()
                  
                  If Not Int32.TryParse("a", inputNum) Then
                     inputNum = 0
                  End If
                  
                  ' Stop the timer, and save the
                  ' elapsed ticks for the operation.
                  timePerParse.Stop()
                  ticksThisTime = timePerParse.ElapsedTicks
               
               Case Else
            End Select
            '</Snippet4>
            
            ' Skip over the time for the first operation,
            ' just in case it caused a one-time
            ' performance hit.
            If i = 0 Then
               time10kOperations.Reset()
               time10kOperations.Start()
            Else
               
               ' Update operation statistics
               ' for iterations 1-10001.
               If maxTicks < ticksThisTime Then
                  indexSlowest = i
                  maxTicks = ticksThisTime
               End If
               If minTicks > ticksThisTime Then
                  indexFastest = i
                  minTicks = ticksThisTime
               End If
               numTicks += ticksThisTime
               If numTicks < ticksThisTime Then
                  ' Keep track of rollovers.
                  numRollovers += 1
               End If
            End If
         Next i
         
         ' Display the statistics for 10000 iterations.
         time10kOperations.Stop()
         milliSec = time10kOperations.ElapsedMilliseconds
         
         Console.WriteLine()
         Console.WriteLine("{0} Summary:", operationNames(operation))
         Console.WriteLine("  Slowest time:  #{0}/{1} = {2} ticks", _
            indexSlowest, numIterations, maxTicks)
         Console.WriteLine("  Fastest time:  #{0}/{1} = {2} ticks", _
            indexFastest, numIterations, minTicks)
         Console.WriteLine("  Average time:  {0} ticks = {1} nanoseconds", _
            numTicks / numIterations, numTicks * nanosecPerTick / numIterations)
         Console.WriteLine("  Total time looping through {0} operations: {1} milliseconds", _
            numIterations, milliSec)
         '</Snippet5>
      Next operation

   End Sub
End Class
'</Snippet3>
'</Snippet1>