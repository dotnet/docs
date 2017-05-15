//<snippet1>
using System;
using System.Runtime.CompilerServices;


class Program
{

    static void Main(string[] args)
    {

        int x = 1; int y = 1;

        bool ret = RuntimeHelpers.Equals(x, y);

        Console.WriteLine("The return value of RuntimeHelpers.Equals is: " + ret);

    }
}
//</snippet1>