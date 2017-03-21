      PerformanceCounter myPerformanceCounter1 = new PerformanceCounter
         ("Processor","% Processor Time", "0");
      CounterSample myCounterSample1 = new CounterSample(10L, 20L, 30L, 40L, 50L, 60L,
                           PerformanceCounterType.AverageCount64);
      Console.WriteLine("CounterTimeStamp = "+myCounterSample1.CounterTimeStamp);

      Console.WriteLine("BaseValue = "+myCounterSample1.BaseValue);
      Console.WriteLine("RawValue = "+myCounterSample1.RawValue);
      Console.WriteLine("CounterFrequency = "+myCounterSample1.CounterFrequency);
      Console.WriteLine("SystemFrequency = "+myCounterSample1.SystemFrequency);
      Console.WriteLine("TimeStamp = "+myCounterSample1.TimeStamp);
      Console.WriteLine("TimeStamp100nSec = "+myCounterSample1.TimeStamp100nSec);
      Console.WriteLine("CounterType = "+myCounterSample1.CounterType);
      // Hold the results of sample.
      myCounterSample1 = myPerformanceCounter1.NextSample();
      Console.WriteLine("BaseValue = "+myCounterSample1.BaseValue);
      Console.WriteLine("RawValue = "+myCounterSample1.RawValue);
      Console.WriteLine("CounterFrequency = "+myCounterSample1.CounterFrequency);
      Console.WriteLine("SystemFrequency = "+myCounterSample1.SystemFrequency);
      Console.WriteLine("TimeStamp = "+myCounterSample1.TimeStamp);
      Console.WriteLine("TimeStamp100nSec = "+myCounterSample1.TimeStamp100nSec);
      Console.WriteLine("CounterType = "+myCounterSample1.CounterType);