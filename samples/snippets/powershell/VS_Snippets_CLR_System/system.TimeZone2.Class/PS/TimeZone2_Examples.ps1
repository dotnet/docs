#  Get timezone/date details and open a stream writer
$DateFormats    = [System.Globalization.CultureInfo]::CurrentCulture.DateTimeFormat
$TimeZones      = [System.TimeZoneInfo]::GetSystemTimeZones()
$OutputFileName = 'C:\Temp\TimeZoneInfo.txt'
$Sw             = New-Object -TypeName System.IO.StreamWriter -ArgumentList $OutputFileName,$false
# Write overview information
$Sw.WriteLine('{0} Time zones on this system' -f $TimeZones.Count)

# Process each timezone on the system
# Write details to the streamwriter
foreach ($TimeZone in $TimeZones) {
 $HasDST        = $TimeZone.SupportsDaylightSavingTime
 $OffsetFromUtc = $TimeZone.BaseUtcOffset
 $Sw.WriteLine("ID: {0}" -f $TimeZone.Id)
 $Sw.WriteLine("   Display Name:  {0}" -f $TimeZone.DisplayName)
 $Sw.WriteLine("   Standard Name: {0}" -f $TimeZone.StandardName)
 $Sw.Write("   Daylight Name: {0}" -f $TimeZone.DaylightName)
 $Sw.Write( $(If ($HasDST) {"  ***Has: "} Else {"  ***Does Not Have: "}))
 $Sw.WriteLine("Daylight Saving Time***")
 $OffsetString = "{0} hours, {1} minutes" -f $OffsetFromUtc.Hours, $OffsetFromUtc.Minutes
 $Sw.WriteLine("   Offset from UTC: {0}"  -f $offsetString)
 $AdjustRules = $timeZone.GetAdjustmentRules()
 $Sw.WriteLine("   Number of adjustment rules: {0}" -f $adjustRules.Count)
 If ($AdjustRules.Count -gt 0)
 {
    $Sw.WriteLine("   Adjustment Rules:")
    foreach ($Rule in $AdjustRules)
    {
       $TransTimeStart = $Rule.DaylightTransitionStart
       $TransTimeEnd   = $Rule.DaylightTransitionEnd
       $Sw.WriteLine(("     From   {0} to {1}" -f $Rule.DateStart, $Rule.DateEnd))
       $Sw.WriteLine(("       Delta: {0}" -f $Rule.DaylightDelta))
       if (-Not  $TransTimeStart.IsFixedDateRule)
       {
          $Sw.WriteLine(("       Begins at {0:t} on {1} of week {2} of {3}" -f $TransTimeStart.TimeOfDay, 
                                                                             $TransTimeStart.DayOfWeek,                                                                                 
                                                                             $TransTimeStart.Week, 
                                                                             $DateFormats.MonthNames[$TransTimeStart.Month - 1]))
          $Sw.WriteLine(("       Ends at {0:t} on {1} of week {2} of {3}" -f $TransTimeEnd.TimeOfDay,
                                                                             $TransTimeEnd.DayOfWeek, 
                                                                             $TransTimeEnd.Week,
                                                                             $DateFormats.MonthNames[[int] $TransTimeEnd.Month - 1]))
       }
     else
       {
         $Sw.WriteLine(("       Begins at {0:t} on {1} {2}" -f $TransTimeStart.TimeOfDay, 
                                                             $TransTimeStart.Day, 
                                                             $DateFormats.MonthNames[$transTimeStart.Month - 1]))
         $Sw.WriteLine(("       Ends at {0:t} on {1} {2}"   -f $TransTimeEnd.TimeOfDay, 
                                                             $TransTimeEnd.Day, 
                                                             $DateFormats.MonthNames[$transTimeEnd.Month - 1]))        
       }
    } # End of processing each adjustment rule
 } # End of checking adjustment rules
} # End of processing Time Zones

# Close stream writer then display output in notepad
$Sw.Close() 

#  Output of 1st three time zones:
#  135 Time zones on this system
#  ID: Dateline Standard Time
#     Display Name:  (UTC-12:00) International Date Line West
#     Standard Name: Dateline Standard Time
#     Daylight Name: Dateline Summer Time  ***Does Not Have: Daylight Saving Time***
#     Offset from UTC: -12 hours, 0 minutes
#     Number of adjustment rules: 0
#  ID: UTC-11
#     Display Name:  (UTC-11:00) Co-ordinated Universal Time-11
#     Standard Name: UTC-11
#     Daylight Name: UTC-11  ***Does Not Have: Daylight Saving Time***
#     Offset from UTC: -11 hours, 0 minutes
#     Number of adjustment rules: 0
#  ID: Aleutian Standard Time
#     Display Name:  (UTC-10:00) Aleutian Islands
#     Standard Name: Aleutian Standard Time
#     Daylight Name: Aleutian Summer Time  ***Has: Daylight Saving Time***
#     Offset from UTC: -10 hours, 0 minutes
#     Number of adjustment rules: 2
#     Adjustment Rules:
#       From   01/01/0001 00:00:00 to 31/12/2006 00:00:00
#         Delta: 01:00:00
#         Begins at 02:00 on Sunday of week 1 of April
#         Ends at 02:00 on Sunday of week 5 of October
#       From   01/01/2007 00:00:00 to 31/12/9999 00:00:00
#         Delta: 01:00:00
#         Begins at 02:00 on Sunday of week 2 of March
#         Ends at 02:00 on Sunday of week 1 of November
