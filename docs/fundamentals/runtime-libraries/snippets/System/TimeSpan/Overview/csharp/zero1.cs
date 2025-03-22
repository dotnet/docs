using System;

public class Example4
{
    public static void Main()
    {
        // <Snippet6>
        Random rnd = new Random();

        TimeSpan timeSpent = TimeSpan.Zero;

        timeSpent += GetTimeBeforeLunch();
        timeSpent += GetTimeAfterLunch();

        Console.WriteLine($"Total time: {timeSpent}");

        TimeSpan GetTimeBeforeLunch()
        {
            return new TimeSpan(rnd.Next(3, 6), 0, 0);
        }

        TimeSpan GetTimeAfterLunch()
        {
            return new TimeSpan(rnd.Next(3, 6), 0, 0);
        }

        // The example displays output like the following:
        //        Total time: 08:00:00
        // </Snippet6>
    }
}
