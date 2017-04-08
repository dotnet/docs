//<snippet1>
using System;
using System.Runtime.CompilerServices;

[assembly :StringFreezingAttribute()]

class Program
{
    
    string frozenString = "This is a frozen string after Ngen is run.";
    
    static void Main(string[] args)
    {

        Console.WriteLine("The StringFreezingAttribute attribute was applied.");

    }
}
//</snippet1>