' Visual Basic .NET Document
Option Strict On

' <Snippet12>
Module Example4
    Public Sub Main()
        Dim one1 As Single = 0.1 * 10
        Dim one2 As Single = 0
        For ctr As Integer = 1 To 10
            one2 += CSng(0.1)
        Next
        Console.WriteLine("{0:R} = {1:R}: {2}", one1, one2, one1.Equals(one2))
        Console.WriteLine("{0:R} is approximately equal to {1:R}: {2}",
                        one1, one2,
                        IsApproximatelyEqual(one1, one2, 0.000001))
    End Sub

    Function IsApproximatelyEqual(value1 As Single, value2 As Single,
                                 epsilon As Single) As Boolean
        ' If they are equal anyway, just return True.
        If value1.Equals(value2) Then Return True

        ' Handle NaN, Infinity.
        If Single.IsInfinity(value1) Or Single.IsNaN(value1) Then
            Return value1.Equals(value2)
        ElseIf Single.IsInfinity(value2) Or Single.IsNaN(value2) Then
            Return value1.Equals(value2)
        End If

        ' Handle zero to avoid division by zero
        Dim divisor As Single = Math.Max(value1, value2)
        If divisor.Equals(0) Then
            divisor = Math.Min(value1, value2)
        End If

        Return Math.Abs(value1 - value2) / divisor <= epsilon
    End Function
End Module
' The example displays the following output:
'       1 = 1.00000012: False
'       1 is approximately equal to 1.00000012: True
' </Snippet12>
