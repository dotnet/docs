' ********************************************************
Option Infer On
Imports System.Collections.Generic

Module Module1

    Sub Main()

        '<Snippet1>
        ' Data source.
        Dim numbers() As Integer = {0, 1, 2, 3, 4, 5, 6}

        ' Query creation.
        Dim evensQuery = From num In numbers
                         Where num Mod 2 = 0
                         Select num

        ' Query execution.
        For Each number In evensQuery
            Console.Write(number & " ")
        Next
        '</Snippet1>

        '<Snippet2>
        ' Create a data source from an XML document.
        Dim contacts = XElement.Load("c:\myContactList.xml")
        '</Snippet2>

        '<Snippet3>
        Dim numberArray() = {0, 1, 2, 3, 4, 5, 6}

        Dim evensQuery2 = From num In numberArray
                          Where num Mod 2 = 0
                          Select num

        Console.WriteLine("Evens in original array:")
        For Each number In evensQuery2
            Console.Write("  " & number)
        Next
        Console.WriteLine()

        ' Change a few array elements.
        numberArray(1) = 10
        numberArray(4) = 22
        numberArray(6) = 8

        ' Run the same query again.
        Console.WriteLine(vbCrLf & "Evens in changed array:")
        For Each number In evensQuery2
            Console.Write("  " & number)
        Next
        Console.WriteLine()
        '</Snippet3>

        '<Snippet4>
        Dim numEvens = (From num In numbers
                        Where num Mod 2 = 0
                        Select num).Count()
        '</Snippet4>

        '<Snippet5>
        Dim numEvensAgg = Aggregate num In numbers
                          Where num Mod 2 = 0
                          Select num
                          Into Count()
        '</Snippet5>

        '<Snippet6>
        ' Immediate execution.
        Dim evensList = (From num In numbers
                         Where num Mod 2 = 0
                         Select num).ToList()

        ' Deferred execution.
        Dim evensQuery3 = From num In numbers
                          Where num Mod 2 = 0
                          Select num
        ' . . .
        Dim evensArray = evensQuery3.ToArray()
        '</Snippet6>

        '<Snippet7>
        ' Query execution that results in a sequence of values.
        For Each number In evensQuery
            Console.Write(number & " ")
        Next

        ' Query execution that results in a single value.
        Dim evens = evensQuery.Count()
        '</Snippet7>
    End Sub

End Module
