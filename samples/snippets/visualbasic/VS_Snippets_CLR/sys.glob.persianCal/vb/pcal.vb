'<snippet1>
Imports System.Globalization

Class Sample
    Public Shared Sub Main()
        '--------------------------------------------------------------------------------
        ' Get today's date.
        '--------------------------------------------------------------------------------
        Dim jc As New PersianCalendar()
        Dim thisDate As Date = Date.Now

        '--------------------------------------------------------------------------------
        ' Properties
        '--------------------------------------------------------------------------------
        Console.WriteLine(vbCrLf & _
                          "........... Selected Properties ....................." & vbCrLf)
        Console.Write("Eras:")
        Dim era As Integer
        For Each era In jc.Eras
            Console.WriteLine(" era = {0}", era)
        Next era
        '--------------------------------------------------------------------------------
        Console.WriteLine("TwoDigitYearMax = {0}", jc.TwoDigitYearMax)
        '--------------------------------------------------------------------------------
        ' Methods
        '--------------------------------------------------------------------------------
        Console.WriteLine(vbCrLf & _
                          "............ Selected Methods ......................." & vbCrLf)

        '--------------------------------------------------------------------------------
        Console.WriteLine("GetDayOfYear: day = {0}", jc.GetDayOfYear(thisDate))
        '--------------------------------------------------------------------------------

        Console.WriteLine("GetDaysInMonth: days = {0}", _
                           jc.GetDaysInMonth(thisDate.Year, _
                                             thisDate.Month, _
                                             PersianCalendar.PersianEra))
        '--------------------------------------------------------------------------------
        Console.WriteLine("GetDaysInYear: days = {0}", _
                          jc.GetDaysInYear(thisDate.Year, PersianCalendar.PersianEra))
        '--------------------------------------------------------------------------------
        Console.WriteLine("GetLeapMonth: leap month (if any) = {0}", _
                           jc.GetLeapMonth(thisDate.Year, PersianCalendar.PersianEra))
        '--------------------------------------------------------------------------------
        Console.WriteLine("GetMonthsInYear: months in a year = {0}", _
                           jc.GetMonthsInYear(thisDate.Year, PersianCalendar.PersianEra))
        '--------------------------------------------------------------------------------
        Console.WriteLine("IsLeapDay: This is a leap day = {0}", _
                           jc.IsLeapDay(thisDate.Year, _
                                        thisDate.Month, thisDate.Day, _
                                        PersianCalendar.PersianEra))
        '--------------------------------------------------------------------------------
        Console.WriteLine("IsLeapMonth: This is a leap month = {0}", _
                           jc.IsLeapMonth(thisDate.Year, _
                                          thisDate.Month, _
                                          PersianCalendar.PersianEra))
        '--------------------------------------------------------------------------------
        Console.WriteLine("IsLeapYear: 1370 is a leap year = {0}", _
                           jc.IsLeapYear(1370, PersianCalendar.PersianEra))
        '--------------------------------------------------------------------------------

        ' Get the 4-digit year for a year whose last two digits are 99. The 4-digit year 
        ' depends on the current value of the TwoDigitYearMax property.

        Console.WriteLine("ToFourDigitYear:")
        Console.WriteLine("  If TwoDigitYearMax = {0}, ToFourDigitYear(99) = {1}", _
                          jc.TwoDigitYearMax, jc.ToFourDigitYear(99))
        jc.TwoDigitYearMax = thisDate.Year
        Console.WriteLine("  If TwoDigitYearMax = {0}, ToFourDigitYear(99) = {1}", _
                          jc.TwoDigitYearMax, jc.ToFourDigitYear(99))
    End Sub
End Class 
' The example displays output like the following: 
'       ........... Seleted Properties .....................
'       
'       Eras: era = 1
'       
'       TwoDigitYearMax = 99
'       
'       ............ Selected Methods .......................
'       
'       GetDayOfYear: day = 1
'       GetDaysInMonth: days = 31
'       GetDaysInYear: days = 365
'       GetLeapMonth: leap month (if any) = 0
'       GetMonthsInYear: months in a year = 12
'       IsLeapDay: This is a leap day = False
'       IsLeapMonth: This is a leap month = False
'       IsLeapYear: 1370 is a leap year = True
'       ToFourDigitYear:
'         If TwoDigitYearMax = 99, ToFourDigitYear(99) = 99
'         If TwoDigitYearMax = 2012, ToFourDigitYear(99) = 1999
' </Snippet1>

Class CalendarConversion
   Public Shared Sub ConvertToday()
      ' <Snippet2>
      ' Instantiate a PersianCalendar object
      Dim pc As New PersianCalendar()

      ' Define a Gregorian date of 3/21/2007 12:47:15
      Dim gregorianDate As Date = #3/21/2007 12:47:15AM#
      Console.WriteLine("The Gregorian calendar date is {0:G}", gregorianDate) 
      ' Convert the Gregorian date to its equivalent date in the Persian calendar
      Console.WriteLine("The Persian calendar date is {0}/{1}/{2} {3}:{4}:{5}.", _ 
                        pc.GetMonth(gregorianDate), _
                        pc.GetDayOfMonth(gregorianDate), _ 
                        pc.GetYear(gregorianDate), _
                        pc.GetHour(gregorianDate), _
                        pc.GetMinute(gregorianDate), _ 
                        pc.GetSecond(gregorianDate))
      ' Convert the Persian calendar date back to the Gregorian calendar date                        
      Dim fromPersianDate As Date = pc.ToDateTime( _
               pc.GetYear(gregorianDate), _
               pc.GetMonth(gregorianDate), _
               pc.GetDayOfMonth(gregorianDate), _ 
               pc.GetHour(gregorianDate), _
               pc.GetMinute(gregorianDate), _
               pc.GetSecond(gregorianDate), _
               pc.GetMilliseconds(gregorianDate), _ 
               PersianCalendar.PersianEra)
      Console.WriteLine("The converted Gregorian calendar date is {0:G}", fromPersianDate) 

      ' The code displays the following output to the console:
      '
      '    The Gregorian calendar date is 3/21/2007 12:47:15 AM
      '    The Persian calendar date is 1/1/1386 0:47:15.
      '    The converted Gregorian calendar date is 3/21/2007 12:47:15 AM      
      ' </Snippet2>
   End Sub
End Class
