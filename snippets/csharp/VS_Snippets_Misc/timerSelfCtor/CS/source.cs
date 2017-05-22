//<Snippet1>
using System;
using System.Threading;

public class Example
{
    public static void Main()
    {
        // Create an instance of the Example class, and start two
        // timers.
        Example ex = new Example();
        ex.StartTimer(2000);
        ex.StartTimer(1000);

        Console.WriteLine("Press Enter to end the program.");
        Console.ReadLine();
    }

    public void StartTimer(int dueTime)
    {
        Timer t = new Timer(new TimerCallback(TimerProc));
        t.Change(dueTime, 0);
    }

    private void TimerProc(object state)
    {
        // The state object is the Timer object.
        Timer t = (Timer) state;
        t.Dispose();
        Console.WriteLine("The timer callback executes.");
    }
}
//</Snippet1>


