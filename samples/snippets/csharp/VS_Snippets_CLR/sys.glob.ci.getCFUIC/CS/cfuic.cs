//<snippet1>
// This example demonstrates the GetConsoleFallbackUICulture() method
using System;
using System.Globalization;

class Sample 
{
    public static void Main() 
    {
    CultureInfo ci = new CultureInfo("ar-DZ");
    Console.WriteLine("Culture name: . . . . . . . . . {0}", ci.Name);
    Console.WriteLine("Console fallback UI culture:. . {0}",
                       ci.GetConsoleFallbackUICulture().Name);
    }
}
/*
This code example produces the following results:

Culture name: . . . . . . . . . ar-DZ
Console fallback UI culture:. . fr-FR

*/
//</snippet1>