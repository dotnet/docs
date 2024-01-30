' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet8>
Imports System.Globalization

Module Example8
    Public Sub Main()
        Dim dat As Date = #3/1/2011#
        Dim cultures() As CultureInfo = {CultureInfo.InvariantCulture,
                                        New CultureInfo("en-US"),
                                        New CultureInfo("fr-FR")}

        For Each culture In cultures
            Console.WriteLine("{0,-12} {1}", If(String.IsNullOrEmpty(culture.Name),
                           "Invariant", culture.Name),
                           dat.ToString("d", culture))
        Next
    End Sub
End Module
' The example displays the following output:
'       Invariant    03/01/2011
'       en-US        3/1/2011
'       fr-FR        01/03/2011
' </Snippet8>
