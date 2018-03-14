//<Snippet1>
using System;
using System.Security;
using System.Threading;

class Test
{
    static void Main()
    {
        SecurityContext.Run(SecurityContext.Capture(), 
            new ContextCallback(Callback), "Hello world.");
    }
    static void Callback(object o)
    {
        Console.WriteLine(o);
    }
}
//</Snippet1>
