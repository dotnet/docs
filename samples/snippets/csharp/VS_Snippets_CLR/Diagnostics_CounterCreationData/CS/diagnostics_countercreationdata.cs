// System.Diagnostics.CounterCreationData
// System.Diagnostics.CounterCreationData(string, string, PerformanceCounterType)
// System.Diagnostics.CounterCreationData()
// System.Diagnostics.CounterCreationData.CounterName
// System.Diagnostics.CounterCreationData.CounterHelp
// System.Diagnostics.CounterCreationData.CounterType

/* The following program demonstrates 'CounterCreationData' class,
   CounterCreationData(string, string, PerformanceCounterType)',
   'CounterCreationData()', 'CounterName', 'CounterHelp' and 
   'CounterType' members of 'System.Diagnostics.CounterCreationData'
   class. It creates the custom counters with 'CounterCreationData'  
   and binds them to 'PerformanceCounterCategory' object. */

// <Snippet1>
// <Snippet2>
// <Snippet3>
// <Snippet4>
// <Snippet5>
// <Snippet6>
using System;
using System.Diagnostics;

namespace MyDiagnostics
{
    class MyCounterCreationData
    {
        static void Main()
        {
            CounterCreationDataCollection myCol =
                                       new CounterCreationDataCollection();

            // Create two custom counter objects.
            CounterCreationData myCounter1 = new CounterCreationData("Counter1",
               "First custom counter", PerformanceCounterType.CounterDelta32);

            CounterCreationData myCounter2 = new CounterCreationData();

            // Set the properties of the 'CounterCreationData' object.
            myCounter2.CounterName = "Counter2";
            myCounter2.CounterHelp = "Second custom counter";
            myCounter2.CounterType = PerformanceCounterType.NumberOfItemsHEX32;

            // Add custom counter objects to CounterCreationDataCollection.
            myCol.Add(myCounter1);
            myCol.Add(myCounter2);

            if (PerformanceCounterCategory.Exists("New Counter Category"))
                PerformanceCounterCategory.Delete("New Counter Category");

            // Bind the counters to a PerformanceCounterCategory.
            PerformanceCounterCategory myCategory =
                  PerformanceCounterCategory.Create("New Counter Category", "Category Help",
                PerformanceCounterCategoryType.SingleInstance, myCol);


            Console.WriteLine("Counter Information:");
            Console.WriteLine("Category Name: " + myCategory.CategoryName);
            for (int i = 0; i < myCol.Count; i++)
            {
                // Display the properties of the CounterCreationData objects.
                Console.WriteLine("CounterName : " + myCol[i].CounterName);
                Console.WriteLine("CounterHelp : " + myCol[i].CounterHelp);
                Console.WriteLine("CounterType : " + myCol[i].CounterType);
            }
        }
    }
}
// </Snippet6>
// </Snippet5>
// </Snippet4>
// </Snippet3>
// </Snippet2>
// </Snippet1>
