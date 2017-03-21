Imports System.Collections.Concurrent
Imports System.Threading.Tasks
Class CD_Ctor
    ' Demonstrates:
    ' ConcurrentDictionary<TKey, TValue> ctor(concurrencyLevel, initialCapacity)
    ' ConcurrentDictionary<TKey, TValue>[TKey]
    Shared Sub Main()
        ' We know how many items we want to insert into the ConcurrentDictionary.
        ' So set the initial capacity to some prime number above that, to ensure that
        ' the ConcurrentDictionary does not need to be resized while initializing it.
        Dim NUMITEMS As Integer = 64
        Dim initialCapacity As Integer = 101

        ' The higher the concurrencyLevel, the higher the theoretical number of operations
        ' that could be performed concurrently on the ConcurrentDictionary. However, global
        ' operations like resizing the dictionary take longer as the concurrencyLevel rises. 
        ' For the purposes of this example, we'll compromise at numCores * 2.
        Dim numProcs As Integer = Environment.ProcessorCount
        Dim concurrencyLevel As Integer = numProcs * 2

        ' Construct the dictionary with the desired concurrencyLevel and initialCapacity
        Dim cd As New ConcurrentDictionary(Of Integer, Integer)(concurrencyLevel, initialCapacity)

        ' Initialize the dictionary
        For i As Integer = 0 To NUMITEMS - 1
            cd(i) = i * i
        Next

        Console.WriteLine("The square of 23 is {0} (should be {1})", cd(23), 23 * 23)
    End Sub
End Class