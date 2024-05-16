Option Strict On

' <Snippet11>
Imports System.Globalization

Public Module Example11
    Public Sub Main11()
        Dim value As Decimal = 1603.42D
        Console.WriteLine(value.ToString("C3", New CultureInfo("en-US")))
        Console.WriteLine(value.ToString("C3", New CultureInfo("fr-FR")))
        Console.WriteLine(value.ToString("C3", New CultureInfo("de-DE")))
    End Sub
End Module
' The example displays the following output:
'       $1,603.420
'       1 603,420 €
'       1.603,420 €
' </Snippet11>
