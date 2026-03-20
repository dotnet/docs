' Visual Basic .NET Document
Option Strict On

Module PrecisionList3
    Public Sub Main()
        ' <Snippet6>
        Dim values() As Single = {10.01, 2.88, 2.88, 2.88, 9.0}
        Dim result As Single = 27.65
        Dim total As Single
        For Each value In values
            total += value
        Next
        If total.Equals(result) Then
            Console.WriteLine("The sum of the values equals the total.")
        Else
            Console.WriteLine($"The sum of the values ({total}) does not equal the total ({result}).")
        End If
    End Sub

    ' The example displays the following output on .NET:
    '      The sum of the values (27.650002) does not equal the total (27.65).
    ' The example displays the following output on .NET Framework:
    '      The sum of the values (27.65) does not equal the total (27.65).
    ' </Snippet6>
End Module
