Option Strict On
Option Infer On

Module Create1
    Sub Main()
        Create1Tuple()
        New1Tuple()
        Create2Tuple()
        New2Tuple()
        Create3Tuple()
        New3Tuple()
        Create4Tuple()
        New4Tuple()
        Create5Tuple()
        New5Tuple()
        Create6Tuple()
        New6Tuple()
        Create7Tuple()
        New7Tuple()
        'Create8Tuple()
        'New8Tuple()
        CreateNTuple()
        NewNTuple()
        Example()
    End Sub

    Private Sub Create1Tuple()
        ' <Snippet1>
        Dim tuple1 = Tuple.Create(12)
        Console.WriteLine(tuple1.Item1)     ' Displays 12
        ' </Snippet1>
    End Sub

    Private Sub New1Tuple()
        ' <Snippet2>
        Dim tuple1 = New Tuple(Of Integer)(12)
        Console.WriteLine(tuple1.Item1)     ' Displays 12
        ' </Snippet2>
    End Sub

    Private Sub Create2Tuple()
        ' <Snippet3>
        Dim tuple2 = Tuple.Create("New York", 32.68)
        Console.WriteLine("{0}: {1}", tuple2.Item1, tuple2.Item2)
        ' Displays New York: 32.68
        ' </Snippet3>
    End Sub

    Private Sub New2Tuple()
        ' <Snippet4>
        Dim tuple2 = New Tuple(Of String, Double)("New York", 32.68)
        Console.WriteLine("{0}: {1}", tuple2.Item1, tuple2.Item2)
        ' Displays New York: 32.68
        ' </Snippet4>
    End Sub

    Private Sub Create3Tuple()
        ' <Snippet5>
        Dim tuple3 = Tuple.Create("New York", 32.68, 51.87)
        Console.WriteLine("{0}: lo {1}, hi {2}", 
                          tuple3.Item1, tuple3.Item2, tuple3.Item3)
        ' Displays New York: lo 32.68, hi 51.87
        ' </Snippet5>
    End Sub

    Private Sub New3Tuple()
        ' <Snippet6>
        Dim tuple3 = New Tuple(Of String, Double, Double)("New York", 32.68, 51.87)
        Console.WriteLine("{0}: lo {1}, hi {2}", 
                          tuple3.Item1, tuple3.Item2, tuple3.Item3)
        ' Displays New York: lo 32.68, hi 51.87
        ' </Snippet6>
    End Sub

    Private Sub Create4Tuple()
        ' <Snippet7>
        Dim tuple4 = Tuple.Create("New York", 32.68, 51.87, 76.3)
        Console.WriteLine("{0}: Hi {1}, Lo {2}, Ave {3}",
                          tuple4.Item1, tuple4.Item4, tuple4.Item2,
                          tuple4.Item3)
        ' Displays New York: Hi 76.3, Lo 32.68, Ave 51.87
        ' </Snippet7>
    End Sub

    Private Sub New4Tuple()
        ' <Snippet8>
        Dim tuple4 = New Tuple(Of String, Double, Double, Double) _
                              ("New York", 32.68, 51.87, 76.3)
        Console.WriteLine("{0}: Hi {1}, Lo {2}, Ave {3}",
                          tuple4.Item1, tuple4.Item4, tuple4.Item2,
                          tuple4.Item3)
        ' Displays New York: Hi 76.3, Lo 32.68, Ave 51.87
        ' </Snippet8>
    End Sub

    Private Sub Create5Tuple()
        ' <Snippet9>
        Dim tuple5 = Tuple.Create("New York", 1990, 7322564, 2000, 
                                  8008278)
        Console.WriteLine("{0}: {1:N0} in {2}, {3:N0} in {4}",
                          tuple5.Item1, tuple5.Item3, tuple5.Item2,
                          tuple5.Item5, tuple5.Item4)
        ' Displays New York: 7,322,564 in 1990, 8,008,278 in 2000
        ' </Snippet9>
    End Sub

    Private Sub New5Tuple()
        ' <Snippet10>
        Dim tuple5 = New Tuple(Of String, Integer, Integer, 
                               Integer, Integer) _
                               ("New York", 1990, 7322564, 2000, 8008278)
        Console.WriteLine("{0}: {1:N0} in {2}, {3:N0} in {4}",
                          tuple5.Item1, tuple5.Item3, tuple5.Item2,
                          tuple5.Item5, tuple5.Item4)
        ' Displays New York: 7,322,564 in 1990, 8,008,278 in 2000
        ' </Snippet10>
    End Sub

    Private Sub Create6Tuple()
        ' <Snippet11>
        Dim tuple6 = Tuple.Create("Jane", 90, 87, 93, 67, 100)
        Console.WriteLine("Test scores for {0}: {1}, {2}, {3}, {4}, {5}",
                          tuple6.Item1, tuple6.Item2, tuple6.Item3,
                          tuple6.Item4, tuple6.Item5, tuple6.Item6)
        ' Displays Test scores for Jane: 90, 87, 93, 67, 100
        ' </Snippet11>
    End Sub

    Private Sub New6Tuple()
        ' <Snippet12>
        Dim tuple6 = New Tuple(Of String, Integer, Integer, Integer, 
                               Integer, Integer) _
                               ("Jane", 90, 87, 93, 67, 100)
        Console.WriteLine("Test scores for {0}: {1}, {2}, {3}, {4}, {5}",
                          tuple6.Item1, tuple6.Item2, tuple6.Item3,
                          tuple6.Item4, tuple6.Item5, tuple6.Item6)
        ' Displays Test scores for Jane: 90, 87, 93, 67, 100
        ' </Snippet12>
    End Sub

    Private Sub Create7Tuple()
        ' <Snippet13>
        Dim tuple7 = Tuple.Create("Jane", 90, 87, 93, 67, 100, 92)
        Console.WriteLine("Test scores for {0}: {1}, {2}, {3}, {4}, {5}, {6}",
                          tuple7.Item1, tuple7.Item2, tuple7.Item3,
                          tuple7.Item4, tuple7.Item5, tuple7.Item6,
                          tuple7.Item7)
        ' Displays Test scores for Jane: 90, 87, 93, 67, 100, 92
        ' </Snippet13>
    End Sub

    Private Sub New7Tuple()
        ' <Snippet14>
        Dim tuple7 = New Tuple(Of String, Integer, Integer, 
                               Integer, Integer, Integer, Integer) _
                               ("Jane", 90, 87, 93, 67, 100, 92)
        Console.WriteLine("Test scores for {0}: {1}, {2}, {3}, {4}, {5}, {6}",
                          tuple7.Item1, tuple7.Item2, tuple7.Item3,
                          tuple7.Item4, tuple7.Item5, tuple7.Item6,
                          tuple7.Item7)
        ' Displays Test scores for Jane: 90, 87, 93, 67, 100, 92
        ' </Snippet14>
    End Sub

    Private Sub CreateNTuple()
'         Dim innerTuple As Tuple(Of Integer, Integer, Integer, Integer, Integer, Integer) =
'             Tuple.Create(1960, 1670140, 1980, 1203339, 2000, 951270)
'         Dim tuple8 As Tuple(Of String, Integer, Integer, Integer, Integer, Integer, Integer, 
'             Tuple(Of Integer, Integer, Integer, Integer, Integer, Integer)) =
'             Tuple.Create("Detroit", 1900, 285704, 1920, 993078, 1940, 1623452, innerTuple)
    End Sub

    Private Sub NewNTuple()
        ' <Snippet18>
        Dim innerTuple = New Tuple(Of Integer, Integer, Integer, 
                                   Integer, Integer, Integer) _
                                   (1960, 1670140, 1980, 1203339, 2000, 
                                   951270)
        Dim tuple8 = New Tuple(Of String, Integer, Integer, Integer, 
                               Integer, Integer, Integer,  
                               Tuple(Of Integer, Integer, Integer, 
                                     Integer, Integer, Integer)) _
                               ("Detroit", 1900, 285704, 1920, 993078, 
                               1940, 1623452, innerTuple)
        Console.WriteLine("Population of {0} in:{13}   {1}: {2,10:N0} {13}" +
                          "   {3}: {4,10:N0} {13}" + 
                          "   {5}: {6,10:N0} {13}" + 
                          "   {7}: {8,10:N0} {13}" + 
                          "   {9}: {10,10:N0} {13}" + 
                          "   {11}: {12,10:N0} {13}",
                          tuple8.Item1, tuple8.Item2, tuple8.Item3,
                          tuple8.Item4, tuple8.Item5, tuple8.Item6,
                          tuple8.Item7, tuple8.Rest.Item1, tuple8.Rest.Item2,
                          tuple8.Rest.Item3, tuple8.Rest.Item4,
                          tuple8.Rest.Item5, tuple8.Rest.Item6, vbCrLf) 
        ' The example displays the following output:
        '       Population of Detroit in:
        '          1900:    285,704
        '          1920:    993,078
        '          1940:  1,623,452
        '          1960:  1,670,140
        '          1980:  1,203,339
        '          2000:    951,270            
        ' </Snippet18>
    End Sub

    Private Sub Example()
    End Sub
End Module
