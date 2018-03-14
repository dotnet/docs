// <Snippet1>
using System;
using System.Reflection;

class Example
{
    static void Main()
    {
        // To invoke MyMethod with the default argument value, pass 
        // Missing.Value for the optional parameter.
        MethodInfo mi = typeof(MissingSample).GetMethod("MyMethod");
        mi.Invoke(null, new Object[] { Missing.Value });
    }
} 

/* This code example produces the following output:

k = 33
 */
// </Snippet1>
