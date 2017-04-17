// System.Diagnostics.CounterCreationDataCollection.Contains(CounterCreationData)
// System.Diagnostics.CounterCreationDataCollection.Remove(CounterCreationData)
/*
   The following program demonstrates 'Contains' and 'Remove' methods of
   'CounterCreationDataCollection' class. An instance of 'CounterCreationDataCollection'
   is created by passing an array of 'CounterCreationData'. A particular instance of
   'CounterCreationData' is removed if it exist in the 'CounterCreationDataCollection'.
*/
using System;
using System.Diagnostics;

public class CounterCreationDataCollectionExample
{
    public static void Main()
    {
        try
        {
            // <Snippet1>
            // <Snippet2>
            string myCategoryName;
            int numberOfCounters;
            Console.Write("Enter the category Name :");
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
                    Console.Write("Enter the counter name for {0} counter : ", i);
                    myCounterCreationData[i] = new CounterCreationData();
                    myCounterCreationData[i].CounterName = Console.ReadLine();
                }
                CounterCreationDataCollection myCounterCollection =
                   new CounterCreationDataCollection();
                // Add the 'CounterCreationData[]' to 'CounterCollection'.
                myCounterCollection.AddRange(myCounterCreationData);

                PerformanceCounterCategory.Create(myCategoryName,
                   "Sample Category",
                PerformanceCounterCategoryType.SingleInstance, myCounterCollection);

                if (myCounterCreationData.Length > 0)
                {
                    if (myCounterCollection.Contains(myCounterCreationData[0]))
                    {
                        myCounterCollection.Remove(myCounterCreationData[0]);
                        Console.WriteLine("'{0}' counter is removed from the " +
                           "CounterCreationDataCollection", myCounterCreationData[0].CounterName);
                    }
                }
                else
                {
                    Console.WriteLine("The counters does not exist");
                }
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
