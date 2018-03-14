' Conversions Examples
Option Strict On

<Assembly: CLSCompliant(True)>
Module modMain
   Public Sub Main()
      Console.WriteLine()
      Console.WriteLine("ConvertToUtc:")
      ConvertToUtc()
      Console.WriteLine()
      Console.WriteLine("ConvertZonesToUtc:")
      ConvertZonesToUtc()
      Console.WriteLine()
      ConvertZonesById()
   End Sub
   
   Private Sub ConvertToUtc()
      ' <Snippet1>
      Dim datNowLocal As Date = Date.Now
      Console.WriteLine("Converting {0}, Kind {1}:", datNowLocal, datNowLocal.Kind)
      Console.WriteLine("   ConvertTimeToUtc: {0}, Kind {1}", TimeZoneInfo.ConvertTimeToUtc(datNowLocal), TimeZoneInfo.ConvertTimeToUtc(datNowLocal).Kind)
      Console.WriteLine()

      Dim datNowUtc As Date = Date.UtcNow
      Console.WriteLine("Converting {0}, Kind {1}", datNowUtc, datNowUtc.Kind)
      Console.WriteLine("   ConvertTimeToUtc: {0}, Kind {1}", TimeZoneInfo.ConvertTimeToUtc(datNowUtc), TimeZoneInfo.ConvertTimeToUtc(datNowUtc).Kind)
      Console.WriteLine()
      
      Dim datNow As Date = CDate("10/26/2007 1:32:00 PM")
      Console.WriteLine("Converting {0}, Kind {1}", datNow, datNow.Kind)
      Console.WriteLine("   ConvertTimeToUtc: {0}, Kind {1}", TimeZoneInfo.ConvertTimeToUtc(datNow), TimeZoneInfo.ConvertTimeToUtc(datNow).Kind)
      Console.WriteLine()
      
      Dim datAmbiguous As Date = #11/4/2007 1:30:00AM#    
      Console.WriteLine("Converting {0}, Kind {1}, Ambiguous {2}", datAmbiguous, datAmbiguous.Kind, TimeZoneInfo.Local.IsAmbiguousTime(datAmbiguous))
      Console.WriteLine("   ConvertTimeToUtc: {0}, Kind {1}", TimeZoneInfo.ConvertTimeToUtc(datAmbiguous), TimeZoneInfo.ConvertTimeToUtc(datAmbiguous).Kind)
      Console.WriteLine()
      
      Dim datInvalid As Date = #03/11/2007 2:30:00AM#    
      Console.WriteLine("Converting {0}, Kind {1}, Invalid {2}", datInvalid, datInvalid.Kind, TimeZoneInfo.Local.IsInvalidTime(datInvalid))
      Try
         Console.WriteLine("   ConvertTimeToUtc: {0}, Kind {1}", TimeZoneInfo.ConvertTimeToUtc(datInvalid), TimeZoneInfo.ConvertTimeToUtc(datInvalid).Kind)
      Catch e As ArgumentException
         Console.WriteLine("   {0}: Cannot convert {1} to UTC.", e.GetType().Name, datInvalid)
      End Try
      Console.WriteLine()

      Dim datNearMax As Date = #12/31/9999 10:00:00PM#
      Console.WriteLine("Converting {0}, Kind {1}", datNearMax, datNearMax.Kind)
      Console.WriteLine("   ConvertTimeToUtc: {0}, Kind {1}", TimeZoneInfo.ConvertTimeToUtc(datNearMax), TimeZoneInfo.ConvertTimeToUtc(datNearMax).Kind)
      Console.WriteLine()
      '
      ' This example produces the following output if the local time zone 
      ' is Pacific Standard Time:
      '
      '    Converting 8/31/2007 2:26:28 PM, Kind Local:
      '       ConvertTimeToUtc: 8/31/2007 9:26:28 PM, Kind Utc
      '    
      '    Converting 8/31/2007 9:26:28 PM, Kind Utc
      '       ConvertTimeToUtc: 8/31/2007 9:26:28 PM, Kind Utc
      '    
      '    Converting 10/26/2007 1:32:00 PM, Kind Unspecified
      '       ConvertTimeToUtc: 10/26/2007 8:32:00 PM, Kind Utc
      '    
      '    Converting 11/4/2007 1:30:00 AM, Kind Unspecified, Ambiguous True
      '       ConvertTimeToUtc: 11/4/2007 9:30:00 AM, Kind Utc
      '    
      '    Converting 3/11/2007 2:30:00 AM, Kind Unspecified, Invalid True
      '       ArgumentException: Cannot convert 3/11/2007 2:30:00 AM to UTC.
      '    
      '    Converting 12/31/9999 10:00:00 PM, Kind Unspecified
      '       ConvertTimeToUtc: 12/31/9999 11:59:59 PM, Kind Utc
      ' </Snippet1> 
   End Sub
   
   Private Sub ConvertZonesToUtc()
   End Sub      
   
   Private Sub ConvertZonesById()
      ' <Snippet3>
      Dim currentTime As Date = Date.Now
      Console.WriteLine("Current Times:")
      Console.WriteLine()
      Console.WriteLine("Los Angeles: {0}", _
                        TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Pacific Standard Time"))
      Console.WriteLine("Chicago: {0}", _ 
                        TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Central Standard Time"))
      Console.WriteLine("New York: {0}", _
                        TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Eastern Standard Time"))
      Console.WriteLine("London: {0}", _
                        TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "GMT Standard Time"))
      Console.WriteLine("Moscow: {0}", _
                        TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Russian Standard Time"))
      Console.WriteLine("New Delhi: {0}", _
                        TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "India Standard Time"))
      Console.WriteLine("Beijing: {0}", _
                        TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "China Standard Time"))
      Console.WriteLine("Tokyo: {0}", _
                        TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Tokyo Standard Time"))
      ' </Snippet3>
   End Sub
End Module

