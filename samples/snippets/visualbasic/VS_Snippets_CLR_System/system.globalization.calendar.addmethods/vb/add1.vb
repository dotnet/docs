' Visual Basic .NET Document
Option Strict On

Imports System.Globalization

Module Example
   Dim date1 As Date = DateTime.SpecifyKind(#06/01/2009 7:42AM#, DateTimeKind.Local)
   Dim date2 As Date = DateTime.SpecifyKind(#06/01/2009 7:42AM#, DateTimeKind.Utc)
   Dim time, returnTime As Date
   
   Public Sub Main()
      Dim calendars() As Calendar = { New ChineseLuniSolarCalendar(), _
                                      New GregorianCalendar(), _
                                      New HebrewCalendar(), _
                                      New HijriCalendar(), _
                                      New JapaneseCalendar(), _
                                      New JapaneseLuniSolarCalendar(), _
                                      New JulianCalendar(), _
                                      New KoreanCalendar(), _
                                      New KoreanLuniSolarCalendar(), _
                                      New PersianCalendar(), _
                                      New TaiwanCalendar(), _
                                      New TaiwanLuniSolarCalendar(), _
                                      New ThaiBuddhistCalendar(), _
                                      New UmAlQuraCalendar() }
      For Each cal As Calendar In calendars
         Console.WriteLine("Calling AddDays...")
         AddDays(cal)   
         Console.WRiteLine("Calling AddHours...")
         AddHours(cal)
         Console.WriteLine("Calling AddMilliseconds...")
         AddMilliseconds(cal)
         Console.WRiteLine("Calling AddMinutes...")
         AddMinutes(cal)
         Console.WriteLine("Calling AddMonths...")
         AddMonths(cal)
         Console.WriteLine("Calling AddSeconds...")
         AddSeconds(cal)
         Console.WRiteLine("Calling AddWeeks...")
         AddWeeks(cal)
         Console.WriteLine("Calling AddYears...")
         AddYears(cal)
      Next
   End Sub
   
   Private Sub AddDays(cal As Calendar)
      Dim days As Integer = 3
      Example.time = date1
            
      Dim newDate As Date = cal.AddDays(date1, days)
      If newDate.Kind = date1.Kind Then Console.WriteLine("      " + cal.ToString() + ": Local Equal")
      newDate = cal.AddDays(date2, days)
      If newDate.Kind = date2.Kind Then Console.WriteLine("      " + cal.ToString() + ": UTC Equal")
      ' <Snippet1>
      returnTime = DateTime.SpecifyKind(cal.AddDays(time, days), time.Kind)
      ' </Snippet1>
      Console.WRiteLine(returnTime.Kind = time.Kind)
   End Sub
   
   Private Sub AddHours(cal As Calendar)
      Dim hours As Integer = 3
      Example.time = date1

      Dim newDate As Date = cal.AddHours(date1, hours)
      If newDate.Kind = date1.Kind Then Console.WriteLine("      " + cal.ToString() + ": Local Equal")
      newDate = cal.AddHours(date2, hours)
      If newDate.Kind = date2.Kind Then Console.WriteLine("      " + cal.ToString() + ": UTC Equal")
      ' <Snippet2>
      returnTime = DateTime.SpecifyKind(cal.AddHours(time, hours), time.Kind)
      ' </Snippet2>
      Console.WriteLine(returnTime.Kind = time.Kind)
   End Sub
   
   Private Sub AddMilliseconds(cal As Calendar)
      Dim milliseconds As Integer = 100000
      Example.time = date1

      Dim newDate As Date = cal.AddMilliseconds(date1, milliseconds)
      If newDate.Kind = date1.Kind Then Console.WriteLine("      " + cal.ToString() + ": Local Equal")
      newDate = cal.AddMilliseconds(date2, milliseconds)
      If newDate.Kind = date2.Kind Then Console.WriteLine("      " + cal.ToString() + ": UTC Equal")
      ' <Snippet3>
      returnTime = DateTime.SpecifyKind(cal.AddMilliseconds(time, milliseconds), time.Kind)
      ' </Snippet3>
      Console.WriteLine(returnTime.Kind = time.Kind)
   End Sub
   
   Private Sub AddMinutes(cal As Calendar)
      Dim minutes As Integer = 90
      Example.time = date1

      Dim newDate As Date = cal.AddMinutes(date1, minutes)
      If newDate.Kind = date1.Kind Then Console.WriteLine("      " + cal.ToString() + ": Local Equal")
      newDate = cal.AddMinutes(date2, minutes)
      If newDate.Kind = date2.Kind Then Console.WriteLine("      " + cal.ToString() + ": UTC Equal")
      ' <Snippet4>
      returnTime = DateTime.SpecifyKind(cal.AddMinutes(time, minutes), time.Kind)
      ' </Snippet4>
      Console.WriteLine(returnTime.Kind = time.Kind)
   End Sub
   
   Private Sub AddMonths(cal As Calendar)
      Dim months As Integer = 11
      Example.time = date1

      Dim newDate As Date = cal.AddMonths(date1, months)
      If newDate.Kind = date1.Kind Then Console.WriteLine("      " + cal.ToString() + ": Local Equal")
      newDate = cal.AddMonths(date2, months)
      If newDate.Kind = date2.Kind Then Console.WriteLine("      " + cal.ToString() + ": UTC Equal")
      ' <Snippet5>
      returnTime = DateTime.SpecifyKind(cal.AddMonths(time, months), time.Kind)
      ' </Snippet5>
      Console.WriteLine(returnTime.Kind = time.Kind)
   End Sub
   
   Private Sub AddSeconds(cal As Calendar)
      Dim seconds As Integer = 90
      Example.time = date1

      Dim newDate As Date = cal.AddSeconds(date1, seconds)
      If newDate.Kind = date1.Kind Then Console.WriteLine("      " + cal.ToString() + ": Local Equal")
      newDate = cal.AddSeconds(date2, seconds)
      If newDate.Kind = date2.Kind Then Console.WriteLine("      " + cal.ToString() + ": UTC Equal")
      ' <Snippet6>
      returnTime = DateTime.SpecifyKind(cal.AddSeconds(time, seconds), time.Kind)
      ' </Snippet6>
      Console.WriteLine(returnTime.Kind = time.Kind)
   End Sub
   
   Private Sub AddWeeks(cal As Calendar)
      Dim weeks As Integer = 12
      Example.time = date1

      Dim newDate As Date = cal.AddWeeks(date1, weeks)
      If newDate.Kind = date1.Kind Then Console.WriteLine("      " + cal.ToString() + ": Local Equal")
      newDate = cal.AddWeeks(date2, weeks)
      If newDate.Kind = date2.Kind Then Console.WriteLine("      " + cal.ToString() + ": UTC Equal")
      ' <Snippet7>
      returnTime = DateTime.SpecifyKind(cal.AddWeeks(time, weeks), time.Kind)
      ' </Snippet7>
      Console.WriteLine(returnTime.Kind = time.Kind)
   End Sub
   
   Private Sub AddYears(cal As Calendar)
      Dim years As Integer = 12
      Example.time = date1

      Dim newDate As Date = cal.AddYears(date1, years)
      If newDate.Kind = date1.Kind Then Console.WriteLine("      " + cal.ToString() + ": Local Equal")
      newDate = cal.AddYears(date2, years)
      If newDate.Kind = date2.Kind Then Console.WriteLine("      " + cal.ToString() + ": UTC Equal")
      ' <Snippet8>
      returnTime = DateTime.SpecifyKind(cal.AddYears(time, years), time.Kind)
      ' </Snippet8>
      Console.WriteLine(returnTime.Kind = time.Kind)
   End Sub
End Module

