using System;

public class Example9
{
    public static void Main()
    {
        // <Snippet6>
        Random rnd = new Random();
        for (int ctr = 0; ctr < 10; ctr++)
        {
            Console.Write("{0,3}   ", rnd.Next(-10, 11));
        }

        // The example displays output like the following:
        //    2     9    -3     2     4    -7    -3    -8    -8     5
        // </Snippet6>
    }
}
