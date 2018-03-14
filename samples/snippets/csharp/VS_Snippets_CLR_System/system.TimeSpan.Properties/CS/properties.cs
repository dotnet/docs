//<Snippet1>
using System;

class Example
{
    static void Main()
    {
        // Create and display a TimeSpan value of 1 tick.
        Console.Write("\n{0,-45}", "TimeSpan( 1 )");
        ShowTimeSpanProperties(new TimeSpan(1));

        // Create a TimeSpan value with a large number of ticks.
        Console.Write("\n{0,-45}", "TimeSpan( 111222333444555 )");
        ShowTimeSpanProperties(new TimeSpan(111222333444555));

        // This TimeSpan has all fields specified.
        Console.Write("\n{0,-45}", "TimeSpan( 10, 20, 30, 40, 50 )");
        ShowTimeSpanProperties(new TimeSpan(10, 20, 30, 40, 50));

        // This TimeSpan has all fields overflowing.
        Console.Write("\n{0,-45}",
                      "TimeSpan( 1111, 2222, 3333, 4444, 5555 )");
        ShowTimeSpanProperties(
           new TimeSpan(1111, 2222, 3333, 4444, 5555));

        // This TimeSpan is based on a number of days.
        Console.Write("\n{0,-45}", "FromDays( 20.84745602 )");
        ShowTimeSpanProperties(TimeSpan.FromDays( 20.84745602));
    }

    static void ShowTimeSpanProperties( TimeSpan interval )
    {
        Console.WriteLine("{0,21}", interval);
        Console.WriteLine("{0,-12}{1,8}       {2,-18}{3,21:N3}", "Days",
                          interval.Days, "TotalDays", interval.TotalDays);
        Console.WriteLine("{0,-12}{1,8}       {2,-18}{3,21:N3}", "Hours",
                          interval.Hours, "TotalHours", interval.TotalHours);
        Console.WriteLine("{0,-12}{1,8}       {2,-18}{3,21:N3}", "Minutes",
                          interval.Minutes, "TotalMinutes", interval.TotalMinutes);
        Console.WriteLine("{0,-12}{1,8}       {2,-18}{3,21:N3}", "Seconds",
                          interval.Seconds, "TotalSeconds", interval.TotalSeconds);
        Console.WriteLine("{0,-12}{1,8}       {2,-18}{3,21:N3}", "Milliseconds",
                          interval.Milliseconds, "TotalMilliseconds",
                          interval.TotalMilliseconds);
        Console.WriteLine("{0,-12}{1,8}       {2,-18}{3,21:N0}", null, null,
            "Ticks", interval.Ticks);
    } 
}
// The example displays the following output if the current culture is en-US:
//    TimeSpan( 1 )                                     00:00:00.0000001
//    Days               0       TotalDays                         0.000
//    Hours              0       TotalHours                        0.000
//    Minutes            0       TotalMinutes                      0.000
//    Seconds            0       TotalSeconds                      0.000
//    Milliseconds       0       TotalMilliseconds                 0.000
//                               Ticks                                 1
//
//    TimeSpan( 111222333444555 )                   128.17:30:33.3444555
//    Days             128       TotalDays                       128.730
//    Hours             17       TotalHours                    3,089.509
//    Minutes           30       TotalMinutes                185,370.556
//    Seconds           33       TotalSeconds             11,122,233.344
//    Milliseconds     344       TotalMilliseconds    11,122,233,344.456
//                               Ticks               111,222,333,444,555
//
//    TimeSpan( 10, 20, 30, 40, 50 )                 10.20:30:40.0500000
//    Days              10       TotalDays                        10.855
//    Hours             20       TotalHours                      260.511
//    Minutes           30       TotalMinutes                 15,630.668
//    Seconds           40       TotalSeconds                937,840.050
//    Milliseconds      50       TotalMilliseconds       937,840,050.000
//                               Ticks                 9,378,400,500,000
//
//    TimeSpan( 1111, 2222, 3333, 4444, 5555 )     1205.22:47:09.5550000
//    Days            1205       TotalDays                     1,205.949
//    Hours             22       TotalHours                   28,942.786
//    Minutes           47       TotalMinutes              1,736,567.159
//    Seconds            9       TotalSeconds            104,194,029.555
//    Milliseconds     555       TotalMilliseconds   104,194,029,555.000
//                               Ticks             1,041,940,295,550,000
//
//    FromDays( 20.84745602 )                        20.20:20:20.2000000
//    Days              20       TotalDays                        20.847
//    Hours             20       TotalHours                      500.339
//    Minutes           20       TotalMinutes                 30,020.337
//    Seconds           20       TotalSeconds              1,801,220.200
//    Milliseconds     200       TotalMilliseconds     1,801,220,200.000
//                               Ticks                18,012,202,000,000
// </Snippet1>
