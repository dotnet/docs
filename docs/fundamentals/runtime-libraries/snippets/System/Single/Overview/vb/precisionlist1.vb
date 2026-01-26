Module Example10
    Public Sub Main()
        ' <Snippet5>
        Dim value1 As Double = 1 / 3
        Dim sValue2 As Single = 1 / 3
        Dim value2 As Double = CDbl(sValue2)
        Console.WriteLine("{0} = {1}: {2}", value1, value2, value1.Equals(value2))

        ' The example displays the following output:
        '       0.3333333333333333 = 0.3333333432674408: False
        ' </Snippet5>
    End Sub
End Module
