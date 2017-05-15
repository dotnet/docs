' Visual Basic .NET Document
'
' TimeZoneInfo Examples

Option Strict On

Imports System.Collections.ObjectModel
Imports System.IO

<Assembly: CLSCompliant(True)>
Module modMain

   Public Sub Main()
      If MsgBox("Display time zone offset?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
         ShowTimezoneOffset()
      End If
      If MsgBox("Display time zone names?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
         ShowTimezoneNames()
      End If
      If MsgBox("Display universal time zone names?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
         ShowUniversalTimeZoneNames()
      End If
      If MsgBox("Show time zones without daylight savings time?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
         ShowNoDSTZones()
      End If
      If MsgBox("List all time zone IDs?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
         ShowTimeZoneIDs   
      End If
      If MsgBox("Test Time Zones for Equality?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
         TestForEquality()    
      End If
      If MsgBox("Show ambiguous times in Pacific Time Zone for 2007?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
         ShowAmbiguousTimes()      
      End If
      If MsgBox("Show invalid times in Pacific Time Zone for 2007?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
         ShowInvalidTimes()      
      End If
                
   End Sub
   
   Private Sub ShowTimezoneOffset()
      ' <Snippet1>
      Dim localZone As TimeZoneInfo = TimeZoneInfo.Local
      Console.WriteLine("The {0} time zone is {1}:{2} {3} than Coordinated Universal Time.", _ 
                        localZone.StandardName, _
                        Math.Abs(localZone.BaseUtcOffset.Hours), _
                        Math.Abs(localZone.BaseUtcOffset.Minutes), _
                        IIf(localZone.BaseUtcOffset >= TimeSpan.Zero, "later", "earlier"))
      ' </Snippet1>                  
   End Sub
   
   Private Sub ShowTimeZoneNames()
      Dim localZone As TimeZoneInfo = TimeZoneInfo.Local
      Console.WriteLine("Local Time Zone ID: {0}", localZone.Id)
      Console.WriteLine("   Display Name is: {0}.", localZone.DisplayName)
      Console.WriteLine("   Standard name is: {0}.", localZone.StandardName)
      Console.WriteLine("   Daylight saving name is: {0}.", localZone.DaylightName) 
   End Sub
   
   Private Sub ShowUniversalTimeZoneNames()
      ' <Snippet3>
      Dim universalZone As TimeZoneInfo = TimeZoneInfo.Utc
      Console.WriteLine("The universal time zone is {0}.", universalZone.DisplayName)
      Console.WriteLine("Its standard name is {0}.", universalZone.StandardName)
      Console.WriteLine("Its daylight savings name is {0}.", universalZone.DaylightName) 
      ' </Snippet3>
   End Sub
   
   Private Sub ShowNoDSTZones()
      ' <Snippet4>
      Dim zones As ReadOnlyCollection(Of TimeZoneInfo) = TimeZoneInfo.GetSystemTimeZones()
      For Each zone As TimeZoneInfo In zones
         If Not zone.SupportsDaylightSavingTime Then _
            Console.WriteLine(zone.DisplayName)
      Next
      ' </Snippet4> 
   End Sub

   Private Sub ShowTimeZoneIDs()
      ' <Snippet5>
      Dim zones As ReadOnlyCollection(Of TimeZoneInfo) = TimeZoneInfo.GetSystemTimeZones()
      Console.WriteLine("The local system has the following {0} time zones", zones.Count)
      For Each zone As TimeZoneInfo In zones
         Console.WriteLine(zone.Id)
      Next
      ' </Snippet5>
   End Sub
   
   Private Sub TestForEquality
      ' <Snippet7> 
      Dim thisTimeZone, zone1, zone2 As TimeZoneInfo
      
      thisTimeZone = TimeZoneInfo.Local
      zone1 = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time")
      zone2 = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")
      Console.WriteLine(thisTimeZone.Equals(zone1))
      Console.WriteLine(thisTimeZone.Equals(zone2))
      ' </Snippet7>
   End Sub
   
   Private Sub ShowAmbiguousTimes()
      ' <Snippet8>
      ' Specify DateTimeKind in Date constructor
      Dim baseTime As New Date(2007, 11, 4, 0, 59, 00, DateTimeKind.Unspecified)
      Dim newTime As Date
      
      ' Get Pacific Standard Time zone
      Dim pstZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time")

      ' List possible ambiguous times for 63-minute interval, from 12:59 AM to 2:01 AM 
      For ctr As Integer = 0 To 62
         ' Because of assignment, newTime.Kind is also DateTimeKind.Unspecified
         newTime = baseTime.AddMinutes(ctr)   
         Console.WriteLine("{0} is ambiguous: {1}", newTime, pstZone.IsAmbiguousTime(newTime))
      Next
      ' </Snippet8>
   End Sub
   
   Private Sub ShowInvalidTimes()
      ' <Snippet9> 
      ' Specify DateTimeKind in Date constructor
      Dim baseTime As New Date(2007, 3, 11, 1, 59, 0, DateTimeKind.Unspecified)
      Dim newTime As Date
      
      ' Get Pacific Standard Time zone
      Dim pstZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time")
      
      ' List possible invalid times for 63-minute interval, from 1:59 AM to 3:01 AM
      For ctr As Integer = 0 To 62
         ' Because of assignment, newTime.Kind is also DateTimeKind.Unspecified
         newTime = baseTime.AddMinutes(ctr)
         Console.WriteLine("{0} is invalid: {1}", newTime, pstZone.IsInvalidTime(newTime))
      Next
      ' </Snippet9>   
   End Sub
End Module

