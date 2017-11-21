# Define two dates.
$date2 = Get-Date -Date '2010/8/18'-Hour 13 -Minute 30 -Second 30
$date1 = Get-Date -Date '2010/1/1' -Hour 8  -Minute 0  -second 15

# Calculate the interval between the two dates.
$interval = $date2 - $date1
"{0} - {1} = {2}" -f $date2, $date1, ($interval.ToString())

#  Display individual properties of the resulting TimeSpan object.
"   {0,-35} {1,20}" -f "Value of Days Component:", $interval.Days
"   {0,-35} {1,20}" -f "Total Number of Days:", $interval.TotalDays
"   {0,-35} {1,20}" -f "Value of Hours Component:", $interval.Hours
"   {0,-35} {1,20}" -f "Total Number of Hours:", $interval.TotalHours
"   {0,-35} {1,20}" -f "Value of Minutes Component:", $interval.Minutes
"   {0,-35} {1,20}" -f "Total Number of Minutes:", $interval.TotalMinutes
"   {0,-35} {1,20:N0}" -f "Value of Seconds Component:", $interval.Seconds
"   {0,-35} {1,20:N0}" -f "Total Number of Seconds:", $interval.TotalSeconds
"   {0,-35} {1,20:N0}" -f "Value of Milliseconds Component:", $interval.Milliseconds
"   {0,-35} {1,20:N0}" -f "Total Number of Milliseconds:", $interval.TotalMilliseconds
"   {0,-35} {1,20:N0}" -f "Ticks:", $interval.Ticks

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
