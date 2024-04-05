using System;

public class Example8
{
    public static void Main()
    {
        // <Snippet7>
        Random rnd = new Random();
        for (int ctr = 0; ctr < 10; ctr++)
        {
            Console.Write("{0,-19:R}   ", rnd.NextDouble());
            if ((ctr + 1) % 3 == 0) Console.WriteLine();
        }

        // The example displays output like the following:
        //    0.7911680553998649    0.0903414949264105    0.79776258291572455
        //    0.615568345233597     0.652644504165577     0.84023809378977776
        //    0.099662564741290441   0.91341467383942321  0.96018602045261581
        //    0.74772306473354022
        // </Snippet7>
    }
}
