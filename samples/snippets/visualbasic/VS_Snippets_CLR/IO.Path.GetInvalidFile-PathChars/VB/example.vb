'<SNIPPET1>
Imports System
Imports System.IO

Namespace PathExample
    Public Class GetCharExample
        Public Shared Sub Main()
            ' Get a list of invalid path characters.
            Dim invalidPathChars() As Char = Path.GetInvalidPathChars()

            Console.WriteLine("The following characters are invalid in a path:")
            ShowChars(invalidPathChars)
            Console.WriteLine()

            ' Get a list of invalid file characters.
            Dim invalidFileChars() As Char = Path.GetInvalidFileNameChars()

            Console.WriteLine("The following characters are invalid in a filename:")
            ShowChars(invalidFileChars)
        End Sub

        Public Shared Sub ShowChars(charArray As Char())
            Console.WriteLine("Char" + vbTab + "Hex Value")
            ' Display each invalid character to the console.
            For Each someChar As Char In charArray
                If Char.IsWhiteSpace(someChar)
                    Console.WriteLine("," + vbTab + "{0:X4}", _
                        Microsoft.VisualBasic.Asc(someChar))
                Else
                    Console.WriteLine("{0:c}," + vbTab +"{1:X4}", someChar, _
                        Microsoft.VisualBasic.Asc(someChar))
                End If
            Next someChar
        End Sub
    End Class
End Namespace
' Note: Some characters may not be displayable on the console.
' The output will look something like:
'
' The following characters are invalid in a path:
' Char    Hex Value
' ",      0022
' <,      003C
' >,      003E
' |,      007C
' ...
'
' The following characters are invalid in a filename:
' Char    Hex Value
' ",      0022
' <,      003C
' >,      003E
' |,      007C
' ...
'</SNIPPET1>