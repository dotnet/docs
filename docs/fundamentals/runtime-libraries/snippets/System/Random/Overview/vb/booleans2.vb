' Visual Basic .NET Document
Option Strict On

' <Snippet20>
Module Example3
    Public Sub Main()
        Dim totalTrue, totalFalse As Integer

        ' Generate 1,0000 random Booleans, and keep a running total.
        For ctr As Integer = 0 To 9999999
            Dim value As Boolean = NextBoolean()
            If value Then
                totalTrue += 1
            Else
                totalFalse += 1
            End If
        Next
        Console.WriteLine("Number of true values:  {0,7:N0} ({1:P3})",
                        totalTrue,
                        totalTrue / (totalTrue + totalFalse))
        Console.WriteLine("Number of false values: {0,7:N0} ({1:P3})",
                        totalFalse,
                        totalFalse / (totalTrue + totalFalse))
    End Sub

    Public Function NextBoolean() As Boolean
        Static rnd As New Random()
        Return Convert.ToBoolean(rnd.Next(0, 2))
    End Function
End Module
' The example displays the following output:
'       Number of true values:  499,777 (49.978 %)
'       Number of false values: 500,223 (50.022 %)
' </Snippet20>
