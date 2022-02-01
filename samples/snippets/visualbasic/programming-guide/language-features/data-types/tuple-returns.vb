' <Snippet2>
Imports System.Globalization

Public Module NumericLibrary
    Public Function ParseInteger(value As String) As (Success As Boolean, Number As Int32)
        Dim number As Integer
        Return (Int32.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, number), number)
    End Function
End Module
' </Snippet2>

Module Module1
    Sub Main()
        StandardMethodCall()
        Console.WriteLine()
        MethodCallWithTuple()
        Console.ReadLine()
    End Sub

    Private Sub StandardMethodCall()
        ' <Snippet1>
        Dim numericString As String = "123456"
        Dim number As Integer
        Dim result = Int32.TryParse(numericString, number)
        Console.WriteLine($"{If(result, $"Success: {number:N0}", "Failure")}")
        '      Output: Success: 123,456
        ' </Snippet1>
    End Sub

    Private Sub MethodCallWithTuple()
        ' <Snippet3>
        Dim numericString As String = "123,456"
        Dim result = ParseInteger(numericString)
        Console.WriteLine($"{If(result.Success, $"Success: {result.Number:N0}", "Failure")}")
        Console.ReadLine()
        '      Output: Success: 123,456
        ' </Snippet3>
    End Sub
End Module
