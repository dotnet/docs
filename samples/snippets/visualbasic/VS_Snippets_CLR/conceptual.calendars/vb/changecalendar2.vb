' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization
Imports System.Threading

Module Example
    Public Sub Main()
        Dim date1 As Date = #6/20/2011#

        DisplayCurrentInfo()
        ' Display the date using the current culture and calendar.
        Console.WriteLine(date1.ToString("d"))
        Console.WriteLine()

        Dim arSA As CultureInfo = CultureInfo.CreateSpecificCulture("ar-SA")

        ' Change the current culture to Arabic (Saudi Arabia).
        Thread.CurrentThread.CurrentCulture = arSA
        ' Display date and information about the current culture.
        DisplayCurrentInfo()
        Console.WriteLine(date1.ToString("d"))
        Console.WriteLine()

        ' Change the calendar to Hijri.
        Dim hijri As Calendar = New HijriCalendar()
        If CalendarExists(arSA, hijri) Then
            arSA.DateTimeFormat.Calendar = hijri
            ' Display date and information about the current culture.
            DisplayCurrentInfo()
            Console.WriteLine(date1.ToString("d"))
        End If
    End Sub

    Private Sub DisplayCurrentInfo()
        Console.WriteLine("Current Culture: {0}",
                          CultureInfo.CurrentCulture.Name)
        Console.WriteLine("Current Calendar: {0}",
                          DateTimeFormatInfo.CurrentInfo.Calendar)
    End Sub

    Private Function CalendarExists(ByVal culture As CultureInfo,
                                    cal As Calendar) As Boolean
        For Each optionalCalendar As Calendar In culture.OptionalCalendars
            If cal.ToString().Equals(optionalCalendar.ToString()) Then Return True
        Next
        Return False
    End Function
End Module
' The example displays the following output:
'    Current Culture: en-US
'    Current Calendar: System.Globalization.GregorianCalendar
'    6/20/2011
'    
'    Current Culture: ar-SA
'    Current Calendar: System.Globalization.UmAlQuraCalendar
'    18/07/32
'    
'    Current Culture: ar-SA
'    Current Calendar: System.Globalization.HijriCalendar
'    19/07/32
' </Snippet2>
