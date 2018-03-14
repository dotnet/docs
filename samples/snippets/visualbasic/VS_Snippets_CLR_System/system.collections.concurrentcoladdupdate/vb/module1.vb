'<snippet1>
Imports System.Collections.Concurrent

Class CD_Ctor
    ' Demonstrates: 
    '      ConcurrentDictionary<TKey, TValue> ctor(concurrencyLevel, initialCapacity) 
    '      ConcurrentDictionary<TKey, TValue>[TKey] 
    Public Shared Sub Main()
        ' We know how many items we want to insert into the ConcurrentDictionary. 
        ' So set the initial capacity to some prime number above that, to ensure that 
        ' the ConcurrentDictionary does not need to be resized while initializing it. 
        Dim HIGHNUMBER As Integer = 64
        Dim initialCapacity As Integer = 101

        ' The higher the concurrencyLevel, the higher the theoretical number of operations 
        ' that could be performed concurrently on the ConcurrentDictionary.  However, global 
        ' operations like resizing the dictionary take longer as the concurrencyLevel rises.  
        ' For the purposes of this example, we'll compromise at numCores * 2. 
        Dim numProcs As Integer = Environment.ProcessorCount
        Dim concurrencyLevel As Integer = numProcs * 2

        ' Construct the dictionary with the desired concurrencyLevel and initialCapacity
        Dim cd As New ConcurrentDictionary(Of Integer, Integer)(concurrencyLevel, initialCapacity)

        ' Initialize the dictionary 
        For i As Integer = 1 To HIGHNUMBER
            cd(i) = i * i
        Next

        Console.WriteLine("The square of 23 is {0} (should be {1})", cd(23), 23 * 23)

        ' Now iterate through, adding one to the end of the list. Existing items should be updated to be divided by their 
        ' key  and a new item will be added that is the square of its key.
        For i As Integer = 1 To HIGHNUMBER + 1

            cd.AddOrUpdate(i, i * i, Function(k, v)
                                         Return v / i
                                     End Function)
        Next

        Console.WriteLine("The square root of 529 is {0} (should be {1})", cd(23), 529 / 23)
        Console.WriteLine("The square of 65 is {0} (should be {1})", cd(HIGHNUMBER + 1), ((HIGHNUMBER + 1) * (HIGHNUMBER + 1)))

    End Sub
End Class
'</snippet1>

