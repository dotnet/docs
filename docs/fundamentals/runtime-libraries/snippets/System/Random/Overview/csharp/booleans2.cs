using System;

public class Example2
{
    public static void Main()
    {
        // <Snippet20>
        Random rnd = new Random();

        int totalTrue = 0, totalFalse = 0;

        // Generate 1,000,000 random Booleans, and keep a running total.
        for (int ctr = 0; ctr < 1000000; ctr++)
        {
            bool value = NextBoolean();
            if (value)
                totalTrue++;
            else
                totalFalse++;
        }
        Console.WriteLine("Number of true values:  {0,7:N0} ({1:P3})",
                          totalTrue,
                          ((double)totalTrue) / (totalTrue + totalFalse));
        Console.WriteLine("Number of false values: {0,7:N0} ({1:P3})",
                          totalFalse,
                          ((double)totalFalse) / (totalTrue + totalFalse));

        bool NextBoolean()
        {
            return rnd.Next(0, 2) == 1;
        }

        // The example displays output like the following:
        //       Number of true values:  499,777 (49.978 %)
        //       Number of false values: 500,223 (50.022 %)
        // </Snippet20>
    }
}
