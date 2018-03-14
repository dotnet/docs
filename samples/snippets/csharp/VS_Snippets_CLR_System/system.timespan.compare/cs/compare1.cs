// <Snippet1>
using System;

class Example
{
    static void Main()
    {
        // Define a time interval equal to two hours.
        TimeSpan baseInterval = new TimeSpan( 2, 0, 0);

        // Define an array of time intervals to compare with
        // the base interval.
        TimeSpan[] spans = { TimeSpan.FromSeconds(-2.5),
                             TimeSpan.FromMinutes(20),
                             TimeSpan.FromHours(1), 
                             TimeSpan.FromMinutes(90),
                             baseInterval,  
                             TimeSpan.FromDays(.5), 
                             TimeSpan.FromDays(1) };

        // Compare the time intervals.
        foreach (var span in spans) {
           int result = TimeSpan.Compare(baseInterval, span);
           Console.WriteLine("{0} {1} {2} (Compare returns {3})", 
                             baseInterval,
                             result == 1 ? ">" : result == 0 ? "=" : "<",
                             span, result);     
        }
    } 
} 
// The example displays the following output:
//       02:00:00 > -00:00:02.5000000 (Compare return
//       02:00:00 > 00:20:00 (Compare returns 1
//       02:00:00 > 01:00:00 (Compare returns 1
//       02:00:00 > 01:30:00 (Compare returns 1
//       02:00:00 = 02:00:00 (Compare returns 0
//       02:00:00 < 12:00:00 (Compare returns -1
//       02:00:00 < 1.00:00:00 (Compare returns -1
// </Snippet1>
