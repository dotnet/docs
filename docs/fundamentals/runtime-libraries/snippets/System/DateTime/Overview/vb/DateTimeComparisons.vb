Class DateTimeComparisons
    Public Shared Sub Snippets()
        TestRoughlyEquals()
    End Sub

    ' <Snippet1>
    Public Shared Function RoughlyEquals(time As DateTime, timeWithWindow As DateTime,
                                 windowInSeconds As Integer,
                                 frequencyInSeconds As Integer) As Boolean
        Dim delta As Long = (timeWithWindow.Subtract(time)).TotalSeconds _
                                                Mod frequencyInSeconds

        If delta > windowInSeconds Then
            delta = frequencyInSeconds - delta
        End If

        Return Math.Abs(delta) < windowInSeconds
    End Function

    Public Shared Sub TestRoughlyEquals()
        Dim window As Integer = 10
        Dim freq As Integer = 60 * 60 * 2 ' 2 hours;
        Dim d1 As DateTime = DateTime.Now

        Dim d2 As DateTime = d1.AddSeconds(2 * window)
        Dim d3 As DateTime = d1.AddSeconds(-2 * window)
        Dim d4 As DateTime = d1.AddSeconds(window / 2)
        Dim d5 As DateTime = d1.AddSeconds(-window / 2)

        Dim d6 As DateTime = d1.AddHours(2).AddSeconds(2 * window)
        Dim d7 As DateTime = d1.AddHours(2).AddSeconds(-2 * window)
        Dim d8 As DateTime = d1.AddHours(2).AddSeconds(window / 2)
        Dim d9 As DateTime = d1.AddHours(2).AddSeconds(-window / 2)

        Console.WriteLine($"d1 ({d1}) ~= d1 ({d1}): {RoughlyEquals(d1, d1, window, freq)}")
        Console.WriteLine($"d1 ({d1}) ~= d2 ({d2}): {RoughlyEquals(d1, d2, window, freq)}")
        Console.WriteLine($"d1 ({d1}) ~= d3 ({d3}): {RoughlyEquals(d1, d3, window, freq)}")
        Console.WriteLine($"d1 ({d1}) ~= d4 ({d4}): {RoughlyEquals(d1, d4, window, freq)}")
        Console.WriteLine($"d1 ({d1}) ~= d5 ({d5}): {RoughlyEquals(d1, d5, window, freq)}")

        Console.WriteLine($"d1 ({d1}) ~= d6 ({d6}): {RoughlyEquals(d1, d6, window, freq)}")
        Console.WriteLine($"d1 ({d1}) ~= d7 ({d7}): {RoughlyEquals(d1, d7, window, freq)}")
        Console.WriteLine($"d1 ({d1}) ~= d8 ({d8}): {RoughlyEquals(d1, d8, window, freq)}")
        Console.WriteLine($"d1 ({d1}) ~= d9 ({d9}): {RoughlyEquals(d1, d9, window, freq)}")
    End Sub
    ' The example displays output similar to the following:
    '    d1 (1/28/2010 9:01:26 PM) ~= d1 (1/28/2010 9:01:26 PM): True
    '    d1 (1/28/2010 9:01:26 PM) ~= d2 (1/28/2010 9:01:46 PM): False
    '    d1 (1/28/2010 9:01:26 PM) ~= d3 (1/28/2010 9:01:06 PM): False
    '    d1 (1/28/2010 9:01:26 PM) ~= d4 (1/28/2010 9:01:31 PM): True
    '    d1 (1/28/2010 9:01:26 PM) ~= d5 (1/28/2010 9:01:21 PM): True
    '    d1 (1/28/2010 9:01:26 PM) ~= d6 (1/28/2010 11:01:46 PM): False
    '    d1 (1/28/2010 9:01:26 PM) ~= d7 (1/28/2010 11:01:06 PM): False
    '    d1 (1/28/2010 9:01:26 PM) ~= d8 (1/28/2010 11:01:31 PM): True
    '    d1 (1/28/2010 9:01:26 PM) ~= d9 (1/28/2010 11:01:21 PM): True
    ' </Snippet1>

End Class
