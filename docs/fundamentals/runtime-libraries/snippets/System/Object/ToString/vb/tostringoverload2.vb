' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Globalization

Module Example7
    Public Sub Main()
        Dim cultureNames() As String = {"en-US", "en-GB", "fr-FR",
                                       "hr-HR", "ja-JP"}
        Dim value As Decimal = 1603.49D
        For Each cultureName In cultureNames
            Dim culture As New CultureInfo(cultureName)
            Console.WriteLine("{0}: {1}", culture.Name,
                           value.ToString("C2", culture))
        Next
    End Sub
End Module
' The example displays the following output:
'       en-US: $1,603.49
'       en-GB: £1,603.49
'       fr-FR: 1 603,49 €
'       hr-HR: 1.603,49 kn
'       ja-JP: ¥1,603.49
' </Snippet5>

