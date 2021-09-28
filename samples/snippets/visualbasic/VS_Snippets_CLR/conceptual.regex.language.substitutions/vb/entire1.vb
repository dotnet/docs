' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim input As String = "ABC123DEF456"
        Dim pattern As String = "\d+"
        Dim substitution As String = "$_"
        Console.WriteLine("Original string:          {0}", input)
        Console.WriteLine("String with substitution: {0}", _
                          Regex.Replace(input, pattern, substitution))
    End Sub
End Module
' The example displays the following output:
'       Original string:          ABC123DEF456
'       String with substitution: ABCABC123DEF456DEFABC123DEF456
' </Snippet7>
