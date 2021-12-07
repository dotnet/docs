' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Globalization

Module Example
    Public Sub Main0()
        Dim date1 As Date = #6/30/2009#
        Console.WriteLine("D Format Specifier:     {0:D}", date1)
        Dim longPattern As String = CultureInfo.CurrentCulture.DateTimeFormat.LongDatePattern
        Console.WriteLine("'{0}' custom format string:     {1}",
                          longPattern, date1.ToString(longPattern))
    End Sub
End Module
' The example displays the following output when run on a system whose
' current culture is en-US:
'    D Format Specifier:     Tuesday, June 30, 2009
'    'dddd, MMMM dd, yyyy' custom format string:     Tuesday, June 30, 2009
' </Snippet5>

