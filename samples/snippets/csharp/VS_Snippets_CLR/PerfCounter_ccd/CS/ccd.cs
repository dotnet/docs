using System;
using System.Diagnostics;

public class Snippet
{
    public static void Main()
    {

        //<Snippet1>
        if (!PerformanceCounterCategory.Exists("Orders"))
        {
            CounterCreationData milk = new CounterCreationData();
            milk.CounterName = "milk";
            milk.CounterType = PerformanceCounterType.NumberOfItems32;

            CounterCreationData milkPerSecond = new CounterCreationData();
            milkPerSecond.CounterName = "milk orders/second";
            milkPerSecond.CounterType = PerformanceCounterType.RateOfCountsPerSecond32;

            CounterCreationDataCollection ccds = new CounterCreationDataCollection();
            ccds.Add(milkPerSecond);
            ccds.Add(milk);

            PerformanceCounterCategory.Create("Orders", "Number of processed orders",
                PerformanceCounterCategoryType.SingleInstance, ccds);

        }
        //</Snippet1>
    }
}