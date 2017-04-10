//<snippet1>
using System;
using System.Runtime.CompilerServices;

[assembly:CompilationRelaxationsAttribute(CompilationRelaxations.NoStringInterning)]

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("The CompilationRelaxationsAttribute attribute was applied.");

    }
}
//</snippet1>