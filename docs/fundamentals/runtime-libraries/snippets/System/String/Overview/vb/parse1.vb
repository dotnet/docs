' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet9>
Imports System.Globalization

Module Example18
    Public Sub Main()
        Dim dateString As String = "07/10/2011"
        Dim cultures() As CultureInfo = {CultureInfo.InvariantCulture,
                                        CultureInfo.CreateSpecificCulture("en-GB"),
                                        CultureInfo.CreateSpecificCulture("en-US")}
        Console.WriteLine("{0,-12} {1,10} {2,8} {3,8}", "Date String", "Culture",
                                                 "Month", "Day")
        Console.WriteLine()
        For Each culture In cultures
            Dim dat As Date = DateTime.Parse(dateString, culture)
            Console.WriteLine("{0,-12} {1,10} {2,8} {3,8}", dateString,
                           If(String.IsNullOrEmpty(culture.Name),
                           "Invariant", culture.Name),
                           dat.Month, dat.Day)
        Next
    End Sub
End Module
' The example displays the following output:
'       Date String     Culture    Month      Day
'       
'       07/10/2011    Invariant        7       10
'       07/10/2011        en-GB       10        7
'       07/10/2011        en-US        7       10
' </Snippet9>

