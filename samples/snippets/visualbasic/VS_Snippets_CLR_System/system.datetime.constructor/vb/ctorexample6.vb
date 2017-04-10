' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Threading

Module Example
   Public Sub Main()
      Console.WriteLine("Using the Persian Calendar:")
      Dim persian As New PersianCalendar()
      Dim date1 As New Date(1389, 5, 27, 16, 32, 18, 500, persian)
      Console.WriteLine(date1.ToString("M/dd/yyyy h:mm:ss.fff tt"))
      Console.WriteLine("{0}/{1}/{2} {3}{7}{4:D2}{7}{5:D2}.{6:G3}", _
                                       persian.GetMonth(date1), _
                                       persian.GetDayOfMonth(date1), _
                                       persian.GetYear(date1), _
                                       persian.GetHour(date1), _
                                       persian.GetMinute(date1), _
                                       persian.GetSecond(date1), _
                                       persian.GetMilliseconds(date1), _
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
      fmtString = "{0} culture using the {1} calendar: {2:" + dFormat + "}"
      Dim date2 As New Date(1431, 9, 9, 16, 32, 18, 500, hijri)
      Console.WriteLine(fmtString, current, GetCalendarName(hijri), date2) 

      ' Restore previous culture.
      Thread.CurrentThread.CurrentCulture = dftCulture
      dFormat = DateTimeFormatInfo.CurrentInfo.ShortDatePattern +" H:mm:ss.fff"
      fmtString = "{0} culture using the {1} calendar: {2:" + dFormat + "}"
      Console.WriteLine(fmtString, CultureInfo.CurrentCulture, _
                        GetCalendarName(CultureInfo.CurrentCulture.Calendar), _
                        date2) 
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
' </Snippet6>
