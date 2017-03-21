            Dim data1 As New CounterCreationData("Trucks", "Number of orders", PerformanceCounterType.NumberOfItems32)
            Dim data2 As New CounterCreationData("Rate of sales", "Orders/second", PerformanceCounterType.RateOfCountsPerSecond32)
            Dim ccds As New CounterCreationDataCollection()
            ccds.Add(data1)
            ccds.Add(data2)
            Console.WriteLine("Creating Orders custom counter.")
            If Not PerformanceCounterCategory.Exists("Orders") Then
                PerformanceCounterCategory.Create("Orders", "Processed orders", PerformanceCounterCategoryType.MultiInstance, ccds)
            End If