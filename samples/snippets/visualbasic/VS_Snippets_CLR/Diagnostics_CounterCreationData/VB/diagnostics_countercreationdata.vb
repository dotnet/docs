' System.Diagnostics.CounterCreationData
' System.Diagnostics.CounterCreationData(string, string, PerformanceCounterType)
' System.Diagnostics.CounterCreationData()
' System.Diagnostics.CounterCreationData.CounterName
' System.Diagnostics.CounterCreationData.CounterHelp
' System.Diagnostics.CounterCreationData.CounterType

' The following program demonstrates 'CounterCreationData' class,
' CounterCreationData(string, string, PerformanceCounterType)',
' 'CounterCreationData()', 'CounterName', 'CounterHelp' and 
' 'CounterType' members of 'System.Diagnostics.CounterCreationData'
' class. It creates the custom counters with 'CounterCreationData'  
' and binds them to 'PerformanceCounterCategory' object.

' <Snippet1>
' <Snippet2>
' <Snippet3>
' <Snippet4>
' <Snippet5>
' <Snippet6>
Imports System
Imports System.Diagnostics

Namespace MyDiagnostics

    Class MyCounterCreationData

        Shared Sub Main()
            Dim myCol As New CounterCreationDataCollection()

            ' Create two custom counter objects.
            Dim myCounter1 As New CounterCreationData("Counter1", "First custom counter", _
                                      PerformanceCounterType.CounterDelta32)
            Dim myCounter2 As New CounterCreationData()

            ' Set the properties of the 'CounterCreationData' object.
            myCounter2.CounterName = "Counter2"
            myCounter2.CounterHelp = "Second custom counter"
            myCounter2.CounterType = PerformanceCounterType.NumberOfItemsHEX32

            ' Add custom counter objects to CounterCreationDataCollection.
            myCol.Add(myCounter1)
            myCol.Add(myCounter2)

            If PerformanceCounterCategory.Exists("New Counter Category") Then
                PerformanceCounterCategory.Delete("New Counter Category")
            End If
            ' Bind the counters to a PerformanceCounterCategory.
            Dim myCategory As PerformanceCounterCategory = PerformanceCounterCategory.Create("New " + _
                   "Counter Category", "Category Help", _
                   PerformanceCounterCategoryType.SingleInstance, myCol)

            Console.WriteLine("Counter Information:")
            Console.WriteLine("Category Name: " + myCategory.CategoryName)
            Dim i As Integer
            For i = 0 To myCol.Count - 1
                ' Display the properties of the CounterCreationData objects.
                Console.WriteLine("CounterName : " + myCol(i).CounterName)
                Console.WriteLine("CounterHelp : " + myCol(i).CounterHelp)
                Console.WriteLine("CounterType : " + myCol(i).CounterType.ToString())
            Next i
        End Sub 'Main
    End Class 'MyCounterCreationData
End Namespace 'MyDiagnostics
' </Snippet6>
' </Snippet5>
' </Snippet4>
' </Snippet3>
' </Snippet2>
' </Snippet1>