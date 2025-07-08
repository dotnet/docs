using System;

public class Example6
{
    public static void Main()
    {
        // <Snippet17>
        Random rnd = new Random();
        for (int ctr = 1; ctr <= 10; ctr++)
            Console.WriteLine(rnd.NextDouble() - 1);

        // The example displays output like the following:
        //       -0.930412760437658
        //       -0.164699016215605
        //       -0.9851692803135
        //       -0.43468508843085
        //       -0.177202483255976
        //       -0.776813320245972
        //       -0.0713201854710096
        //       -0.0912875561468711
        //       -0.540621722368813
        //       -0.232211863730201
        // </Snippet17>
    }
}
