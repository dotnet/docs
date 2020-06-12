Option Explicit On
Option Strict On

' How to: Convert Strings into an Array of Characters in Visual Basic
' 1b54b686-ab29-413b-adce-6bd5422376eb
Class Class1b54b686ab29413badce6bd5422376eb
    Private Sub Method75()
        ' <snippet75>
        Dim testString1 As String = "ABC"
        ' Create an array containing "A", "B", and "C".
        Dim charArray() As Char = testString1.ToCharArray
        ' </snippet75>

        ' <snippet76>
        ' This string is made up of a surrogate pair (high surrogate
        ' U+D800 and low surrogate U+DC00) and a combining character 
        ' sequence (the letter "a" with the combining grave accent).
        Dim testString2 As String = ChrW(&HD800) & ChrW(&HDC00) & "a" & ChrW(&H300)

        ' Create and initialize a StringInfo object for the string.
        Dim si As New System.Globalization.StringInfo(testString2)

        ' Create and populate the array.
        Dim unicodeTestArray(si.LengthInTextElements - 1) As String
        For i As Integer = 0 To si.LengthInTextElements - 1
            unicodeTestArray(i) = si.SubstringByTextElements(i, 1)
        Next
        ' </snippet76>

    End Sub
End Class
