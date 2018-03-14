Imports System.Collections.Generic
'<Snippet1>
Imports System.Runtime.CompilerServices

Module LINQExtension

    ' Extension method for the IEnumerable(of T) interface. 
    ' The method accepts only values of the Double type.
    <Extension()> 
    Function Median(ByVal source As IEnumerable(Of Double)) As Double
        If source.Count = 0 Then
            Throw New InvalidOperationException("Cannot compute median for an empty set.")
        End If

        Dim sortedSource = From number In source 
                           Order By number

        Dim itemIndex = sortedSource.Count \ 2

        If sortedSource.Count Mod 2 = 0 Then
            ' Even number of items in list.
            Return (sortedSource(itemIndex) + sortedSource(itemIndex - 1)) / 2
        Else
            ' Odd number of items in list.
            Return sortedSource(itemIndex)
        End If
    End Function
End Module
'</Snippet1>

Module MoreAggregates

    '<Snippet4>
    ' Integer overload

    <Extension()> 
    Function Median(ByVal source As IEnumerable(Of Integer)) As Double
        Return Aggregate num In source Select CDbl(num) Into med = Median()
    End Function
    '</Snippet4>

    '<Snippet7>
    ' Generic overload.

    <Extension()> 
    Function Median(Of T)(ByVal source As IEnumerable(Of T), 
                          ByVal selector As Func(Of T, Double)) As Double
        Return Aggregate num In source Select selector(num) Into med = Median()
    End Function
    '</Snippet7>

    '<Snippet9>
    ' Extension method for the IEnumerable(of T) interface. 
    ' The method returns every other element of a sequence.

    <Extension()> 
    Function AlternateElements(Of T)(
        ByVal source As IEnumerable(Of T)
        ) As IEnumerable(Of T)

        Dim list As New List(Of T)
        Dim i = 0
        For Each element In source
            If (i Mod 2 = 0) Then
                list.Add(element)
            End If
            i = i + 1
        Next
        Return list
    End Function
    '</Snippet9>
End Module

Module Module1

    Sub Main()

        '<Snippet2>
        Dim numbers1() As Double = {1.9, 2, 8, 4, 5.7, 6, 7.2, 0}

        Dim query1 = Aggregate num In numbers1 Into Median()

        Console.WriteLine("Double: Median = " & query1)

        '</Snippet2>

        '<Snippet3>
        ' This code produces the following output:
        '
        ' Double: Median = 4.85

        '</Snippet3>

        '<Snippet5>
        Dim numbers2() As Integer = {1, 2, 3, 4, 5}

        Dim query2 = Aggregate num In numbers2 Into Median()

        Console.WriteLine("Integer: Median = " & query2)

        '</Snippet5>

        '<Snippet6>
        ' This code produces the following output:
        '
        ' Double: Median = 4.85
        ' Integer: Median = 3
        '</Snippet6>

        '<Snippet8>
        Dim numbers3() As Integer = {1, 2, 3, 4, 5}

        ' You can use num as a parameter for the Median method 
        ' so that the compiler will implicitly convert its value to double.
        ' If there is no implicit conversion, the compiler will
        ' display an error message.

        Dim query3 = Aggregate num In numbers3 Into Median(num)

        Console.WriteLine("Integer: Median = " & query3)

        Dim numbers4() As String = {"one", "two", "three", "four", "five"}

        ' With the generic overload, you can also use numeric properties of objects.

        Dim query4 = Aggregate str In numbers4 Into Median(str.Length)

        Console.WriteLine("String: Median = " & query4)

        ' This code produces the following output:
        '
        ' Integer: Median = 3
        ' String: Median = 4
        '</Snippet8>

        '<Snippet10>
        Dim strings() As String = {"a", "b", "c", "d", "e"}

        Dim query = strings.AlternateElements()

        For Each element In query
            Console.WriteLine(element)
        Next

        ' This code produces the following output:
        '
        ' a
        ' c
        ' e
        '</Snippet10>
        Console.ReadKey()

    End Sub

End Module
