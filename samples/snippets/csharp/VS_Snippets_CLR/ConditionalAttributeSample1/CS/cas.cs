//<snippet7>
#define CONDITION1
#define CONDITION2
using System;
using System.Diagnostics;

class Test
{
    static void Main()
    {               
        Console.WriteLine("Calling Method1");
        Method1(3);
        Console.WriteLine("Calling Method2");
        Method2();
        
        Console.WriteLine("Using the Debug class");
        Debug.Listeners.Add(new ConsoleTraceListener());
        Debug.WriteLine("DEBUG is defined");
    }
    
    //<snippet8>
    [Conditional("CONDITION1")]
    public static void Method1(int x)
    {
        Console.WriteLine("CONDITION1 is defined");
    }
    
    [Conditional("CONDITION1"), Conditional("CONDITION2")]  
    public static void Method2()
    {
        Console.WriteLine("CONDITION1 or CONDITION2 is defined");
    }
    //</snippet8>
}

/*
When compiled as shown, the application (named ConsoleApp) 
produces the following output.

Calling Method1
CONDITION1 is defined
Calling Method2
CONDITION1 or CONDITION2 is defined
Using the Debug class
DEBUG is defined
*/
//</snippet7>
