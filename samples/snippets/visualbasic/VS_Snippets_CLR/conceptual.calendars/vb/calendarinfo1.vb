' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Public Module Example
    Public Sub Main()
        ' Create a CultureInfo for Thai in Thailand.
        Dim th As CultureInfo = CultureInfo.CreateSpecificCulture("th-TH")
        DisplayCalendars(th)

        ' Create a CultureInfo for Japanese in Japan.
        Dim ja As CultureInfo = CultureInfo.CreateSpecificCulture("ja-JP")
        DisplayCalendars(ja)
    End Sub

    Sub DisplayCalendars(ci As CultureInfo)
        Console.WriteLine("Calendars for the {0} culture:", ci.Name)

        ' Get the culture's default calendar.
        Dim defaultCalendar As Calendar = ci.Calendar
        Console.Write("   Default Calendar: {0}", GetCalendarName(defaultCalendar))

        If TypeOf defaultCalendar Is GregorianCalendar Then
            Console.WriteLine(" ({0})",
                              CType(defaultCalendar, GregorianCalendar).CalendarType)
        Else
            Console.WriteLine()
        End If

        ' Get the culture's optional calendars.
        Console.WriteLine("   Optional Calendars:")
        For Each optionalCalendar In ci.OptionalCalendars
            Console.Write("{0,6}{1}", "", GetCalendarName(optionalCalendar))
            If TypeOf optionalCalendar Is GregorianCalendar Then
                Console.Write(" ({0})",
                              CType(optionalCalendar, GregorianCalendar).CalendarType)
            End If
            Console.WriteLine()
        Next
        Console.WriteLine()
    End Sub

    Function GetCalendarName(cal As Calendar) As String
        Return cal.ToString().Replace("System.Globalization.", "")
    End Function
End Module
' The example displays the following output:
'       Calendars for the th-TH culture:
'          Default Calendar: ThaiBuddhistCalendar
'          Optional Calendars:
'             ThaiBuddhistCalendar
'             GregorianCalendar (Localized)
'       
'       Calendars for the ja-JP culture:
'          Default Calendar: GregorianCalendar (Localized)
'          Optional Calendars:
'             GregorianCalendar (Localized)
'             JapaneseCalendar
'             GregorianCalendar (USEnglish)
' </Snippet1>
