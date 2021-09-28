Imports System

Module Program
    Sub Main(args As String())
        ' <MedianUsage>
        Dim numbers() As Double = {1.9, 2, 8, 4, 5.7, 6, 7.2, 0}

        Dim query = Aggregate num In numbers Into Median()

        Console.WriteLine("Double: Median = " & query)
        ' This code produces the following output:
        '
        ' Double: Median = 4.85
        ' </MedianUsage>

        ' <OverloadUsage>
        Dim numbers1() As Double = {1.9, 2, 8, 4, 5.7, 6, 7.2, 0}

        Dim query1 = Aggregate num In numbers1 Into Median()

        Console.WriteLine("Double: Median = " & query1)

        Dim numbers2() As Integer = {1, 2, 3, 4, 5}

        Dim query2 = Aggregate num In numbers2 Into Median()

        Console.WriteLine("Integer: Median = " & query2)

        ' This code produces the following output:
        '
        ' Double: Median = 4.85
        ' Integer: Median = 3
        ' </OverloadUsage>

        ' <GenericUsage>
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
        ' </GenericUsage>

        ' <SequenceUsage>
        Dim strings() As String = {"a", "b", "c", "d", "e"}

        Dim query5 = strings.AlternateElements()

        For Each element In query5
            Console.WriteLine(element)
        Next

        ' This code produces the following output:
        '
        ' a
        ' c
        ' e
        ' </SequenceUsage>

    End Sub
End Module
