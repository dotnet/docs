' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization
Imports System.IO

Module Example9
    Public Sub Main()
        Dim sw As New StreamWriter(".\graphemes.txt")
        Dim grapheme As String = ChrW(&H61) + ChrW(&H308)
        sw.WriteLine(grapheme)

        Dim singleChar As String = ChrW(&HE4)
        sw.WriteLine(singleChar)

        sw.WriteLine("{0} = {1} (Culture-sensitive): {2}", grapheme, singleChar,
                   String.Equals(grapheme, singleChar,
                                 StringComparison.CurrentCulture))
        sw.WriteLine("{0} = {1} (Ordinal): {2}", grapheme, singleChar,
                   String.Equals(grapheme, singleChar,
                                 StringComparison.Ordinal))
        sw.WriteLine("{0} = {1} (Normalized Ordinal): {2}", grapheme, singleChar,
                   String.Equals(grapheme.Normalize(),
                                 singleChar.Normalize(),
                                 StringComparison.Ordinal))
        sw.Close()
    End Sub
End Module
' The example produces the following output:
'       ä
'       ä
'       ä = ä (Culture-sensitive): True
'       ä = ä (Ordinal): False
'       ä = ä (Normalized Ordinal): True
' </Snippet2>
