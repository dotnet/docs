//<snippet1>
using System;
using System.Runtime.CompilerServices;

[assembly: DependencyAttribute("AssemblyA", LoadHint.Always)]
[assembly: DependencyAttribute("AssemblyB", LoadHint.Sometimes)]

class Program
{
    
    static void Main(string[] args)
    {

        Console.WriteLine("The DependencyAttribute attribute was applied.");

    }
}
//</snippet1>