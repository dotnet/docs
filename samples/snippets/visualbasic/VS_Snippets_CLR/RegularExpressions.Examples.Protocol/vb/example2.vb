' Visual Basic .NET Document
Option Strict On

Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim url As String = "http://www.contoso.com:8080/letters/readme.html"
        Dim r As New Regex("^(?<proto>\w+)://[^/]+?(?<port>:\d+)?/",
                           RegexOptions.None, TimeSpan.FromMilliseconds(150))
        Dim m As Match = r.Match(url)
        If m.Success Then
            ' <Snippet2>
            Console.WriteLine(m.Groups("proto").Value + m.Groups("port").Value)
            ' </Snippet2>
        End If
    End Sub
End Module
' The example displays the following output:
'       http:8080

