         Dim myCategoryName As String
         Dim numberOfCounters As Integer
         Console.Write("Enter the category Name : ")
         myCategoryName = Console.ReadLine()
         ' Check if the category already exists or not.
         If Not PerformanceCounterCategory.Exists(myCategoryName) Then
            Console.Write("Enter the number of counters : ")
            numberOfCounters = Integer.Parse(Console.ReadLine())
            Dim myCounterCreationData(numberOfCounters-1) As CounterCreationData

            Dim i As Integer
            For i = 0 To numberOfCounters - 1
               Console.Write("Enter the counter name for {0} counter : ", i)
               myCounterCreationData(i) = New CounterCreationData()
               myCounterCreationData(i).CounterName = Console.ReadLine()
            Next i
            Dim myCounterCollection As New CounterCreationDataCollection(myCounterCreationData)
            ' Create the category.
                PerformanceCounterCategory.Create(myCategoryName, "Sample Category", _
                       PerformanceCounterCategoryType.SingleInstance, myCounterCollection)

            Console.WriteLine("The list of counters in 'CounterCollection' are :")

            For i = 0 To myCounterCollection.Count - 1
               Console.WriteLine("Counter {0} is '{1}'", i, _
                                             myCounterCollection(i).CounterName)
            Next i
         Else
            Console.WriteLine("The category already exists")
         End If