' Visual Basic .NET Document
Option Strict On

' <Snippet9>
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Threading

Module Example
   Public Sub Main()
      Console.WriteLine("Using the Persian Calendar:")
      Dim persian As New PersianCalendar()
      Dim date1 As New Date(1389, 5, 27, 16, 32, 18, 500, _
                            persian, DateTimeKind.Local)
      Console.WriteLine("{0:M/dd/yyyy h:mm:ss.fff tt} {1}", date1, date1.Kind)
      Console.WriteLine("{0}/{1}/{2} {3}{8}{4:D2}{8}{5:D2}.{6:G3} {7}", _
                                       persian.GetMonth(date1), _
                                       persian.GetDayOfMonth(date1), _
                                       persian.GetYear(date1), _
                                       persian.GetHour(date1), _
                                       persian.GetMinute(date1), _
                                       persian.GetSecond(date1), _
                                       persian.GetMilliseconds(date1), _
                                       date1.Kind, _
                                       DateTimeFormatInfo.CurrentInfo.TimeSeparator)
      Console.WriteLine()
      
      Console.WriteLine("Using the Hijri Calendar:")
      ' Get current culture so it can later be restored.
      Dim dftCulture As CultureInfo = Thread.CurrentThread.CurrentCulture
      
      ' Define strings for use in composite formatting.
      Dim dFormat As String 
      Dim fmtString As String 
      ' Define Hijri calendar.
      Dim hijri As New HijriCalendar()
      ' Make ar-SY the current culture and Hijri the current calendar.
      Thread.CurrentThread.CurrentCulture = New CultureInfo("ar-SY")
      Dim current As CultureInfo = CultureInfo.CurrentCulture
      current.DateTimeFormat.Calendar = hijri
      dFormat = current.DateTimeFormat.ShortDatePattern
      ' Ensure year is displayed as four digits.
      dFormat = Regex.Replace(dFormat, "/yy$", "/yyyy") + " H:mm:ss.fff"
      fmtString = "{0} culture using the {1} calendar: {2:" + dFormat + "} {3}"
      Dim date2 As New Date(1431, 9, 9, 16, 32, 18, 500, _
                            hijri, DateTimeKind.Local)
      Console.WriteLine(fmtString, current, GetCalendarName(hijri), _
                        date2, date2.Kind) 

      ' Restore previous culture.
      Thread.CurrentThread.CurrentCulture = dftCulture
      dFormat = DateTimeFormatInfo.CurrentInfo.ShortDatePattern +" H:mm:ss.fff"
      fmtString = "{0} culture using the {1} calendar: {2:" + dFormat + "} {3}"
      Console.WriteLine(fmtString, CultureInfo.CurrentCulture, _
                        GetCalendarName(CultureInfo.CurrentCulture.Calendar), _
                        date2, date2.Kind) 
   End Sub
   
   Private Function GetCalendarName(cal As Calendar) As String
      Return Regex.Match(cal.ToString(), "\.(\w+)Calendar").Groups(1).Value
   End Function
End Module
' The example displays the following output:
'       Using the Persian Calendar:
'       8/18/2010 4:32:18.500 PM
'       5/27/1389 16:32:18.500
'       
'       Using the Hijri Calendar:
'       ar-SY culture using the Hijri calendar: 09/09/1431 16:32:18.500
'       en-US culture using the Gregorian calendar: 8/18/2010 16:32:18.500
' </Snippet9>
