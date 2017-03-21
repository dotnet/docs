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
   