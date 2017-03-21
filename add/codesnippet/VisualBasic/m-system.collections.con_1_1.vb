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