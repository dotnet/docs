'<snippet1>
Imports System
Imports System.IO

Public Class CharsFromStr
    Public Shared Sub Main()
        Dim str As String = "Some number of characters"
        Dim b(str.Length) As Char

        Using sr As StringReader = New StringReader(str)
            ' Read 13 characters from the string into the array.
            sr.Read(b, 0, 13)
            Console.WriteLine(b)

            ' Read the rest of the string starting at the current string position.
            ' Put in the array starting at the 6th array member.
            sr.Read(b, 5, str.Length - 13)
            Console.WriteLine(b)
        End Using
    End Sub
End Class
' The example has the following output:
'
' Some number o
' Some f characters
'</snippet1>
