' Visual Basic .NET Document
Option Strict On

Imports System.Globalization

Module modMain
   ' Snippet1: DateTimeOffset constructor with DateTime parameter
   Public Sub Main()
      ConstructWithDateTime()
      Console.WriteLine()
      ConstructWithTicks()
      Console.WriteLine()
      ConstructWithDateAndOffset()
      Console.WriteLine()
      ConstructNonLocalWithLocalTicks()
      Console.WriteLine()
      ConstructWithDateElements()
      Console.WriteLine()
      ConstructWithDateElements2()
      Console.WriteLine()
      ConstructWithDateElements3()
      Console.WriteLine()
      ConstructWithCalendar()
   End Sub
   
   Private Sub ConstructWithDateTime()
      ' <Snippet1>
      Dim localNow As Date = Date.Now
      Dim localOffset As New DateTimeOffset(localNow)
      Console.WriteLine(localOffset.ToString())
      
      Dim utcNow As Date = Date.UtcNow
      Dim utcOffset As New DateTimeOffset(utcNow)
      Console.WriteLine(utcOffset.ToString())
      
      Dim unspecifiedNow As Date = Date.SpecifyKind(Date.Now, _
                                        DateTimeKind.Unspecified)
      Dim unspecifiedOffset As New DateTimeOffset(unspecifiedNow)
      Console.WriteLine(unspecifiedOffset.ToString())
      '
      ' The code produces the following output if run on Feb. 23, 2007, on
      ' a system 8 hours earlier than UTC:
      '    2/23/2007 4:21:58 PM -08:00
      '    2/24/2007 12:21:58 AM +00:00
      '    2/23/2007 4:21:58 PM -08:00      
      ' </Snippet1> 
   End Sub

   Private Sub ConstructWithTicks()
      ' <Snippet2>
      Dim dateWithoutOffset As Date = #07/16/2007 1:32PM#
      Dim timeFromTicks As New DateTimeOffset(datewithoutOffset.Ticks, _
                               New TimeSpan(-5, 0, 0))
      Console.WriteLine(timeFromTicks.ToString())
      ' The code produces the following output:
      '    7/16/2007 1:32:00 PM -05:00
      ' </Snippet2>
   End Sub
   
   Private Sub ConstructWithDateAndOffset()
      ' <Snippet3>
      Dim localTime As Date = #07/12/2007 6:32AM#
      Dim dateAndOffset As New DateTimeOffset(localTime, _
                               TimeZoneInfo.Local.GetUtcOffset(localTime))
      Console.WriteLine(dateAndOffset)
      ' The code produces the following output:
      '    7/12/2007 6:32:00 AM -07:00
      ' </Snippet3>
   End Sub
   
   Private Sub ConstructNonLocalWithLocalTicks
      ' <Snippet4>
      Dim localTime As Date = Date.Now
      Dim nonLocalDateWithOffset As New DateTimeOffset(localTime.Ticks, _
                                        New TimeSpan(2, 0, 0))
      Console.WriteLine(nonLocalDateWithOffset)                                        
      '
      ' The code produces the following output if run on Feb. 23, 2007:
      '    2/23/2007 4:37:50 PM +02:00
      ' </Snippet4>
   End Sub
   
   Private Sub ConstructWithDateElements()
      ' <Snippet5>
         Dim specificDate As Date = #5/1/2008 6:32AM#
         Dim offsetDate As New DateTimeOffset(specificDate.Year, _
                                              specificDate.Month, _
                                              specificDate.Day, _
                                              specificDate.Hour, _
                                              specificDate.Minute, _
                                              specificDate.Second, _
                                              New TimeSpan(-5, 0, 0))
         Console.WriteLine("Current time: {0}", offsetDate)
         Console.WriteLine("Corresponding UTC time: {0}", offsetDate.UtcDateTime)                                              
      ' The code produces the following output:
      '    Current time: 5/1/2008 6:32:00 AM -05:00
      '    Corresponding UTC time: 5/1/2008 11:32:00 AM      
      ' </Snippet5>
   End Sub
   
   Private Sub ConstructWithDateElements2()
      ' <Snippet6>
         Dim specificDate As Date = #5/1/2008 6:32:05AM#
         Dim offsetDate As New DateTimeOffset(specificDate.Year - 1, _
                                              specificDate.Month, _
                                              specificDate.Day, _
                                              specificDate.Hour, _
                                              specificDate.Minute, _
                                              specificDate.Second, _
                                              0, _
                                              New TimeSpan(-5, 0, 0))
         Console.WriteLine("Current time: {0}", offsetDate)
         Console.WriteLine("Corresponding UTC time: {0}", offsetDate.UtcDateTime)                                              
      ' The code produces the following output:
      '    Current time: 5/1/2007 6:32:05 AM -05:00
      '    Corresponding UTC time: 5/1/2007 11:32:05 AM      
      ' </Snippet6>
   End Sub

   Private Sub ConstructWithDateElements3()
      ' <Snippet7>
      Dim fmt As String = "dd MMM yyyy HH:mm:ss"
      Dim thisDate As DateTime = New Date(2007, 06, 12, 19, 00, 14, 16)
      Dim offsetDate As New DateTimeOffset(thisDate.Year, _
                                           thisDate.Month, _
                                           thisDate.Day, _
                                           thisDate.Hour, _
                                           thisDate.Minute, _
                                           thisDate.Second, _
                                           thisDate.Millisecond, _ 
                                           New TimeSpan(2, 0, 0))  
      Console.WriteLine("Current time: {0}:{1}", offsetDate.ToString(fmt), _ 
                                                 offsetDate.Millisecond)
      ' The code produces the following output:
      '    Current time: 12 Jun 2007 19:00:14:16      
      ' </Snippet7>
   End Sub
   
   Private Sub ConstructWithCalendar()
      ' <Snippet8>
      Dim fmt As CultureInfo
      Dim year As Integer
      Dim cal As Calendar
      Dim dateInCal As DateTimeOffset
      
      ' Instantiate DateTimeOffset with Hebrew calendar
      year = 5770
      cal = New HebrewCalendar()
      fmt = New CultureInfo("he-IL")
      fmt.DateTimeFormat.Calendar = cal      
      dateInCal = New DateTimeOffset(year, 7, 12, _
                                     15, 30, 0, 0, _
                                     cal, _
                                     New TimeSpan(2, 0, 0))
      ' Display the date in the Hebrew calendar
      Console.WriteLine("Date in Hebrew Calendar: {0:g}", _
                         dateInCal.ToString(fmt))
      ' Display the date in the Gregorian calendar                         
      Console.WriteLine("Date in Gregorian Calendar: {0:g}", dateInCal)
      Console.WriteLine()

      ' Instantiate DateTimeOffset with Hijri calendar
      year = 1431
      cal = New HijriCalendar()
      fmt = New CultureInfo("ar-SA")
      fmt.DateTimeFormat.Calendar = cal
      dateInCal = New DateTimeOffset(year, 7, 12, _
                                     15, 30, 0, 0, _
                                     cal, _
                                     New TimeSpan(2, 0, 0))
      ' Display the date in the Hijri calendar
      Console.WriteLine("Date in Hijri Calendar: {0:g}", _
                         dateInCal.ToString(fmt))
      ' Display the date in the Gregorian calendar                         
      Console.WriteLine("Date in Gregorian Calendar: {0:g}", dateInCal)
      Console.WriteLine()
      ' </Snippet8>
   End Sub
End Module

