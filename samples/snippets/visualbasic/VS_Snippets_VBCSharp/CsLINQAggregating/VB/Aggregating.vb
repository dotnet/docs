Module Aggregating
    Sub Main(ByVal args As String())
        Count()
    End Sub

    Sub Average()
        ' <Snippet1>

        Dim temperatures() As Double = {72.0, 81.5, 69.3, 88.6, 80.0, 68.5}

        Dim avg = Aggregate temp In temperatures Into Average()

        ' Display the result.
        MsgBox(avg)

        ' This code produces the following output:

        ' 76.65
        ' </Snippet1>
    End Sub

    Sub Count()
        ' <Snippet2>

        Dim temperatures() As Double = {72.0, 81.5, 69.3, 88.6, 80.0, 68.5}

        Dim highTemps As Integer = Aggregate temp In temperatures Into Count(temp >= 80)

        ' Display the result.
        MsgBox(highTemps)

        ' This code produces the following output:

        ' 3
        ' </Snippet2>
    End Sub

    Sub LongCount()
        ' <Snippet3>

        Dim temperatures() As Double = {72.0, 81.5, 69.3, 88.6, 80.0, 68.5}

        Dim numTemps As Long = Aggregate temp In temperatures Into LongCount()

        ' Display the result.
        MsgBox(numTemps)

        ' This code produces the following output:

        ' 6
        ' </Snippet3>
    End Sub

    Sub Max()
        ' <Snippet4>

        Dim temperatures() As Double = {72.0, 81.5, 69.3, 88.6, 80.0, 68.5}

        Dim maxTemp = Aggregate temp In temperatures Into Max()

        ' Display the result.
        MsgBox(maxTemp)

        ' This code produces the following output:

        ' 88.6
        ' </Snippet4>
    End Sub

    Sub Min()
        ' <Snippet5>

        Dim temperatures() As Double = {72.0, 81.5, 69.3, 88.6, 80.0, 68.5}

        Dim minTemp = Aggregate temp In temperatures Into Min()

        ' Display the result.
        MsgBox(minTemp)

        ' This code produces the following output:

        ' 68.5
        ' </Snippet5>
    End Sub

    Sub Sum()
        ' <Snippet6>

        Dim expenses() As Double = {560.0, 300.0, 1080.5, 29.95, 64.75, 200.0}

        Dim totalExpense = Aggregate expense In expenses Into Sum()

        ' Display the result.
        MsgBox(totalExpense)

        ' This code produces the following output:

        ' 2235.2
        ' </Snippet6>
    End Sub
End Module
