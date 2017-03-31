'<snippet9>
Imports System
Imports System.IO
Imports System.Text

Public Class CharsToStr
    Public Shared Sub Main()
        Dim sb As New StringBuilder("Start with a string and add from ")
        Dim b() As Char = { "c", "h", "a", "r", ".", " ", "B", "u", "t", " ", "n", "o", "t", " ", "a", "l", "l" }

        Using sw As StringWriter = New StringWriter(sb)
            ' Write five characters from the array into the StringBuilder.
            sw.Write(b, 0, 5)
            Console.WriteLine(sb)
        End Using
    End Sub
End Class
' The example has the following output:
'
' Start with a string and add from char.

'</snippet9>
