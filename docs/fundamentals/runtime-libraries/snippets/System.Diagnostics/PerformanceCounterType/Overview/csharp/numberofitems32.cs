//<snippet1>
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;

public class NumberOfItems64
{

	private static PerformanceCounter PC;

	public static void Main()
	{	
		ArrayList samplesList = new ArrayList();

        // If the category does not exist, create the category and exit.
        // Performance counters should not be created and immediately used.
        // There is a latency time to enable the counters, they should be created
        // prior to executing the application that uses the counters.
        // Execute this sample a second time to use the category.
        if (SetupCategory())
            return;
        CreateCounters();
		CollectSamples(samplesList);
		CalculateResults(samplesList);
	}

    private static bool SetupCategory()
    {		
        if ( !PerformanceCounterCategory.Exists("NumberOfItems32SampleCategory") )
        {

            CounterCreationDataCollection CCDC = new CounterCreationDataCollection();

            // Add the counter.
            CounterCreationData NOI64 = new CounterCreationData();
            NOI64.CounterType = PerformanceCounterType.NumberOfItems64;
            NOI64.CounterName = "NumberOfItems32Sample";
            CCDC.Add(NOI64);

            // Create the category.
            PerformanceCounterCategory.Create("NumberOfItems32SampleCategory",
                "Demonstrates usage of the NumberOfItems32 performance counter type.",
                PerformanceCounterCategoryType.SingleInstance, CCDC);

            return(true);
        }
        else
        {
            Console.WriteLine("Category exists - NumberOfItems32SampleCategory");
            return(false);
        }
    }

    private static void CreateCounters()
    {
        // Create the counter.
        PC = new PerformanceCounter("NumberOfItems32SampleCategory",
			"NumberOfItems32Sample",
			false);

        PC.RawValue=0;
    }

	private static void CollectSamples(ArrayList samplesList)
	{

		Random r = new Random( DateTime.Now.Millisecond );

		// Loop for the samples.
		for (int j = 0; j < 100; j++)
		{
	
			int value = r.Next(1, 10);
			Console.Write(j + " = " + value);

			PC.IncrementBy(value);

			if ((j % 10) == 9)
			{
				OutputSample(PC.NextSample());
				samplesList.Add( PC.NextSample() );
			}
			else
            {
                Console.WriteLine();
            }

            System.Threading.Thread.Sleep(50);
		}
	}

    private static void CalculateResults(ArrayList samplesList)
    {
        for(int i = 0; i < (samplesList.Count - 1); i++)
        {
            // Output the sample.
            OutputSample( (CounterSample)samplesList[i] );
            OutputSample( (CounterSample)samplesList[i+1] );

			// Use .NET to calculate the counter value.
            Console.WriteLine(".NET computed counter value = " +
                CounterSampleCalculator.ComputeCounterValue((CounterSample)samplesList[i],
                (CounterSample)samplesList[i+1]) );

			// Calculate the counter value manually.
            Console.WriteLine("My computed counter value = " +
                MyComputeCounterValue((CounterSample)samplesList[i],
                (CounterSample)samplesList[i+1]) );
        }
    }

	//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++
	//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++
	private static Single MyComputeCounterValue(CounterSample s0, CounterSample s1)
	{
		Single counterValue = s1.RawValue;
		return(counterValue);
	}
	
	// Output information about the counter sample.
	private static void OutputSample(CounterSample s)
	{
		Console.WriteLine("\r\n+++++++++++");
		Console.WriteLine("Sample values - \r\n");
		Console.WriteLine("   BaseValue        = " + s.BaseValue);
		Console.WriteLine("   CounterFrequency = " + s.CounterFrequency);
		Console.WriteLine("   CounterTimeStamp = " + s.CounterTimeStamp);
		Console.WriteLine("   CounterType      = " + s.CounterType);
		Console.WriteLine("   RawValue         = " + s.RawValue);
		Console.WriteLine("   SystemFrequency  = " + s.SystemFrequency);
		Console.WriteLine("   TimeStamp        = " + s.TimeStamp);
		Console.WriteLine("   TimeStamp100nSec = " + s.TimeStamp100nSec);
		Console.WriteLine("++++++++++++++++++++++");
	}
}
//</snippet1>