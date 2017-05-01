//<snippet1>
// Assembly building example in the .NET Framework.
using System;

namespace myStringer
{
    public class Stringer
    {
        public void StringerMethod()
        {
            System.Console.WriteLine("This is a line from StringerMethod.");
        }
    }
}
//</snippet1>

#if false
//<snippet2>
csc /t:module Stringer.cs
//</snippet2>
#endif
