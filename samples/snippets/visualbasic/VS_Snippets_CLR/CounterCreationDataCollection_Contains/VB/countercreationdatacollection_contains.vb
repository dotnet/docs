' System.Diagnostics.CounterCreationDataCollection.Contains(CounterCreationData)
' System.Diagnostics.CounterCreationDataCollection.Remove(CounterCreationData)

' The following program demonstrates 'Contains' and 'Remove' methods of
' 'CounterCreationDataCollection' class. An instance of 'CounterCreationDataCollection'
' is created by passing an array of 'CounterCreationData'. A particular instance of
' 'CounterCreationData' is removed if it exist in the 'CounterCreationDataCollection'.

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
         Console.Write("Enter the category Name :")
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
            Dim myCounterCollection As New CounterCreationDataCollection()
            ' Add the 'CounterCreationData[]' to 'CounterCollection'.
            myCounterCollection.AddRange(myCounterCreationData)

                PerformanceCounterCategory.Create(myCategoryName, "Sample Category", _
                       PerformanceCounterCategoryType.SingleInstance, myCounterCollection)

            ' Remove an instance of 'CounterCreationData' from 'CounterCollection'.
            If myCounterCreationData.Length > 0 Then
               If myCounterCollection.Contains(myCounterCreationData(0)) Then
                  myCounterCollection.Remove(myCounterCreationData(0))
                  Console.WriteLine("'{0}' counter is removed from the " + _
                              "CounterCreationDataCollection", myCounterCreationData(0).CounterName)
               End If
            Else
               Console.WriteLine("The counters does not exist")
            End If
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
