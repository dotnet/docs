//<snippet3>
using System;
using myStringer;

class MainClientApp
{
    // Static method Main is the entry point method.
    public static void Main()
    {
        Stringer myStringInstance = new Stringer();
        Console.WriteLine("Client code executes");
        myStringInstance.StringerMethod();
    }
}
//</snippet3>

#if false
//<snippet4>
csc /addmodule:Stringer.netmodule /t:module Client.cs
//</snippet4>

//<snippet5>
csc /t:module Stringer.cs
csc Client.cs /addmodule:Stringer.netmodule
//</snippet5>

//<snippet6>
csc /out:Client.exe Client.cs /out:Stringer.netmodule Stringer.cs
//</snippet6>
#endif
