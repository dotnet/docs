Imports System

Module Program
    Sub Main(args As String())

    End Sub

    Sub FrameworkDiffs()
        '<framework_diffs>
        Const greeting As String = "Hel" & vbNullChar & "lo"
        Console.WriteLine($"{greeting.IndexOf(vbNullChar)}")

        ' The snippet prints:
        '
        ' '3' when running on .NET Framework and .NET Core 2.x - 3.x (Windows)
        ' '0' when running on .NET 5 or later (Windows)
        ' '0' when running on .NET Core 2.x - 3.x or .NET 5 (non-Windows)
        ' '3' when running on .NET Core 2.x or .NET 5+ (in invariant mode)
        '</framework_diffs>
    End Sub

    '<html_example>
    '
    ' THIS SAMPLE CODE IS INCORRECT.
    ' DO NOT USE IT IN PRODUCTION.
    '
    Function ContainsHtmlSensitiveCharacters(input As String) As Boolean
        If input.IndexOf("<") >= 0 Then Return True
        If input.IndexOf("&") >= 0 Then Return True
        Return False
    End Function
    '</html_example>
End Module
