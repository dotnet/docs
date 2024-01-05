using System;

public class Example10
{
    public static void Main()
    {
        // <Snippet15>
        Random rnd = new Random();
        for (int ctr = 1; ctr <= 15; ctr++)
        {
            Console.Write("{0,3}    ", rnd.Next(-10, 11));
            if (ctr % 5 == 0) Console.WriteLine();
        }

        // The example displays output like the following:
        //        -2     -5     -1     -2     10
        //        -3      6     -4     -8      3
        //        -7     10      5     -2      4
        // </Snippet15>
    }
}
