      PerformanceCounter myPerformanceCounter2 = new PerformanceCounter
         ("Processor","% Processor Time", "0");
      CounterSample myCounterSample2 = new CounterSample(10L, 20L, 30L, 40L, 50L, 60L,
                     PerformanceCounterType.AverageCount64, 300);
      Console.WriteLine("CounterTimeStamp = "+myCounterSample2.CounterTimeStamp);
      Console.WriteLine("BaseValue = "+myCounterSample2.BaseValue);
      Console.WriteLine("RawValue = "+myCounterSample2.RawValue);
      Console.WriteLine("CounterFrequency = "+myCounterSample2.CounterFrequency);
      Console.WriteLine("SystemFrequency = "+myCounterSample2.SystemFrequency);
      Console.WriteLine("TimeStamp = "+myCounterSample2.TimeStamp);
      Console.WriteLine("TimeStamp100nSec = "+myCounterSample2.TimeStamp100nSec);
      Console.WriteLine("CounterType = "+myCounterSample2.CounterType);
      Console.WriteLine("CounterTimeStamp = "+myCounterSample2.CounterTimeStamp);
      // Hold the results of sample.
      myCounterSample2 = myPerformanceCounter2.NextSample();
      Console.WriteLine("BaseValue = "+myCounterSample2.BaseValue);
      Console.WriteLine("RawValue = "+myCounterSample2.RawValue);
      Console.WriteLine("CounterFrequency = "+myCounterSample2.CounterFrequency);
      Console.WriteLine("SystemFrequency = "+myCounterSample2.SystemFrequency);
      Console.WriteLine("TimeStamp = "+myCounterSample2.TimeStamp);
      Console.WriteLine("TimeStamp100nSec = "+myCounterSample2.TimeStamp100nSec);
      Console.WriteLine("CounterType = "+myCounterSample2.CounterType);
      Console.WriteLine("CounterTimeStamp = "+myCounterSample2.CounterTimeStamp);