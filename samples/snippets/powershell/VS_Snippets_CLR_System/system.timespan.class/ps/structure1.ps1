# Define two dates.
$Date2 = Get-Date -Date '2010/8/18' -Hour 13 -Minute 30 -Second 30
$Date1 = Get-Date -Date '2010/1/1'  -Hour 8  -Minute 0  -Second 15

# Calculate the interval between the two dates.
$Interval = $Date2 - $Date1
"{0} - {1} = {2}" -f $Date2, $Date1, ($Interval.ToString())

#  Display individual properties of the resulting TimeSpan object.
"   {0,-35} {1,20}"    -f "Value of Days Component:", $Interval.Days
"   {0,-35} {1,20}"    -f "Total Number of Days:", $Interval.TotalDays
"   {0,-35} {1,20}"    -f "Value of Hours Component:", $Interval.Hours
"   {0,-35} {1,20}"    -f "Total Number of Hours:", $Interval.TotalHours
"   {0,-35} {1,20}"    -f "Value of Minutes Component:", $Interval.Minutes
"   {0,-35} {1,20}"    -f "Total Number of Minutes:", $Interval.TotalMinutes
"   {0,-35} {1,20:N0}" -f "Value of Seconds Component:", $Interval.Seconds
"   {0,-35} {1,20:N0}" -f "Total Number of Seconds:", $Interval.TotalSeconds
"   {0,-35} {1,20:N0}" -f "Value of Milliseconds Component:", $Interval.Milliseconds
"   {0,-35} {1,20:N0}" -f "Total Number of Milliseconds:", $Interval.TotalMilliseconds
"   {0,-35} {1,20:N0}" -f "Ticks:", $Interval.Ticks

<# This sample produces the following output:

18/08/2010 13:30:30 - 01/01/2010 08:00:15 = 229.05:30:15
   Value of Days Component:                             229
   Total Number of Days:                   229.229340277778
   Value of Hours Component:                              5
   Total Number of Hours:                  5501.50416666667
   Value of Minutes Component:                           30
   Total Number of Minutes:                       330090.25
   Value of Seconds Component:                           15
   Total Number of Seconds:                      19,805,415
   Value of Milliseconds Component:                       0
   Total Number of Milliseconds:             19,805,415,000
   Ticks:                               198,054,150,000,000
#>
