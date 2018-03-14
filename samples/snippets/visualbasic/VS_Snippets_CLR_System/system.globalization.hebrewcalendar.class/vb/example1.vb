' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization
Imports System.IO
Imports System.Threading

Module Example
   Public Sub Main()
      Dim output As New StreamWriter("HebrewCalendarInfo.txt")
      
      ' Make the Hebrew Calendar the current calendar and
      ' Hebrew (Israel) the current thread culture.
      Dim hc As New HebrewCalendar()
      Dim culture As CultureInfo = CultureInfo.CreateSpecificCulture("he-IL")
      culture.DateTimeFormat.Calendar = hc
      Thread.CurrentThread.CurrentCulture = culture
      
      output.WriteLine("{0} Information:", 
                       GetCalendarName(culture.DateTimeFormat.Calendar))
      output.WriteLine()
      
      ' Get the calendar range expressed in both Hebrew calendar and
      ' Gregorian calendar dates.
      output.WriteLine("Start Date: {0} ", 
                       hc.MinSupportedDateTime)  
      culture.DateTimeFormat.Calendar = culture.Calendar
      output.WriteLine("            ({0} Gregorian)", 
                       hc.MinSupportedDateTime)
      output.WriteLine()
      
      culture.DateTimeFormat.Calendar = hc
      output.WriteLine("End Date: {0} ", 
                   hc.MaxSupportedDateTime)
      culture.DateTimeFormat.Calendar = culture.Calendar
      output.WriteLine("          ({0} Gregorian)", 
                       hc.MaxSupportedDateTime)  
      output.WriteLine()
      
      culture.DateTimeFormat.Calendar = hc
      
      ' Get the year in the Hebrew calendar that corresponds to 1/1/2012
      ' and display information about it.
      Dim startOfYear As Date = #1/1/2012#
      output.WriteLine("Days in the Year {0}: {1}", 
                       hc.GetYear(startOfYear), 
                       hc.GetDaysInYear(hc.GetYear(startOfYear)))
      output.WriteLine()
      
      output.WriteLine("Days in Each Month of {0}:", hc.GetYear(startOfYear))
      output.WriteLine()
      output.WriteLine("Month       Days       Month Name")
      ' Change start of year to first day of first month 
      startOfYear = hc.ToDateTime(hc.GetYear(startOfYear), 1, 1, 0, 0, 0, 0)
      Dim startOfMonth As Date = startOfYear
      For ctr As Integer = 1 To hc.GetMonthsInYear(hc.GetYear(startOfYear)) 
         output.Write(" {0,2}", ctr)
         output.WriteLine("{0,12}{1,15:MMM}", 
                          hc.GetDaysInMonth(hc.GetYear(startOfMonth), hc.GetMonth(startOfMonth)),
                          startOfMonth)  
         startOfMonth = hc.AddMonths(startOfMonth, 1)                 
      Next 
                                     
      output.Close()          
   End Sub
   
   Private Function GetCalendarName(cal As Calendar) As String
      Return cal.ToString().Replace("System.Globalization.", "").Replace("Cal", " Cal")
   End Function
End Module
' The example displays the following output:
'       Hebrew Calendar Information:
'       
'       Start Date: ז' טבת שמ"ג 00:00:00 
'                   (01/01/1583 00:00:00 Gregorian)
'       
'       End Date: כ"ט אלול תתקצ"ט 23:59:59 
'                 (29/09/2239 23:59:59 Gregorian)
'       
'       Days in the Year 5772: 354
'       
'       Days in Each Month of 5772:
'       
'       Month       Days       Month Name
'         1          30           תשרי
'         2          29           חשון
'         3          30           כסלו
'         4          29            טבת
'         5          30            שבט
'         6          29            אדר
'         7          30           ניסן
'         8          29           אייר
'         9          30           סיון
'        10          29           תמוז
'        11          30             אב
'        12          29           אלול
' </Snippet1>
