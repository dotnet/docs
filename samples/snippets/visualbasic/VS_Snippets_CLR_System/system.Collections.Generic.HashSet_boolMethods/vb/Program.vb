'<snippet01>
Imports System
Imports System.Collections.Generic

Class Program

    '<snippet02>
    Shared Sub Main()

        Dim lowNumbers As HashSet(Of Integer) = New HashSet(Of Integer)()
        Dim allNumbers As HashSet(Of Integer) = New HashSet(Of Integer)()

        For i As Integer = 1 To 4
            lowNumbers.Add(i)
        Next i

        For i As Integer = 0 To 9
            allNumbers.Add(i)
        Next i


        Console.Write("lowNumbers contains {0} elements: ", lowNumbers.Count)
        DisplaySet(lowNumbers)

        Console.Write("allNumbers contains {0} elements: ", allNumbers.Count)
        DisplaySet(allNumbers)

        Console.WriteLine("lowNumbers overlaps allNumbers: {0}", _
            lowNumbers.Overlaps(allNumbers))

        Console.WriteLine("allNumbers and lowNumbers are equal sets: {0}", _
            allNumbers.SetEquals(lowNumbers))

        ' Show the results of sub/superset testing
        Console.WriteLine("lowNumbers is a subset of allNumbers: {0}", _
            lowNumbers.IsSubsetOf(allNumbers))
        Console.WriteLine("allNumbers is a superset of lowNumbers: {0}", _
            allNumbers.IsSupersetOf(lowNumbers))
        Console.WriteLine("lowNumbers is a proper subset of allNumbers: {0}", _
            lowNumbers.IsProperSubsetOf(allNumbers))
        Console.WriteLine("allNumbers is a proper superset of lowNumbers: {0}", _
            allNumbers.IsProperSupersetOf(lowNumbers))

        ' Modify allNumbers to remove numbers that are not in lowNumbers.
        allNumbers.IntersectWith(lowNumbers)
        Console.Write("allNumbers contains {0} elements: ", allNumbers.Count)
        DisplaySet(allNumbers)

        Console.WriteLine("allNumbers and lowNumbers are equal sets: {0}", _
            allNumbers.SetEquals(lowNumbers))

        ' Show the results of sub/superset testing with the modified set.
        Console.WriteLine("lowNumbers is a subset of allNumbers: {0}", _
            lowNumbers.IsSubsetOf(allNumbers))
        Console.WriteLine("allNumbers is a superset of lowNumbers: {0}", _
            allNumbers.IsSupersetOf(lowNumbers))
        Console.WriteLine("lowNumbers is a proper subset of allNumbers: {0}", _
            lowNumbers.IsProperSubsetOf(allNumbers))
        Console.WriteLine("allNumbers is a proper superset of lowNumbers: {0}", _
            allNumbers.IsProperSupersetOf(lowNumbers))
    End Sub
    ' This code example produces output similar to the following:
    ' lowNumbers contains 4 elements: { 1 2 3 4 }
    ' allNumbers contains 10 elements: { 0 1 2 3 4 5 6 7 8 9 }
    ' lowNumbers overlaps allNumbers: True
    ' allNumbers and lowNumbers are equal sets: False
    ' lowNumbers is a subset of allNumbers: True
    ' allNumbers is a superset of lowNumbers: True
    ' lowNumbers is a proper subset of allNumbers: True
    ' allNumbers is a proper superset of lowNumbers: True
    ' allNumbers contains 4 elements: { 1 2 3 4 }
    ' allNumbers and lowNumbers are equal sets: True
    ' lowNumbers is a subset of allNumbers: True
    ' allNumbers is a superset of lowNumbers: True
    ' lowNumbers is a proper subset of allNumbers: False
    ' allNumbers is a proper superset of lowNumbers: False
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
