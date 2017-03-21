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