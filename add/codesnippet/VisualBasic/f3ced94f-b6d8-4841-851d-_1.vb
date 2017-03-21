            Console.WriteLine("Creating Inventory custom counter")
            If Not PerformanceCounterCategory.Exists("Inventory") Then
                PerformanceCounterCategory.Create("Inventory", "Truck inventory", PerformanceCounterCategoryType.SingleInstance, "Trucks", "Number of trucks on hand")
            End If