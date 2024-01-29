' Visual Basic .NET Document
Option Strict On

' <Snippet22>
Imports System.Globalization

Module Example19
    Public Sub Main()
        Dim cultureNames() As String = {"da-DK", "en-US"}
        Dim ci As CompareInfo
        Dim str As String = "aerial"
        Dim ch As Char = "æ"c  ' U+00E6

        Console.Write("Ordinal comparison -- ")
        Console.WriteLine("Position of '{0}' in {1}: {2}", ch, str,
                        str.IndexOf(ch))

        For Each cultureName In cultureNames
            ci = CultureInfo.CreateSpecificCulture(cultureName).CompareInfo
            Console.Write("{0} cultural comparison -- ", cultureName)
            Console.WriteLine("Position of '{0}' in {1}: {2}", ch, str,
                           ci.IndexOf(str, ch))
        Next
    End Sub
End Module
' The example displays the following output:
'       Ordinal comparison -- Position of 'æ' in aerial: -1
'       da-DK cultural comparison -- Position of 'æ' in aerial: -1
'       en-US cultural comparison -- Position of 'æ' in aerial: 0
' </Snippet22>
