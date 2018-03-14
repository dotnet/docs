// <snippet2>
using System;
using System.Threading;

public class Example
{
    private static Timer ticker;

    public static void TimerMethod(object state)
    {
        Console.Write(".");
    }

    public static void Main()
    {
        ticker = new Timer(TimerMethod, null, 1000, 1000);

        Console.WriteLine("Press the Enter key to end the program.");
        Console.ReadLine();
    }
}
// </snippet2>