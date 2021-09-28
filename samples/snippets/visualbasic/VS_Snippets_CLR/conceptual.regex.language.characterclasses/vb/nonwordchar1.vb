' Visual Basic .NET Document
Option Strict On

' <Snippet9>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim pattern As String = "\b(\w+)(\W){1,2}"
        Dim input As String = "The old, grey mare slowly walked across the narrow, green pasture."
        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine(match.Value)
            Console.Write("   Non-word character(s):")
            Dim captures As CaptureCollection = match.Groups(2).Captures
            For ctr As Integer = 0 To captures.Count - 1
                Console.Write("'{0}' (\u{1}){2}", captures(ctr).Value, _
                              Convert.ToUInt16(captures(ctr).Value.Chars(0)).ToString("X4"), _
                              If(ctr < captures.Count - 1, ", ", ""))
            Next
            Console.WriteLine()
        Next
    End Sub
End Module
' The example displays the following output:
'       The
'          Non-word character(s):' ' (\u0020)
'       old,
'          Non-word character(s):',' (\u002C), ' ' (\u0020)
'       grey
'          Non-word character(s):' ' (\u0020)
'       mare
'          Non-word character(s):' ' (\u0020)
'       slowly
'          Non-word character(s):' ' (\u0020)
'       walked
'          Non-word character(s):' ' (\u0020)
'       across
'          Non-word character(s):' ' (\u0020)
'       the
'          Non-word character(s):' ' (\u0020)
'       narrow,
'          Non-word character(s):',' (\u002C), ' ' (\u0020)
'       green
'          Non-word character(s):' ' (\u0020)
'       pasture.
'          Non-word character(s):'.' (\u002E)
' </Snippet9>
