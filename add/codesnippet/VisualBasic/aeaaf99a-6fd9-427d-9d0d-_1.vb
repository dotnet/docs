      Dim myPerformanceCounter1 As New PerformanceCounter("Processor", _
                                                  "% Processor Time", "0")
      Dim myCounterSample1 As New CounterSample(10&, 20&, 30&, 40&, 50&, 60&, _
                                     PerformanceCounterType.AverageCount64)
      Console.WriteLine("CounterTimeStamp = " & myCounterSample1.CounterTimeStamp)

      Console.WriteLine("BaseValue = " & myCounterSample1.BaseValue)
      Console.WriteLine("RawValue = " & myCounterSample1.RawValue)
      Console.WriteLine("CounterFrequency = " & myCounterSample1.CounterFrequency)
      Console.WriteLine("SystemFrequency = " & myCounterSample1.SystemFrequency)
      Console.WriteLine("TimeStamp = " & myCounterSample1.TimeStamp)
      Console.WriteLine("TimeStamp100nSec = " & myCounterSample1.TimeStamp100nSec)
      Console.WriteLine("CounterType = " & myCounterSample1.CounterType.ToString)
      ' Hold the results of sample.
      myCounterSample1 = myPerformanceCounter1.NextSample()

      Console.WriteLine("BaseValue = " & myCounterSample1.BaseValue)
      Console.WriteLine("RawValue = " & myCounterSample1.RawValue)
      Console.WriteLine("CounterFrequency = " & myCounterSample1.CounterFrequency)
      Console.WriteLine("SystemFrequency = " & myCounterSample1.SystemFrequency)
      Console.WriteLine("TimeStamp = " & myCounterSample1.TimeStamp)
      Console.WriteLine("TimeStamp100nSec = " & myCounterSample1.TimeStamp100nSec)
      Console.WriteLine("CounterType = " & myCounterSample1.CounterType.ToString)