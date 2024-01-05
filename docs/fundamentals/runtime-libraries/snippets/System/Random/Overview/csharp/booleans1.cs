// <Snippet8>
using System;

public class Example1
{
    public static void Main()
    {
        // Instantiate the Boolean generator.
        BooleanGenerator boolGen = new BooleanGenerator();
        int totalTrue = 0, totalFalse = 0;

        // Generate 1,0000 random Booleans, and keep a running total.
        for (int ctr = 0; ctr < 1000000; ctr++)
        {
            bool value = boolGen.NextBoolean();
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
    }
}

public class BooleanGenerator
{
    Random rnd;

    public BooleanGenerator()
    {
        rnd = new Random();
    }

    public bool NextBoolean()
    {
        return rnd.Next(0, 2) == 1;
    }
}
// The example displays output like the following:
//       Number of true values:  500,004 (50.000 %)
//       Number of false values: 499,996 (50.000 %)
// </Snippet8>
