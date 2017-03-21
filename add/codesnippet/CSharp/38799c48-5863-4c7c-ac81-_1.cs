            CounterCreationData data1 = new CounterCreationData("Trucks",
                "Number of orders", PerformanceCounterType.NumberOfItems32);
            CounterCreationData data2 = new CounterCreationData("Rate of sales",
                "Orders/second", PerformanceCounterType.RateOfCountsPerSecond32);
            CounterCreationDataCollection ccds = new CounterCreationDataCollection();
            ccds.Add(data1);
            ccds.Add(data2);
            Console.WriteLine("Creating Orders custom counter.");
            if (!PerformanceCounterCategory.Exists("Orders"))
                PerformanceCounterCategory.Create("Orders",
                    "Processed orders",
                    PerformanceCounterCategoryType.MultiInstance,
                    ccds);