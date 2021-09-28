' Visual Basic .NET Document
Option Strict On

' <Snippet14>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim chars() As Char = {"a"c, "X"c, "8"c, ","c, " "c, ChrW(9), "!"c}

        For Each ch As Char In chars
            Console.WriteLine("'{0}': {1}", Regex.Escape(ch.ToString()), _
                              Char.GetUnicodeCategory(ch))
        Next
    End Sub
End Module
' The example displays the following output:
'       'a': LowercaseLetter
'       'X': UppercaseLetter
'       '8': DecimalDigitNumber
'       ',': OtherPunctuation
'       '\ ': SpaceSeparator
'       '\t': Control
'       '!': OtherPunctuation
' </Snippet14>
