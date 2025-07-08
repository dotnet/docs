' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example2
    Public Sub Main()
        Console.WriteLine("The current UI culture: {0}",
                        CultureInfo.CurrentUICulture.Name)

        CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr-FR")
        Console.WriteLine("The current UI culture: {0}",
                        CultureInfo.CurrentUICulture.Name)
    End Sub
End Module
' The example displays output like the following:
'       The current UI culture: en-US
'       The current UI culture: fr-FR
' </Snippet1>
