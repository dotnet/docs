            Dim myCategoryName As String
            Dim numberOfCounters As Integer
            Console.Write("Enter the category Name : ")
            myCategoryName = Console.ReadLine()
            ' Check if the category already exists or not.
            If Not PerformanceCounterCategory.Exists(myCategoryName) Then
                Console.Write("Enter the number of counters : ")
                numberOfCounters = Integer.Parse(Console.ReadLine())
                Dim myCounterCreationData(numberOfCounters - 1) As CounterCreationData

                Dim i As Integer
                For i = 0 To numberOfCounters - 1
                    Console.Write("Enter the counter name for {0} counter ", i)
                    myCounterCreationData(i) = New CounterCreationData()
                    myCounterCreationData(i).CounterName = Console.ReadLine()
                Next i
                Dim myCounterCollection As New CounterCreationDataCollection(myCounterCreationData)
                Dim myInsertCounterCreationData As New CounterCreationData("CounterInsert", "", _
                                        PerformanceCounterType.NumberOfItems32)
                ' Insert an instance of 'CounterCreationData' in the 'CounterCreationDataCollection'.
                myCounterCollection.Insert(myCounterCollection.Count - 1, myInsertCounterCreationData)
                Console.WriteLine("'{0}' counter is inserted into 'CounterCreationDataCollection'", _
                                        myInsertCounterCreationData.CounterName)
                ' Create the category.
                PerformanceCounterCategory.Create(myCategoryName, "Sample Category", _
                   PerformanceCounterCategoryType.SingleInstance, myCounterCollection)

                For i = 0 To numberOfCounters - 1
                    myCounter = New PerformanceCounter(myCategoryName, _
                                                     myCounterCreationData(i).CounterName, "", False)
                Next i
                Console.WriteLine("The index of '{0}' counter is {1}", _
                   myInsertCounterCreationData.CounterName, myCounterCollection.IndexOf(myInsertCounterCreationData))
            Else
                Console.WriteLine("The category already exists")
            End If