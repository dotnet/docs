// System.Diagnostics.CounterCreationDataCollection.CounterCreationDataCollection(CounterCreationDataCollection)
/*
   The following program demonstrates 'CounterCreationDataCollection(CounterCreationDataCollection)'
   constructor of 'CounterCreationDataCollection' class.
   An instance of 'CounterCreationDataCollection' is created by passing another instance
   of 'CounterCreationDataCollection'. The counters of the 'CounterCreationDataCollection'
   are displayed to the console.
 */
using System;
using System.Diagnostics;

public class CounterCreationExample
{

    public static void Main()
    {
        try
        {
            //<Snippet1>
            string myCategoryName;
            int numberOfCounters;
            Console.Write("Enter the number of counters : ");
            numberOfCounters = int.Parse(Console.ReadLine());
            CounterCreationData[] myCounterCreationData =
               new CounterCreationData[numberOfCounters];
            for (int i = 0; i < numberOfCounters; i++)
            {
                Console.Write("Enter the counter name for {0} counter : ", i);
                myCounterCreationData[i] = new CounterCreationData();
                myCounterCreationData[i].CounterName = Console.ReadLine();
            }
            CounterCreationDataCollection myCounterCollection =
               new CounterCreationDataCollection(myCounterCreationData);
            Console.Write("Enter the category Name:");
            myCategoryName = Console.ReadLine();
            // Check if the category already exists or not.
            if (!PerformanceCounterCategory.Exists(myCategoryName))
            {
                CounterCreationDataCollection myNewCounterCollection =
                   new CounterCreationDataCollection(myCounterCollection);
                PerformanceCounterCategory.Create(myCategoryName, "Sample Category",
                PerformanceCounterCategoryType.SingleInstance, myNewCounterCollection);


                Console.WriteLine("The list of counters in 'CounterCollection' are : ");
                for (int i = 0; i < myNewCounterCollection.Count; i++)
                    Console.WriteLine("Counter {0} is '{1}'", i, myNewCounterCollection[i].CounterName);
            }
            else
            {
                Console.WriteLine("The category already exists");
            }
            //</Snippet1>
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: {0}.", e.Message);
            return;
        }
    }
}