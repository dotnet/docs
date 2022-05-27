' Visual Basic .NET Document
Option Strict On

Module Example17
    Public Sub Main17()
        ' <Snippet4>
        Dim thisDay As DayOfWeek = DayOfWeek.Monday
        Dim formatStrings() As String = {"G", "F", "D", "X"}

        For Each formatString As String In formatStrings
            Console.WriteLine(thisDay.ToString(formatString))
        Next
        ' The example displays the following output:
        '       Monday
        '       Monday
        '       1
        '       00000001
        ' </Snippet4>
    End Sub
End Module
