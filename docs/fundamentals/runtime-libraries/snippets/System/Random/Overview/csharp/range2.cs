using System;

public class Example11
{
    public static void Main()
    {
        // <Snippet16>
        Random rnd = new Random();
        for (int ctr = 1; ctr <= 50; ctr++)
        {
            Console.Write("{0,3}    ", rnd.Next(1000, 10000));
            if (ctr % 10 == 0) Console.WriteLine();
        }

        // The example displays output like the following:
        //    9570    8979    5770    1606    3818    4735    8495    7196    7070    2313
        //    5279    6577    5104    5734    4227    3373    7376    6007    8193    5540
        //    7558    3934    3819    7392    1113    7191    6947    4963    9179    7907
        //    3391    6667    7269    1838    7317    1981    5154    7377    3297    5320
        //    9869    8694    2684    4949    2999    3019    2357    5211    9604    2593
        // </Snippet16>
    }
}
