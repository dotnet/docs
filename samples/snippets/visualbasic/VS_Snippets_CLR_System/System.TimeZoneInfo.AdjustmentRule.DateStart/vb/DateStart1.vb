' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections.ObjectModel
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim timeZones As ReadOnlyCollection(Of TimeZoneInfo) = TimeZoneInfo.GetSystemTimeZones()
      Dim dateInfo As DateTimeFormatInfo = CultureInfo.CurrentCulture.DateTimeFormat
      
      For Each zone In timeZones
         Console.WriteLine("{0} transition time information:", zone.StandardName)
         Console.WriteLine("   Time zone information: ")
         Console.WriteLine("      Base UTC Offset: {0}", zone.BaseUtcOffset)
         Console.WriteLine("      Supports DST: {0}", zone.SupportsDaylightSavingTime)

         Dim adjustmentRules() As TimeZoneInfo.AdjustmentRule = zone.GetAdjustmentRules()
         
         ' Indicate that time zone has no adjustment rules
         If adjustmentRules.Length = 0 Then
            Console.WriteLine("      No adjustment rules defined.")
         Else
            Console.WriteLine("      Adjustment Rules: {0}", adjustmentRules.Length)
            ' Iterate adjustment rules       
            For Each adjustmentRule In adjustmentRules
               Console.WriteLine("   Adjustment rule from {0:d} to {1:d}:", 
                                 adjustmentRule.DateStart, 
                                 adjustmentRule.DateEnd)                                 
               Console.WriteLine("      Delta: {0}", adjustmentRule.DaylightDelta)
               ' Get start of transition
               Dim daylightStart As TimeZoneInfo.TransitionTime = adjustmentRule.DaylightTransitionStart
               ' Display information on floating date rule
               If Not daylightStart.IsFixedDateRule Then
                  Console.WriteLine("      Begins at {0:t} on the {1} {2} of {3}", 
                                 daylightStart.TimeOfDay, 
                                 CType(daylightStart.Week, WeekOfMonth),  
                                 daylightStart.DayOfWeek, 
                                 dateInfo.GetMonthName(daylightStart.Month))
               ' Display information on fixed date rule 
               Else
                  Console.WriteLine("      Begins at {0:t} on {1} {2}", 
                                    daylightStart.TimeOfDay, 
                                    dateInfo.GetMonthName(daylightStart.Month), 
                                    daylightStart.Day)
               End If
               
               ' Get end of transition.
               Dim daylightEnd As TimeZoneInfo.TransitionTime = adjustmentRule.DaylightTransitionEnd
               ' Display information on floating date rule.
               If Not daylightEnd.IsFixedDateRule Then 
                  Console.WriteLine("      Ends at {0:t} on the {1} {2} of {3}", 
                                 daylightEnd.TimeOfDay, 
                                 CType(daylightEnd.Week, WeekOfMonth),  
                                 daylightEnd.DayOfWeek, 
                                 dateInfo.GetMonthName(daylightEnd.Month))
               ' Display information on fixed date rule.
               Else
                  Console.WriteLine("      Ends at {0:t} on {1} {2}", 
                                    daylightEnd.TimeOfDay, 
                                    dateInfo.GetMonthName(daylightEnd.Month), 
                                    daylightEnd.Day)
               End If
            Next
         End If   
      Next   
   End Sub

   Private Enum WeekOfMonth As Integer
      First = 1
      Second = 2
      Third = 3
      Fourth = 4
      Last = 5
   End Enum
End Module
' A portion of the output from the example might appear as follows:
'       Tonga Standard Time transition time information:
'          Time zone information:
'             Base UTC Offset: 13:00:00
'             Supports DST: False
'             No adjustment rules defined.
'       Samoa Standard Time transition time information:
'          Time zone information:
'             Base UTC Offset: 13:00:00
'             Supports DST: True
'             Adjustment Rules: 4
'          Adjustment rule from 1/1/0001 to 12/31/2009:
'             Delta: 00:00:00
'             Begins at 12:00 AM on January 1
'             Ends at 12:00 AM on January 1
'          Adjustment rule from 1/1/2010 to 12/31/2010:
'             Delta: 01:00:00
'             Begins at 11:59 PM on the Last Saturday of September
'             Ends at 12:00 AM on the First Friday of January
'          Adjustment rule from 1/1/2011 to 12/31/2011:
'             Delta: 01:00:00
'             Begins at 3:00 AM on the Fourth Saturday of September
'             Ends at 4:00 AM on the First Saturday of April
'          Adjustment rule from 1/1/2012 to 12/31/9999:
'             Delta: 01:00:00
'             Begins at 12:00 AM on the Last Sunday of September
'             Ends at 1:00 AM on the First Sunday of April
'       Line Islands Standard Time transition time information:
'          Time zone information:
'             Base UTC Offset: 14:00:00
'             Supports DST: False
'             No adjustment rules defined.
' </Snippet1>

