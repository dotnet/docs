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