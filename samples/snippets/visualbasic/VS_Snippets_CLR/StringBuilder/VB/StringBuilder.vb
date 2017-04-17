' <Snippet1>
Imports System.Text

Public Module App 
    Public Sub Main() 
        ' <Snippet2>
        ' Create a StringBuilder that expects to hold 50 characters.
        ' Initialize the StringBuilder with "ABC".
        Dim sb As New StringBuilder("ABC", 50)
        ' </Snippet2>

        ' <Snippet3> 
        ' Append three characters (D, E, and F) to the end of the StringBuilder.
        sb.Append(New Char() {"D"c, "E"c, "F"c})
        ' </Snippet3>

        ' <Snippet4>
        ' Append a format string to the end of the StringBuilder.
        sb.AppendFormat("GHI{0}{1}", "J"c, "k"c)
        ' </Snippet4>

        ' <Snippet5>
        ' Display the number of characters in the StringBuilder and its string.
        Console.WriteLine("{0} chars: {1}", sb.Length, sb.ToString())
        ' </Snippet5>

        ' <Snippet6>
        ' Insert a string at the beginning of the StringBuilder.
        sb.Insert(0, "Alphabet: ")
        ' </Snippet6>

        ' <Snippet7>
        ' Replace all lowercase k's with uppercase K's.
        sb.Replace("k", "K")
        ' </Snippet7>

        ' Display the number of characters in the StringBuilder and its string.
        Console.WriteLine("{0} chars: {1}", sb.Length, sb.ToString())
    End Sub
End Module

' This code produces the following output.
'
' 11 chars: ABCDEFGHIJk
' 21 chars: Alphabet: ABCDEFGHIJK
' </Snippet1>
