' Visual Basic .NET Document
Option Strict On

' <Snippet12>
Imports System.Globalization
Imports System.Threading

Module Example4
    Public Sub S1()
        Dim value As Double = 1634.92
        CultureInfo.CurrentCulture = New CultureInfo("fr-CA")
        Console.WriteLine("Current Culture: {0}",
                        CultureInfo.CurrentCulture.Name)
        Console.WriteLine("{0:C2}", value)
        Console.WriteLine()

        Thread.CurrentThread.CurrentCulture = New CultureInfo("fr")
        Console.WriteLine("Current Culture: {0}",
                        CultureInfo.CurrentCulture.Name)
        Console.WriteLine("{0:C2}", value)
    End Sub
End Module
' The example displays the following output:
'       Current Culture: fr-CA
'       1 634,92 $
'       
'       Current Culture: fr
'       1 634,92 €
' </Snippet12>

