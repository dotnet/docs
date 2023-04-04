' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim input As String = "Essential services are provided by regular expressions."
        Dim pattern As String = ".*(es)"
        Dim m As Match = Regex.Match(input, pattern, RegexOptions.IgnoreCase)
        If m.Success Then
            Console.WriteLine("'{0}' found at position {1}", _
                              m.Value, m.Index)
            Console.WriteLine("'es' found at position {0}", _
                              m.Groups(1).Index)
        End If
    End Sub
End Module
'    'Essential services are provided by regular expressions found at position 0
'    'es' found at position 47
' </Snippet2>
