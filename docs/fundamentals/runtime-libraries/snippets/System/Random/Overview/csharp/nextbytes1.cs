using System;

public class Example7
{
    public static void Main()
    {
        // <Snippet5>
        Random rnd = new Random();
        Byte[] bytes = new Byte[20];
        rnd.NextBytes(bytes);
        for (int ctr = 1; ctr <= bytes.Length; ctr++)
        {
            Console.Write("{0,3}   ", bytes[ctr - 1]);
            if (ctr % 10 == 0) Console.WriteLine();
        }

        // The example displays output like the following:
        //       141    48   189    66   134   212   211    71   161    56
        //       181   166   220   133     9   252   222    57    62    62
        // </Snippet5>
    }
}
