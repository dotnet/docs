// <Snippet7>
using System;

public class Dice
{
    Random rnd = new Random();
    public Dice()
    {

    }
    public int Roll()
    {
        return rnd.Next(1, 7); 
    }
}

class Program
{
    static void Main(string[] args)
    {
        var d1 = new Dice();
        ShowValue(d1);
    }

    private static void ShowValue(object o)
    {
        const int HIGH_ROLL = 6;

        if (o is Dice d && d.Roll() is HIGH_ROLL)
            Console.WriteLine($"The value is {HIGH_ROLL}!");
        else
            Console.WriteLine($"The dice roll is not a {HIGH_ROLL}!");
     }
}
// The example displays output like the following:
//      The value is 6!
// </Snippet7>

