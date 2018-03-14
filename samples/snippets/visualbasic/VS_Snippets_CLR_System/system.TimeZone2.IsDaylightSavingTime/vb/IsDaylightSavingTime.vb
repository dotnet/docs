' Visual Basic .NET Document
Option Strict On

<Assembly: CLSCompliant(True)>
Module modMain

   Dim cst, est As TimeZoneInfo
   
   Public Sub Main()
      AnalyzeTimes()
      Do 
         Dim dateString As String = InputBox("Enter a Date: ")
         If IsDate(dateString) Then
            DisplayDateWithTimeZoneName(CDate(dateString), TimeZoneInfo.Local)
         Else
            Exit Do
         End If
      Loop  
      Console.WriteLine()
      MayBeDST()
   End Sub
   
   Private Sub AnalyzeTimes()
      cst = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time")
      est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")
      
      ' Try Daylight Saving Ttme with a local time
      Dim localDat As Date = New Date(2006, 06, 15, 1, 00, 00, DateTimeKind.Local) 
      DisplayDstResult(localDat)
      
      ' Try standard time on edge of DST
      Dim datJustBeforeDST As New Date(2006, 04, 02, 01, 00, 00, DateTimeKind.Local)
      DisplayDstResult(datJustBeforeDST)

      ' Try UTC Date and Time of 10/29/2006 at 8:00 AM (DST in both zones)
      Dim datUTC As Date = New  Date(2006, 10, 29, 8, 00, 00, DateTimeKind.Utc)
      DisplayDSTResult(datUTC)

      ' Try DST with Unspecified on edge of DST
      Dim datUnsp1 As Date = New Date(2006, 10, 29, 1, 00, 00, DateTimeKind.Unspecified)
      DisplayDSTResult(datUnsp1)
      
      ' Try DST with Unspecified in DST
      Dim datUnsp2 As Date = New Date(2006, 10, 29, 00, 00, 00, DateTimeKind.Unspecified)
      DisplayDSTResult(datUnsp2)
   End Sub
   
   Private Sub DisplayDSTResult(dat As Date)
      Console.WriteLine("Result for {0}, Kind {1}", dat, dat.Kind.ToString())
      Console.WriteLine("   Local: {0}", TimeZoneInfo.Local.IsDaylightSavingTime(dat))
      Console.WriteLine("   Utc:   {0}", TimeZoneInfo.Utc.IsDaylightSavingTime(dat))
      Console.WriteLine("   CST:   {0}", cst.IsDaylightSavingTime(dat))
      Console.WriteLine("   EST:   {0}", est.IsDaylightSavingTime(dat))

      Console.WriteLine()
   End Sub

   ' <Snippet1>
   Private Sub DisplayDateWithTimeZoneName(date1 As Date, timeZone As TimeZoneInfo)
      Console.WriteLine("The time is {0:t} on {0:d} {1}", _
                        date1, _
                        IIf(timeZone.IsDaylightSavingTime(date1), _
                            timezone.DaylightName, timezone.StandardName))   
   End Sub
   ' The example displays output similar to the following:
   '    The time is 1:00 AM on 4/2/2006 Pacific Standard Time   
   ' </Snippet1>

   Private Sub MayBeDST()
      ' <Snippet2>
      Dim unclearDate As Date = #11/4/2007 1:30AM#
      ' Test if time is ambiguous.
      Console.WriteLine("In the {0}, {1} is {2}ambiguous.", _ 
                        TimeZoneInfo.Local.DisplayName, _
                        unclearDate, _
                        IIf(TimeZoneInfo.Local.IsAmbiguousTime(unclearDate), "", "not "))
      ' Test if time is DST.
      Console.WriteLine("In the {0}, {1} is {2}daylight saving time.", _ 
                        TimeZoneInfo.Local.DisplayName, _
                        unclearDate, _
                        IIf(TimeZoneInfo.Local.IsDaylightSavingTime(unclearDate), "", "not "))
      Console.WriteLine()    
      ' Report time as DST if it is either ambiguous or DST.
      If TimeZoneInfo.Local.IsAmbiguousTime(unclearDate) OrElse _ 
         TimeZoneInfo.Local.IsDaylightSavingTime(unclearDate) Then
          Console.WriteLine("{0} may be daylight saving time in {1}.", _ 
                            unclearDate, TimeZoneInfo.Local.DisplayName)                                           
      End If
      ' The example displays the following output:
      '    In the (GMT-08:00) Pacific Time (US & Canada), 11/4/2007 1:30:00 AM is ambiguous.
      '    In the (GMT-08:00) Pacific Time (US & Canada), 11/4/2007 1:30:00 AM is not daylight saving time.
      '    
      '    11/4/2007 1:30:00 AM may be daylight saving time in (GMT-08:00) Pacific Time (US & Canada).
      ' </Snippet2>
   End Sub
End Module

