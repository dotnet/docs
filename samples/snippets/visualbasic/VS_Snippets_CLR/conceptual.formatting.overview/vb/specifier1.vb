' Visual Basic .NET Document
Option Strict On

Module Example16
    Public Sub Main16()
        ' <Snippet3>
        Dim integerValue As Integer = 60312
        Console.WriteLine(integerValue.ToString("X"))   ' Displays EB98.
        ' </Snippet3>

        ' <Snippet10>
        Dim cost As Double = 1632.54
        Console.WriteLine(cost.ToString("C", New System.Globalization.CultureInfo("en-US")))
        ' The example displays the following output:
        '       $1,632.54
        ' </Snippet10>
    End Sub
End Module

