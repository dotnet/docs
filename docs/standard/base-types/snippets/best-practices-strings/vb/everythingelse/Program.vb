Imports System
Imports System.Globalization

Module Program
    Sub Main(args As String())
        EndZExample()
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

    '<indexof>
    Sub IndexOfExample()
        Console.WriteLine("resume".IndexOf("e"c, StringComparison.Ordinal)) ' "resume": prints '1'
        Console.WriteLine(("r" & ChrW(&HE9) & "sum" & ChrW(&HE9)).IndexOf("e"c, StringComparison.Ordinal)) ' "résumé": prints '-1'
        Console.WriteLine(("r" & ChrW(&HE9) & "sume" & ChrW(&H301)).IndexOf("e"c, StringComparison.Ordinal)) ' "résumé": prints '5'
        Console.WriteLine(("re" & ChrW(&H301) & "sum" & ChrW(&HE9)).IndexOf("e"c, StringComparison.Ordinal)) ' "résumé": prints '1'
        Console.WriteLine(("re" & ChrW(&H301) & "sume" & ChrW(&H301)).IndexOf("e"c, StringComparison.Ordinal)) ' "résumé": prints '1'
        Console.WriteLine("resume".IndexOf("e"c, StringComparison.OrdinalIgnoreCase)) ' "resume": prints '1'
        Console.WriteLine(("r" & ChrW(&HE9) & "sum" & ChrW(&HE9)).IndexOf("e"c, StringComparison.OrdinalIgnoreCase)) ' "résumé": prints '-1'
        Console.WriteLine(("r" & ChrW(&HE9) & "sume" & ChrW(&H301)).IndexOf("e"c, StringComparison.OrdinalIgnoreCase)) ' "résumé": prints '5'
        Console.WriteLine(("re" & ChrW(&H301) & "sum" & ChrW(&HE9)).IndexOf("e"c, StringComparison.OrdinalIgnoreCase)) ' "résumé": prints '1'
        Console.WriteLine(("re" & ChrW(&H301) & "sume" & ChrW(&H301)).IndexOf("e"c, StringComparison.OrdinalIgnoreCase)) ' "résumé": prints '1'
    End Sub
    '</indexof>

    '<indexof_string>
    Sub IndexOfStringExample()
        Console.WriteLine(("r" & ChrW(&HE9) & "sum" & ChrW(&HE9)).IndexOf("e")) ' "résumé": prints '-1' (not found)
        Console.WriteLine(("r" & ChrW(&HE9) & "sum" & ChrW(&HE9)).IndexOf(ChrW(&HE9).ToString())) ' "résumé": prints '1'
        Console.WriteLine(ChrW(&HE9).ToString().IndexOf("e" & ChrW(&H301))) ' prints '0'
    End Sub
    '</indexof_string>

    Sub EndZExample()
        '<endz>
        ' Set thread culture to Hungarian
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("hu-HU")
        Console.WriteLine("endz".EndsWith("z")) ' Prints 'False'

        ' Set thread culture to invariant culture
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture
        Console.WriteLine("endz".EndsWith("z")) ' Prints 'True'
        '</endz>
    End Sub

End Module
