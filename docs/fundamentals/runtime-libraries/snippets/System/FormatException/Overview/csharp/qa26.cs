using System;

public class Example7
{
    public static void Main()
    {
        // <Snippet26>
        object[] values = { 1603, 1794.68235, 15436.14 };
        string result;
        foreach (var value in values)
        {
            result = String.Format("{0,12:C2}   {0,12:E3}   {0,12:F4}   {0,12:N3}  {1,12:P2}\n",
                                   Convert.ToDouble(value), Convert.ToDouble(value) / 10000);
            Console.WriteLine(result);
        }
        // The example displays output like the following:
        //       $1,603.00     1.603E+003      1603.0000      1,603.000       16.03 %
        //    
        //       $1,794.68     1.795E+003      1794.6824      1,794.682       17.95 %
        //    
        //      $15,436.14     1.544E+004     15436.1400     15,436.140      154.36 %
        // </Snippet26>
    }
}
