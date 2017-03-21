      Dim myPerformanceCounter2 As New PerformanceCounter("Processor", _
                                                   "% Processor Time", "0")
      Dim myCounterSample2 As New CounterSample(10&, 20&, 30&, 40&, 50&, 60&, _
                               PerformanceCounterType.AverageCount64, 300)
      Console.WriteLine("CounterTimeStamp = " & myCounterSample2.CounterTimeStamp)
      Console.WriteLine("BaseValue = " & myCounterSample2.BaseValue)
      Console.WriteLine("RawValue = " & myCounterSample2.RawValue)
      Console.WriteLine("CounterFrequency = " & myCounterSample2.CounterFrequency)
      Console.WriteLine("SystemFrequency = " & myCounterSample2.SystemFrequency)
      Console.WriteLine("TimeStamp = " & myCounterSample2.TimeStamp)
      Console.WriteLine("TimeStamp100nSec = " & myCounterSample2.TimeStamp100nSec)
      Console.WriteLine("CounterType = " & myCounterSample2.CounterType.ToString)
      Console.WriteLine("CounterTimeStamp = " & myCounterSample2.CounterTimeStamp)

      ' Hold the results of sample.
      myCounterSample2 = myPerformanceCounter2.NextSample()
      Console.WriteLine("BaseValue = " & myCounterSample2.BaseValue)
      Console.WriteLine("RawValue = " & myCounterSample2.RawValue)
      Console.WriteLine("CounterFrequency = " & myCounterSample2.CounterFrequency)
      Console.WriteLine("SystemFrequency = " & myCounterSample2.SystemFrequency)
      Console.WriteLine("TimeStamp = " & myCounterSample2.TimeStamp)
      Console.WriteLine("TimeStamp100nSec = " & myCounterSample2.TimeStamp100nSec)
      Console.WriteLine("CounterType = " & myCounterSample2.CounterType.ToString)
      Console.WriteLine("CounterTimeStamp = " & myCounterSample2.CounterTimeStamp)