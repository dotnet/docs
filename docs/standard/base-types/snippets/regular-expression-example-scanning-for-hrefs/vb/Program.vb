Option Strict On

Imports System.Text.RegularExpressions

Public Module Example
    ' <main>
    Public Sub Main()
        Dim inputString As String = "My favorite web sites include:</P>" &
                                    "<A HREF=""https://docs.microsoft.com/en-us/dotnet/"">" &
                                    ".NET Documentation</A></P>" &
                                    "<A HREF=""http://www.microsoft.com"">" &
                                    "Microsoft Corporation Home Page</A></P>" &
                                    "<A HREF=""https://devblogs.microsoft.com/dotnet/"">" &
                                    ".NET Blog</A></P>"
        DumpHRefs(inputString)
    End Sub
    ' The example displays the following output:
    '       Found href https://docs.microsoft.com/dotnet/ at 43
    '       Found href http://www.microsoft.com at 114
    '       Found href https://devblogs.microsoft.com/dotnet/ at 188
    ' </main>

    ' <regex>
    Private Sub DumpHRefs(inputString As String)
        Dim hrefPattern As String = "href\s*=\s*(?:[""'](?<1>[^""']*)[""']|(?<1>[^>\s]+))"

        Try
            Dim regexMatch = Regex.Match(inputString, hrefPattern,
                                         RegexOptions.IgnoreCase Or RegexOptions.Compiled,
                                         TimeSpan.FromSeconds(1))
            Do While regexMatch.Success
                Console.WriteLine($"Found href {regexMatch.Groups(1)} at {regexMatch.Groups(1).Index}.")
                regexMatch = regexMatch.NextMatch()
            Loop
        Catch e As RegexMatchTimeoutException
            Console.WriteLine("The matching operation timed out.")
        End Try
    End Sub
    ' </regex>
End Module
