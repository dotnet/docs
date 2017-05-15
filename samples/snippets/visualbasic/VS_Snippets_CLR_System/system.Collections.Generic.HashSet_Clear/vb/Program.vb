'<snippet01>
Imports System
Imports System.Collections.Generic

Class Program

    '<snippet02>
    Shared Sub Main()

        Dim Numbers As HashSet(Of Integer) = New HashSet(Of Integer)()

        For i As Integer = 0 To 9
            Numbers.Add(i)
        Next i

        Console.Write("Numbers contains {0} elements: ", Numbers.Count)
        DisplaySet(Numbers)

        Numbers.Clear()
        Numbers.TrimExcess()

        Console.Write("Numbers contains {0} elements: ", Numbers.Count)
        DisplaySet(Numbers)

    End Sub
    ' This code example produces output similar to the following:
    ' Numbers contains 10 elements: { 0 1 2 3 4 5 6 7 8 9 }
    ' Numbers contains 0 elements: { }
    '</snippet02>

    Private Shared Sub DisplaySet(ByVal coll As HashSet(Of Integer))
        Console.Write("{")
        For Each i As Integer In coll
            Console.Write(" {0}", i)
        Next i
        Console.WriteLine(" }")
    End Sub

End Class
'</snippet01>
