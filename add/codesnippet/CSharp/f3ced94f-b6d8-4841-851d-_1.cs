            Console.WriteLine("Creating Inventory custom counter");
            if (!PerformanceCounterCategory.Exists("Inventory"))
                PerformanceCounterCategory.Create("Inventory",
                    "Truck inventory",
                    PerformanceCounterCategoryType.SingleInstance,
                    "Trucks", "Number of trucks on hand");