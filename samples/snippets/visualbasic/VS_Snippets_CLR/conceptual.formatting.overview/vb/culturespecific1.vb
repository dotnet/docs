' Visual Basic .NET Document
Option Strict On

' <Snippet17>
Imports System.Globalization
Imports System.Threading

Module Example
    Public Sub Main()
        Dim cultureNames() As String = {"en-US", "fr-FR", "es-MX", "de-DE"}
        Dim dateToFormat As Date = #5/28/2012 11:30AM#

        For Each cultureName In cultureNames
            ' Change the current thread culture.
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName)
            Console.WriteLine("The current culture is {0}",
                              Thread.CurrentThread.CurrentCulture.Name)
            Console.WriteLine(dateToFormat.ToString("F"))
            Console.WriteLine()
        Next
    End Sub
End Module
' The example displays the following output:
'       The current culture is en-US
'       Monday, May 28, 2012 11:30:00 AM
'       
'       The current culture is fr-FR
'       lundi 28 mai 2012 11:30:00
'       
'       The current culture is es-MX
'       lunes, 28 de mayo de 2012 11:30:00 a.m.
'       
'       The current culture is de-DE
'       Montag, 28. Mai 2012 11:30:00 
' </Snippet17>

