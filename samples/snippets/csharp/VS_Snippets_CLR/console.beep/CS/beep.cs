//<snippet1>
// This example demonstrates the Console.Beep() method.
using System;

class Sample 
{
    public static void Main(String[] args) 
    {
    int x = 0;
//
    if ((args.Length == 1) &&
        (Int32.TryParse(args[0], out x) == true) &&
        ((x >= 1) && (x <= 9)))
        {
        for (int i = 1; i <= x; i++)
            {
            Console.WriteLine("Beep number {0}.", i);
            Console.Beep();
            }
        }
    else
        Console.WriteLine("Usage: Enter the number of times (between 1 and 9) to beep.");
    }
}
/*
This example produces the following results:

>beep
Usage: Enter the number of times (between 1 and 9) to beep

>beep 9
Beep number 1.
Beep number 2.
Beep number 3.
Beep number 4.
Beep number 5.
Beep number 6.
Beep number 7.
Beep number 8.
Beep number 9.

*/
//</snippet1>