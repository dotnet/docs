//<snippet1>
using System;
using System.Runtime.CompilerServices;

[assembly: SuppressIldasmAttribute()]
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("The SuppressIldasmAttribute is applied to this assembly.");

    }

}
//</snippet1>