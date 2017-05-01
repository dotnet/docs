// System.Diagnostics.CounterCreationDataCollection.Insert(int, CounterCreationData)
// System.Diagnostics.CounterCreationDataCollection.IndexOf(CounterCreationData)

/*
   The following program demonstrates 'IndexOf(CounterCreationData)' and 'Insert(int, CounterCreationData)'
   methods of 'CounterCreationDataCollection' class. An instance of 'CounterCreationDataCollection'
   is created by passing an array of 'CounterCreationData' to the constructor. A counter is inserted
   into the 'CounterCreationDataCollection' at specified index. The inserted counter and
   its index are displayed to the console.

 */
using System;
using System.Diagnostics;

public class CounterCreationDataCollectionExample
{
    static PerformanceCounter myCounter;
    public static void Main()
    {
        try
        {
            // <Snippet1>
            // <Snippet2>
            string myCategoryName;
            int numberOfCounters;
            Console.Write("Enter the category Name : ");
            myCategoryName = Console.ReadLine();
            // Check if the category already exists or not.
            if (!PerformanceCounterCategory.Exists(myCategoryName))
            {
                Console.Write("Enter the number of counters : ");
                numberOfCounters = int.Parse(Console.ReadLine());
                CounterCreationData[] myCounterCreationData =
                   new CounterCreationData[numberOfCounters];

                for (int i = 0; i < numberOfCounters; i++)
                {
                    Console.Write("Enter the counter name for {0} counter ", i);
                    myCounterCreationData[i] = new CounterCreationData();
                    myCounterCreationData[i].CounterName = Console.ReadLine();
                }
                CounterCreationDataCollection myCounterCollection =
                   new CounterCreationDataCollection(myCounterCreationData);
                CounterCreationData myInsertCounterCreationData = new CounterCreationData(
                   "CounterInsert", "", PerformanceCounterType.NumberOfItems32);
                // Insert an instance of 'CounterCreationData' in the 'CounterCreationDataCollection'.
                myCounterCollection.Insert(myCounterCollection.Count - 1,
                   myInsertCounterCreationData);
                Console.WriteLine("'{0}' counter is inserted into 'CounterCreationDataCollection'",
                   myInsertCounterCreationData.CounterName);
                // Create the category.
                PerformanceCounterCategory.Create(myCategoryName, "Sample Category",
                PerformanceCounterCategoryType.SingleInstance, myCounterCollection);

                for (int i = 0; i < numberOfCounters; i++)
                {
                    myCounter = new PerformanceCounter(myCategoryName,
                       myCounterCreationData[i].CounterName, "", false);
                }
                Console.WriteLine("The index of '{0}' counter is {1}",
                   myInsertCounterCreationData.CounterName, myCounterCollection.IndexOf(myInsertCounterCreationData));
            }
            else
            {
                Console.WriteLine("The category already exists");
            }
            // </Snippet2>
            // </Snippet1>
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: {0}.", e.Message);
            return;
        }
    }
}
