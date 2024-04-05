' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Globalization

Module Example3
    Public Sub S1()
        Dim culture As CultureInfo = CultureInfo.CurrentCulture
        Console.WriteLine("The current culture is {0} [{1}]",
                        culture.NativeName, culture.Name)
    End Sub
End Module
' The example displays output like the following:
'     The current culture is English (United States) [en-US]
' </Snippet5>
