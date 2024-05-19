using System;

internal class TimeSpanExample
{
    public static void RunIt()
    {
        // <TimeSpan.From>
        TimeSpan timeSpan1 = TimeSpan.FromSeconds(value: 101.832);
        Console.WriteLine($"timeSpan1 = {timeSpan1}");
        // timeSpan1 = 00:01:41.8319999

        TimeSpan timeSpan2 = TimeSpan.FromSeconds(seconds: 101, milliseconds: 832);
        Console.WriteLine($"timeSpan2 = {timeSpan2}");
        // timeSpan2 = 00:01:41.8320000
        // </TimeSpan.From>
    }
}
