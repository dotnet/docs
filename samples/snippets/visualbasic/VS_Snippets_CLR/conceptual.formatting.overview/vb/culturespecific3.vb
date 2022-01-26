' Visual Basic .NET Document
Option Strict On

' <Snippet19>
Imports System.Globalization

Module Example6
    Public Sub Main6()
        Dim cultureNames() As String = {"en-US", "fr-FR", "es-MX", "de-DE"}
        Dim value As Decimal = 1043.17D

        For Each cultureName In cultureNames
            ' Change the current culture.
            CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName)
            Console.WriteLine($"The current culture is {CultureInfo.CurrentCulture.Name}")
            Console.WriteLine(value.ToString("C2"))
            Console.WriteLine()
        Next
    End Sub
End Module
' The example displays the following output:
'       The current culture is en-US
'       $1,043.17
'       
'       The current culture is fr-FR
'       1 043,17 €
'       
'       The current culture is es-MX
'       $1,043.17
'       
'       The current culture is de-DE
'       1.043,17 €
' </Snippet19>
