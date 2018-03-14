// System.Diagnostics.CounterSample.CounterSample(long,long,long,long,long,long,PerformanceCounterType)
// System.Diagnostics.CounterSample.CounterSample(long,long,long,long,long,long,PerformanceCounterType,long)

/* The following program demonstrates the constructors of the 'CounterSample'
   structure. It creates an instance of performance counter, configures it
   to interact with 'Processor' category, '% Processor Time' counter and
   '0' instance, creates an instance of 'CounterSample', and displays
    the corresponding fields.
*/

using System;
using System.Diagnostics;

class MyCounterSampleClass
{
   public static void Main()
   {
// <Snippet1>
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
// </Snippet1>
      Console.WriteLine("");
      Console.WriteLine("");
// <Snippet2>
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
// </Snippet2>
   }
}
