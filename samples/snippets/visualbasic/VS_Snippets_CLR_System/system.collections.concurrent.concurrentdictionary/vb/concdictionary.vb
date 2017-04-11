
'<snippet1>
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
'</snippet1>

'<snippet2>
'Imports System.Collections.Concurrent

Class CD_TryXYZ

    ' Demonstrates:
    ' ConcurrentDictionary<TKey, TValue>.TryAdd()
    ' ConcurrentDictionary<TKey, TValue>.TryUpdate()
    ' ConcurrentDictionary<TKey, TValue>.TryRemove()
    Shared Sub Main()
        Dim numFailures As Integer = 0
        ' for bookkeeping
        ' Construct an empty dictionary
        Dim cd As ConcurrentDictionary(Of Integer, [String]) = New ConcurrentDictionary(Of Integer, String)()

        ' This should work
        If Not cd.TryAdd(1, "one") Then
            Console.WriteLine("CD.TryAdd() failed when it should have succeeded")
            numFailures += 1
        End If

        ' This shouldn't work -- key 1 is already in use
        If cd.TryAdd(1, "uno") Then
            Console.WriteLine("CD.TryAdd() succeeded when it should have failed")
            numFailures += 1
        End If

        ' Now change the value for key 1 from "one" to "uno" -- should work
        If Not cd.TryUpdate(1, "uno", "one") Then
            Console.WriteLine("CD.TryUpdate() failed when it should have succeeded")
            numFailures += 1
        End If

        ' Try to change the value for key 1 from "eine" to "one" 
        ' -- this shouldn't work, because the current value isn't "eine"
        If cd.TryUpdate(1, "one", "eine") Then
            Console.WriteLine("CD.TryUpdate() succeeded when it should have failed")
            numFailures += 1
        End If

        ' Remove key/value for key 1. Should work.
        Dim value1 As String = ""
        If Not cd.TryRemove(1, value1) Then
            Console.WriteLine("CD.TryRemove() failed when it should have succeeded")
            numFailures += 1
        End If

        ' Remove key/value for key 1. Shouldn't work, because I already removed it
        Dim value2 As String = ""
        If cd.TryRemove(1, value2) Then
            Console.WriteLine("CD.TryRemove() succeeded when it should have failed")
            numFailures += 1
        End If

        ' If nothing went wrong, say so
        If numFailures = 0 Then
            Console.WriteLine(" OK!")
        End If
    End Sub
End Class
'</snippet2>


'<snippet3>
' Imports System.Collections.Concurrent
' Imports System.Threading.Tasks
Class CD_GetOrAddOrUpdate

    ' Demonstrates:
    ' ConcurrentDictionary<TKey, TValue>.AddOrUpdate()
    ' ConcurrentDictionary<TKey, TValue>.GetOrAdd()
    ' ConcurrentDictionary<TKey, TValue>[]
    Shared Sub Main()
        ' Construct a ConcurrentDictionary
        Dim cd As New ConcurrentDictionary(Of Integer, Integer)()

        ' Bombard the ConcurrentDictionary with 10000 competing AddOrUpdates
        Parallel.For(0, 10000,
                       Sub(i)
                           ' Initial call will set cd[1] = 1. 
                           ' Ensuing calls will set cd[1] = cd[1] + 1
                           cd.AddOrUpdate(1, 1, Function(key, oldValue) oldValue + 1)
                       End Sub)

        Console.WriteLine("After 10000 AddOrUpdates, cd[1] = {0}, should be 10000", cd(1))

        ' Should return 100, as key 2 is not yet in the dictionary
        Dim value As Integer = cd.GetOrAdd(2, Function(key) 100)
        Console.WriteLine("After initial GetOrAdd, cd[2] = {0} (should be 100)", value)

        ' Should return 100, as key 2 is already set to that value
        value = cd.GetOrAdd(2, 10000)
        Console.WriteLine("After second GetOrAdd, cd[2] = {0} (should be 100)", value)
    End Sub
End Class
'</snippet3>
