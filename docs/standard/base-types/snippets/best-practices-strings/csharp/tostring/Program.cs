using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // <Snippet1>
        string concat1 = "The amount is " + 126.03 + ".";
        Console.WriteLine(concat1);
        // </Snippet1>

        // <Snippet2>
        string concat2 = "The amount is " + 126.03.ToString(CultureInfo.InvariantCulture) + ".";
        Console.WriteLine(concat2);
        // </Snippet2>
    }
}
