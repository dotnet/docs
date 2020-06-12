' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization

Public Class CalendarDates
    Public Shared Sub Main()
        Dim hijriCal As New HijriCalendar()
        Dim hijriUtil As New CalendarUtility(hijriCal)
        Dim dateValue1 As Date = New Date(1429, 6, 29, hijriCal)
        Dim dateValue2 As DateTimeOffset = New DateTimeOffset(dateValue1, _
                                           TimeZoneInfo.Local.GetUtcOffset(dateValue1))
        Dim jc As CultureInfo = CultureInfo.CreateSpecificCulture("ar-JO")

        ' Display the date using the Gregorian calendar.
        Console.WriteLine("Using the system default culture: {0}", _
                          dateValue1.ToString("d"))
        ' Display the date using the ar-JO culture's original default calendar.
        Console.WriteLine("Using the ar-JO culture's original default calendar: {0}", _
                          dateValue1.ToString("d", jc))
        ' Display the date using the Hijri calendar.
        Console.WriteLine("Using the ar-JO culture with Hijri as the default calendar:")
        ' Display a Date value.
        Console.WriteLine(hijriUtil.DisplayDate(dateValue1, jc))
        ' Display a DateTimeOffset value.
        Console.WriteLine(hijriUtil.DisplayDate(dateValue2, jc))

        Console.WriteLine()

        Dim persianCal As New PersianCalendar()
        Dim persianUtil As New CalendarUtility(persianCal)
        Dim ic As CultureInfo = CultureInfo.CreateSpecificCulture("fa-IR")

        ' Display the date using the ir-FA culture's default calendar.
        Console.WriteLine("Using the ir-FA culture's default calendar: {0}", _
                          dateValue1.ToString("d", ic))
        ' Display a Date value.
        Console.WriteLine(persianUtil.DisplayDate(dateValue1, ic))
        ' Display a DateTimeOffset value.
        Console.WriteLine(persianUtil.DisplayDate(dateValue2, ic))
    End Sub
End Class

Public Class CalendarUtility
    Private thisCalendar As Calendar
    Private targetCulture As CultureInfo

    Public Sub New(cal As Calendar)
        Me.thisCalendar = cal
    End Sub

    Private Function CalendarExists(culture As CultureInfo) As Boolean
        Me.targetCulture = culture
        Return Array.Exists(Me.targetCulture.OptionalCalendars, _
                            AddressOf Me.HasSameName)
    End Function

    Private Function HasSameName(cal As Calendar) As Boolean
        If cal.ToString() = thisCalendar.ToString() Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function DisplayDate(dateToDisplay As Date, _
                                culture As CultureInfo) As String
        Dim displayOffsetDate As DateTimeOffset = dateToDisplay
        Return DisplayDate(displayOffsetDate, culture)
    End Function

    Public Function DisplayDate(dateToDisplay As DateTimeOffset, _
                                culture As CultureInfo) As String
        Dim specifier As String = "yyyy/MM/dd"

        If Me.CalendarExists(culture) Then
            Console.WriteLine("Displaying date in supported {0} calendar...", _
                              thisCalendar.GetType().Name)
            culture.DateTimeFormat.Calendar = Me.thisCalendar
            Return dateToDisplay.ToString(specifier, culture)
        Else
            Console.WriteLine("Displaying date in unsupported {0} calendar...", _
                              thisCalendar.GetType().Name)

            Dim separator As String = targetCulture.DateTimeFormat.DateSeparator

            Return thisCalendar.GetYear(dateToDisplay.DateTime).ToString("0000") & separator & _
                   thisCalendar.GetMonth(dateToDisplay.DateTime).ToString("00") & separator & _
                   thisCalendar.GetDayOfMonth(dateToDisplay.DateTime).ToString("00")
        End If
    End Function
End Class
' The example displays the following output to the console:
'       Using the system default culture: 7/3/2008
'       Using the ar-JO culture's original default calendar: 03/07/2008
'       Using the ar-JO culture with Hijri as the default calendar:
'       Displaying date in supported HijriCalendar calendar...
'       1429/06/29
'       Displaying date in supported HijriCalendar calendar...
'       1429/06/29
'       
'       Using the ir-FA culture's default calendar: 7/3/2008
'       Displaying date in unsupported PersianCalendar calendar...
'       1387/04/13
'       Displaying date in unsupported PersianCalendar calendar...
'       1387/04/13
' </Snippet2>

Module AdditionalSnippets
    Public Sub BadDate()
        ' <Snippet1>
        Dim persianCal As New PersianCalendar()

        Dim persianDate As Date = persianCal.ToDateTime(1387, 3, 18, _
                                                        12, 0, 0, 0)
        Console.WriteLine(persianDate.ToString())

        persianDate = New DateTime(1387, 3, 18, persianCal)
        Console.WriteLine(persianDate.ToString())
        ' The example displays the following output to the console:
        '       6/7/2008 12:00:00 PM
        '       6/7/2008 12:00:00 AM
        ' </Snippet1>
    End Sub
End Module
