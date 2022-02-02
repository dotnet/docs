' <ParseIntegerReturnsTuple>
Imports System.Globalization

Public Module NumericLibrary
    Public Function ParseInteger(value As String) As (Success As Boolean, Number As Integer)
        Dim number As Integer
        Return (Integer.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, number), number)
    End Function
End Module
' </ParseIntegerReturnsTuple>

Module TupleReturns
    Sub Run()
        StandardMethodCall()
        Console.WriteLine()
        MethodCallWithTuple()
        Console.ReadLine()
    End Sub

    Private Sub StandardMethodCall()
        ' <StandardMethodCall>
        Dim numericString As String = "123456"
        Dim number As Integer
        Dim result = Integer.TryParse(numericString, number)
        Console.WriteLine($"{If(result, $"Success: {number:N0}", "Failure")}")
        '      Output: Success: 123,456
        ' </StandardMethodCall>
    End Sub

    Private Sub MethodCallWithTuple()
        ' <MethodCallWithTuple>
        Dim numericString As String = "123,456"
        Dim result = ParseInteger(numericString)
        Console.WriteLine($"{If(result.Success, $"Success: {result.Number:N0}", "Failure")}")
        Console.ReadLine()
        '      Output: Success: 123,456
        ' </MethodCallWithTuple>
    End Sub
End Module
