' System.Diagnostics.CounterCreationDataCollection.Insert(int,CounterCreationData) 
' System.Diagnostics.CounterCreationDataCollection.IndexOf(CounterCreationData)

' The following program demonstrates 'IndexOf(CounterCreationData)' and
' 'Insert(int, CounterCreationData)' methods of 'CounterCreationDataCollection
' ' class. An instance of 'CounterCreationDataCollection' is created by
' passing an array of 'CounterCreationData' to the constructor. A counter is
' inserted into the 'CounterCreationDataCollection' at specified index. The
' inserted counter and its index are displayed to the console.

Imports System
Imports System.Diagnostics

Public Class CounterCreationDataCollectionExample
    Private Shared myCounter As PerformanceCounter

    Public Shared Sub Main()
        Try
            ' <Snippet1>
            ' <Snippet2>
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
            ' </Snippet2>
            ' </Snippet1>
        Catch e As Exception
            Console.WriteLine("Exception: {0}.", e.Message)
            Return
        End Try
    End Sub 'Main
End Class 'CounterCreationDataCollectionExample
