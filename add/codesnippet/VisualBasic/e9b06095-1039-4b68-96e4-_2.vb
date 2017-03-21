        Dim startTime As Date = Now
        ' Run the process that is to be timed.
        Dim runLength As Global.System.TimeSpan = Now.Subtract(startTime)
        Dim millisecs As Double = runLength.TotalMilliseconds