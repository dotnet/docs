' <ChangeCalendar>
Imports System.Globalization

Module Example
    Public Sub Main()
        Dim date1 As Date = #6/20/2011#

        Console.OutputEncoding = System.Text.Encoding.UTF8
        DisplayCurrentInfo()
        ' Display the date using the current culture and calendar.
        Console.WriteLine(date1.ToString("d"))
        Console.WriteLine()

        Dim arSA As CultureInfo = CultureInfo.CreateSpecificCulture("ar-SA")

        ' Change the current culture to Arabic (Saudi Arabia).
        CultureInfo.CurrentCulture = arSA
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
        Console.WriteLine($"Current Culture: {CultureInfo.CurrentCulture.Name}")
        Console.WriteLine($"Current Calendar: {DateTimeFormatInfo.CurrentInfo.Calendar}")
    End Sub

    Private Function CalendarExists(culture As CultureInfo, cal As Calendar) As Boolean
        Return culture.OptionalCalendars.Any(Function(optional1) optional1.ToString() = cal.ToString())
    End Function
End Module
' The example displays the following output:
'    Current Culture: en-US
'    Current Calendar: System.Globalization.GregorianCalendar
'    6/20/2011
'    
'    Current Culture: ar-SA
'    Current Calendar: System.Globalization.UmAlQuraCalendar
'    18‏‏/7‏‏/1432 بعد الهجرة
'    
'    Current Culture: ar-SA
'    Current Calendar: System.Globalization.HijriCalendar
'    19‏‏/7‏‏/1432 بعد الهجرة
' </ChangeCalendar>
