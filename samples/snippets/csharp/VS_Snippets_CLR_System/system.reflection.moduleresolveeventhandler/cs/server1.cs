//<Snippet2>
// Server1 module

using System;
using System.Reflection;

public class Server1 : MarshalByRefObject
{
    public int trivial()
    {
        Console.WriteLine();
        Console.WriteLine("******************************************************");
        Console.WriteLine("*   Server1.trivial() in module: {0:s}   *", this.GetType().Module.ScopeName);
        Console.WriteLine("******************************************************");
        Console.WriteLine("Returning from Server1.trivial...");
        return 1;
    }
}
//</Snippet2>
