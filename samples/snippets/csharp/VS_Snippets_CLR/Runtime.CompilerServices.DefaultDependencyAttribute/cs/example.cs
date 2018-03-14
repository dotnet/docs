//<snippet1>
using System;
using System.Runtime.CompilerServices;

[assembly: DefaultDependencyAttribute(LoadHint.Always)]
class Program
{
    
    static void Main(string[] args)
    {

        Console.WriteLine("The DefaultDependencyAttribute attribute was applied.");

    }
}
//</snippet1>