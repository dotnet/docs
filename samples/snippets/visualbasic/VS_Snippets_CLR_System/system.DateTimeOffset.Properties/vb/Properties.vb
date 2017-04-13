' Visual Basic .NET Document
Option Strict On

Imports System.Globalization

Module modMain

   Public Sub Main()
      ShowDateFormats()
      Console.WriteLine("----------") 
      ConvertToDateTime()
      Console.WriteLine("----------") 
      ShowFirstOfMonth()
      Console.WriteLine("----------") 
      ShowHour()
      Console.WriteLine("----------") 
      CompareDateTimeValues()   
      Console.WriteLine("----------") 
      ConvertToLocalTime()
      Console.WriteLine("----------") 
      ShowMinute()
      Console.WriteLine("----------") 
      ShowMonth()
      Console.WriteLine("----------") 
      ShowDay()
      Console.WriteLine("----------") 
      ShowResolution()
      Console.WriteLine("----------") 
      ShowMilliseconds()
      Console.WriteLine("----------")
      ShowLocalOffset()
      Console.WriteLine("----------")
      ShowSeconds()
      Console.WriteLine("----------")
      IllustrateTicks()
      Console.WriteLine("----------")
      ShowTime()
      Console.WriteLine("----------")
      ConvertToUtc()
      Console.WriteLine("----------")
      CompareUtcAndLocal()
      Console.WriteLine("----------")
      ShowYear()
      Console.WriteLine("----------")
   End Sub
   
   Private Sub ShowDateFormats()
      ' <Snippet1>
      ' Illustrate Date property and date formatting
      Dim thisDate As New DateTimeOffset(#3/17/2008 1:32AM#, New TimeSpan(-5, 0, 0))
      Dim fmt As String                    ' format specifier
      ' Display date only using "D" format specifier
      ' For en-us culture, displays:
      '   'D' format specifier: Monday, March 17, 2008
      fmt = "D"
      Console.WriteLine("'{0}' format specifier: {1}", _ 
                        fmt, thisDate.Date.ToString(fmt))
      
      ' Display date only using "d" format specifier
      ' For en-us culture, displays:
      '   'd' format specifier: 3/17/2008
      fmt = "d"
      Console.WriteLine("'{0}' format specifier: {1}", _ 
                        fmt, thisDate.Date.ToString(fmt))
      
      ' Display date only using "Y" (or "y") format specifier
      ' For en-us culture, displays:
      '   'Y' format specifier: March, 2008
      fmt = "Y"
      Console.WriteLine("'{0}' format specifier: {1}", _ 
                        fmt, thisDate.Date.ToString(fmt))
                        
      ' Display date only using custom format specifier
      ' For en-us culture, displays:
      '   'dd MMM yyyy' format specifier: 17 Mar 2008
      fmt = "dd MMM yyyy"
      Console.WriteLine("'{0}' format specifier: {1}", _ 
                        fmt, thisDate.Date.ToString(fmt))
      ' </Snippet1>
   End Sub
   
   Private Sub ConvertToDateTime()
      ' <Snippet2>
      Dim offsetDate As DateTimeOffset 
      Dim regularDate As Date
      
      offsetDate = DateTimeOffset.Now
      regularDate = offsetDate.DateTime
      Console.WriteLine("{0} converts to {1}, Kind {2}.", _
                        offsetDate.ToString(), _
                        regularDate, _ 
                        regularDate.Kind)
                     
      offsetDate = DateTimeOffset.UtcNow
      regularDate = offsetDate.DateTime
      Console.WriteLine("{0} converts to {1}, Kind {2}.", _
                        offsetDate.ToString(), _
                        regularDate, _
                        regularDate.Kind)
      ' If run on 3/6/2007 at 17:11, produces the following output:
      '
      '   3/6/2007 5:11:22 PM -08:00 converts to 3/6/2007 5:11:22 PM, Kind Unspecified.
      '   3/7/2007 1:11:22 AM +00:00 converts to 3/7/2007 1:11:22 AM, Kind Unspecified.                        
      ' </Snippet2>                        
   End Sub
   
   Private Sub ShowFirstOfMonth()
      ' <Snippet3>
      Dim startOfMonth As New DateTimeOffset(#1/1/2008#, _
                                            DateTimeOffset.Now.Offset)
      Dim year As Integer = startOfMonth.Year
      Do While startOfMonth.Year = year
         Console.WriteLine("{0:MMM d, yyyy} is a {1}.", _
                           startOfMonth, startOfMonth.DayOfWeek)
         startOfMonth = startOfMonth.AddMonths(1)                   
      Loop      
      ' This example writes the following output to the console:
      '    Jan 1, 2008 is a Tuesday.
      '    Feb 1, 2008 is a Friday.
      '    Mar 1, 2008 is a Saturday.
      '    Apr 1, 2008 is a Tuesday.
      '    May 1, 2008 is a Thursday.
      '    Jun 1, 2008 is a Sunday.
      '    Jul 1, 2008 is a Tuesday.
      '    Aug 1, 2008 is a Friday.
      '    Sep 1, 2008 is a Monday.
      '    Oct 1, 2008 is a Wednesday.
      '    Nov 1, 2008 is a Saturday.
      '    Dec 1, 2008 is a Monday.      
      ' </Snippet3>   
      
      ' <Snippet4>
      Dim displayDate As New DateTimeOffset(#1/1/2008 1:18PM#, _
                                            DateTimeOffset.Now.Offset)
      Console.WriteLine("{0:D}", displayDate)    ' Output: Tuesday, January 01, 2008                     
      Console.WriteLine("{0:d} is a {0:dddd}.", _
                        displayDate)             ' Output: 1/1/2008 is a Tuesday.
      ' </Snippet4>
      
      ' <Snippet5>
      Dim thisDate As New DateTimeOffset(#6/1/2007 6:15AM#, _
                                            DateTimeOffset.Now.Offset)
      Dim weekdayName As String = thisDate.ToString("dddd", _
                                  New CultureInfo("fr-fr")) 
      Console.WriteLine(weekdayName)                        ' Displays vendredi     
      ' </Snippet5>                     
   End Sub
   
   Private Sub ShowHour()
      ' <Snippet6>
      Dim theTime As New DateTimeOffset(#3/1/2008 2:15PM#, _
                                             DateTimeOffset.Now.Offset)
      Console.WriteLine("The hour component of {0} is {1}.", _
                        theTime, theTime.Hour)

      Console.WriteLine("The hour component of {0} is{1}.", _
                        theTime, theTime.ToString(" H"))

      Console.WriteLine("The hour component of {0} is {1}.", _
                        theTime, theTime.ToString("HH"))
      ' The example produces the following output:
      '    The hour component of 3/1/2008 2:15:00 PM -08:00 is 14.
      '    The hour component of 3/1/2008 2:15:00 PM -08:00 is 14.
      '    The hour component of 3/1/2008 2:15:00 PM -08:00 is 14.
      ' </Snippet6>                              
   End Sub
   
   Private Sub CompareDateTimeValues()
      Dim thisTime As New DateTimeOffset(#12/22/2007 10:00AM#, _
                                         DateTimeOffset.UtcNow.Offset)
      Dim localDate As Date = thisTime.LocalDateTime
      Dim thisDate As Date = thisTime.DateTime
      
      Console.WriteLine("{0} Equals {1}: {2}", localDate, thisDate, localDate.Equals(thisDate)) 
   End Sub   
   
   Private Sub ConvertToLocalTime()
      ' <Snippet7>
      Dim dto As DateTimeOffset

      ' Current time
      dto = DateTimeOffset.Now
      Console.WriteLine(dto.LocalDateTime)
      ' UTC time
      dto = DateTimeOffset.UtcNow
      Console.WriteLine(dto.LocalDateTime)

     ' Transition to DST in local time zone occurs on 3/11/2007 at 2:00 AM
      dto = New DateTimeOffset(#03/11/2007 3:30AM#, New Timespan(-7, 0, 0))      
      Console.WriteLine(dto.LocalDateTime)
      dto = New DateTimeOffset(#03/11/2007 2:30AM#, New Timespan(-7, 0, 0))
      Console.WriteLine(dto.LocalDateTime)
      ' Invalid time in local time zone
      dto = New DateTimeOffset(#03/11/2007 2:30AM#, New Timespan(-8, 0, 0))
      Console.WriteLine(TimeZoneInfo.Local.IsInvalidTime(dto.DateTime))
      Console.WriteLine(dto.LocalDateTime)

      ' Transition from DST in local time zone occurs on 11/4/07 at 2:00 AM
      ' This is an ambiguous time
      dto = New DateTimeOffset(#11/4/2007 1:30AM#, New TimeSpan(-7, 0, 0))
      Console.WriteLine(TimeZoneInfo.Local.IsAmbiguousTime(dto))
      Console.WriteLine(dto.LocalDateTime)
      dto = New DateTimeOffset(#11/4/2007 2:30AM#, New TimeSpan(-7, 0, 0))           
      Console.WriteLine(TimeZoneInfo.Local.IsAmbiguousTime(dto))
      Console.WriteLine(dto.LocalDateTime)
      ' This is also an ambiguous time
      dto = New DateTimeOffset(#11/4/2007 1:30AM#, New TimeSpan(-8, 0, 0))           
      Console.WriteLine(TimeZoneInfo.Local.IsAmbiguousTime(dto))
      Console.WriteLine(dto.LocalDateTime)
      ' If run on 3/8/2007 at 4:56 PM, the code produces the following
      ' output:
      '    3/8/2007 4:56:03 PM
      '    3/8/2007 4:56:03 PM
      '    3/11/2007 3:30:00 AM
      '    3/11/2007 1:30:00 AM
      '    True
      '    3/11/2007 3:30:00 AM
      '    True
      '    11/4/2007 1:30:00 AM
      '    11/4/2007 1:30:00 AM
      '    True
      '    11/4/2007 1:30:00 AM      
      ' </Snippet7>
   End Sub
   
   Private Sub ShowMinute()
      ' <Snippet8>
      Dim theTime As New DateTimeOffset(#5/1/2008 10:03AM#, _
                                             DateTimeOffset.Now.Offset)
      Console.WriteLine("The minute component of {0} is {1}.", _
                        theTime, theTime.Minute)

      Console.WriteLine("The minute component of {0} is{1}.", _
                        theTime, theTime.ToString(" m"))

      Console.WriteLine("The minute component of {0} is {1}.", _
                        theTime, theTime.ToString("mm"))
      ' The example produces the following output:
      '    The minute component of 5/1/2008 10:03:00 AM -08:00 is 3.
      '    The minute component of 5/1/2008 10:03:00 AM -08:00 is 3.
      '    The minute component of 5/1/2008 10:03:00 AM -08:00 is 03.
      ' </Snippet8>                              
   End Sub
   
   Private Sub ShowMonth
      ' <Snippet9>
      Dim theTime As New DateTimeOffset(#9/7/2008 11:25AM#, _
                                             DateTimeOffset.Now.Offset)
      Console.WriteLine("The month component of {0} is {1}.", _
                        theTime, theTime.Month)

      Console.WriteLine("The month component of {0} is{1}.", _
                        theTime, theTime.ToString(" M"))

      Console.WriteLine("The month component of {0} is {1}.", _
                        theTime, theTime.ToString("MM"))
      ' The example produces the following output:
      '    The month component of 9/7/2008 11:25:00 AM -08:00 is 9.
      '    The month component of 9/7/2008 11:25:00 AM -08:00 is 9.
      '    The month component of 9/7/2008 11:25:00 AM -08:00 is 09.      
      ' </Snippet9>                              
   End Sub
   
   Private Sub ShowDay
      ' <Snippet10>
      Dim theTime As New DateTimeOffset(#5/1/2007 4:35PM#, _
                                             DateTimeOffset.Now.Offset)
      Console.WriteLine("The day component of {0} is {1}.", _
                        theTime, theTime.Day)

      Console.WriteLine("The day component of {0} is{1}.", _
                        theTime, theTime.ToString(" d"))

      Console.WriteLine("The day component of {0} is {1}.", _
                        theTime, theTime.ToString("dd"))
      ' The example produces the following output:
      '    The day component of 5/1/2007 4:35:00 PM -08:00 is 1.
      '    The day component of 5/1/2007 4:35:00 PM -08:00 is 1.
      '    The day component of 5/1/2007 4:35:00 PM -08:00 is 01.
      ' </Snippet10>                              
   End Sub

   Private Sub ShowResolution()
      ' <Snippet11>
      Dim dto As DateTimeOffset
      Dim ctr As Integer
      Dim ms As Integer
      Do
         dto = DateTimeOffset.Now
         If dto.Millisecond <> ms Then
            ms = dto.Millisecond
            Console.WriteLine("{0}:{1:d3} ms. {2}", _
                              dto.ToString("M/d/yyyy h:mm:ss"), _
                              ms, dto.ToString("zzz"))
            ctr += 1
         End If
      Loop While ctr < 100
      ' </Snippet11>
   End Sub   
   
   Private Sub ShowMilliseconds()
      ' <Snippet12>
      Dim date1 As New DateTimeOffset(2008, 3, 5, 5, 45, 35, 649, _
                                      New TimeSpan(-7, 0, 0))
      Console.WriteLine("Milliseconds value of {0} is {1}.", _
                        date1.ToString("MM/dd/yyyy hh:mm:ss.fff"), _
                        date1.Millisecond)
      ' The example produces the following output:
      '
      ' Milliseconds value of 03/05/2008 05:45:35.649 is 649.
      ' </Snippet12>                        
   End Sub

   Private Sub ShowLocalOffset()
      ' <Snippet13>
      Dim localTime As DateTimeOffset = DateTimeOffset.Now
      Console.WriteLine("The local time zone is {0} hours and {1} minutes {2} than UTC.", _
                        Math.Abs(localTime.Offset.Hours), _
                        localTime.Offset.Minutes, _
                        IIf(localTime.Offset.Hours < 0, "earlier", "later"))
      ' If run on a system whose local time zone is U.S. Pacific Standard Time,
      ' the example displays output similar to the following:
      '       The local time zone is 8 hours and 0 minutes earlier than UTC.      
      ' </Snippet13>
   End Sub
   
   Private Sub ShowSeconds()
      ' <Snippet14>
      Dim theTime As New DateTimeOffset(#6/12/2008 9:16:32PM#, _
                                             DateTimeOffset.Now.Offset)
      Console.WriteLine("The second component of {0} is {1}.", _
                        theTime, theTime.Second)

      Console.WriteLine("The second component of {0} is{1}.", _
                        theTime, theTime.ToString(" s"))

      Console.WriteLine("The second component of {0} is {1}.", _
                        theTime, theTime.ToString("ss"))
      ' The example produces the following output:
      '    The second component of 6/12/2008 9:16:32 PM -07:00 is 32.
      '    The second component of 6/12/2008 9:16:32 PM -07:00 is 32.
      '    The second component of 6/12/2008 9:16:32 PM -07:00 is 32.
      ' </Snippet14>                              
   End Sub
   
   Private Sub IllustrateTicks()
      ' <Snippet15>
      ' Attempt to initialize date to number of ticks
      ' in July 1, 2008 1:23:07.      
      '
      ' There are 10,000,000 100-nanosecond intervals in a second
      Const NSPerSecond As Long = 10000000
      Dim ticks As Long
      ticks = 7 * NSPerSecond                         ' Ticks in a 7 seconds 
      ticks += 23 * 60 * NSPerSecond                  ' Ticks in 23 minutes
      ticks += 1 * 60 * 60 * NSPerSecond              ' Ticks in 1 hour
      ticks += 60 * 60 * 24 * NSPerSecond             ' Ticks in 1 day
      ticks += 181 * 60 * 60 * 24 * NSPerSecond       ' Ticks in 6 months 
      ticks += 2007 * 60 * 60 * 24 * 365l * NSPerSecond   ' Ticks in 2007 years 
      ticks += 486 * 60 * 60 * 24 * NSPerSecond       ' Adjustment for leap years      
      Dim dto As DateTimeOffset = New DateTimeOffset( _
                                  ticks, _
                                  DateTimeOffset.Now.Offset)
      Console.WriteLine("There are {0:n0} ticks in {1}.", _
                        dto.Ticks, _
                        dto.ToString())
      ' The example displays the following output:
      '       There are 633,504,721,870,000,000 ticks in 7/1/2008 1:23:07 AM -08:00.      
      ' </Snippet15>                     
   End Sub 
   
   Private Sub ShowTime()
      ' <Snippet16>
      Dim currentDate As New DateTimeOffset(#5/10/2008 5:32:16AM#, _
                                            DateTimeOffset.Now.Offset) 
      Dim currentTime As TimeSpan = currentDate.TimeOfDay
      Console.WriteLine("The current time is {0}.", currentTime.ToString())
      ' The example produces the following output: 
      '       The current time is 05:32:16.
      ' </Snippet16>
   End Sub  
   
   Private Sub ConvertToUtc()
      ' <Snippet17>
      Dim offsetTime As New DateTimeOffset(#11/25/2007 11:14AM#, _
                        New TimeSpan(3, 0, 0))
      Console.WriteLine("{0} is equivalent to {1} {2}", _
                        offsetTime.ToString(), _
                        offsetTime.UtcDateTime.ToString(), _
                        offsetTime.UtcDateTime.Kind.ToString())      
      ' The example displays the following output:
      '       11/25/2007 11:14:00 AM +03:00 is equivalent to 11/25/2007 8:14:00 AM Utc      
      ' </Snippet17>
   End Sub
   
   Private Sub CompareUtcAndLocal()
      ' <Snippet18> 
      Dim localTime As DateTimeOffset = DateTimeOffset.Now
      Dim utcTime As DateTimeOffset = DateTimeOffset.UtcNow
      
      Console.WriteLine("Local Time:          {0}", localTime.ToString("T"))
      Console.WriteLine("Difference from UTC: {0}", localTime.Offset.ToString())
      Console.WriteLine("UTC:                 {0}", utcTime.ToString("T"))
      ' If run on a particular date at 1:19 PM, the example produces
      ' the following output:
      '    Local Time:          1:19:43 PM
      '    Difference from UTC: -07:00:00
      '    UTC:                 8:19:43 PM      
      ' </Snippet18>
   End Sub

   Private Sub ShowYear
      ' <Snippet19>
      Dim theTime As New DateTimeOffset(#2/17/2008 9:00AM#, _
                                        DateTimeOffset.Now.Offset)
      Console.WriteLine("The year component of {0} is {1}.", _
                        theTime, theTime.Year)

      Console.WriteLine("The year component of {0} is{1}.", _
                        theTime, theTime.ToString(" y"))

      Console.WriteLine("The year component of {0} is {1}.", _
                        theTime, theTime.ToString("yy"))
                        
      Console.WriteLine("The year component of {0} is {1}.", _
                        theTime, theTime.ToString("yyyy"))
      ' The example produces the following output:
      '    The year component of 2/17/2008 9:00:00 AM -07:00 is 2008.
      '    The year component of 2/17/2008 9:00:00 AM -07:00 is 8.
      '    The year component of 2/17/2008 9:00:00 AM -07:00 is 08.
      '    The year component of 2/17/2008 9:00:00 AM -07:00 is 2008.
      ' </Snippet19>                              
   End Sub
End Module

