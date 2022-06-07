' Visual Basic .NET Document
Option Strict On

Imports System.Text.RegularExpressions

Module DetermineExample
    Public Sub Main()
        Dim rgx As New Regex("\w*\s", RegexOptions.IgnoreCase)
        ' <Snippet19>
        If (rgx.Options And RegexOptions.IgnoreCase) = RegexOptions.IgnoreCase Then
            Console.WriteLine("Case-insensitive pattern comparison.")
        Else
            Console.WriteLine("Case-sensitive pattern comparison.")
        End If
        ' </Snippet19>
        ' <Snippet20>
        If rgx.Options = RegexOptions.None Then
            Console.WriteLine("No options have been set.")
        End If
        ' </Snippet20>   
    End Sub
End Module

