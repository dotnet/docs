// The following code example demonstrates that Type objects are returned
// by the typeid operator, and shows how Type objects are used in reflection
// to explore information about types and to invoke members of types.
//<Snippet1>
using System;
using System.Reflection;

class Example
{
    static void Main()
    {
        Type t = typeof(String);

        MethodInfo substr = t.GetMethod("Substring", 
            new Type[] { typeof(int), typeof(int) });

        Object result = 
            substr.Invoke("Hello, World!", new Object[] { 7, 5 });
        Console.WriteLine("{0} returned \"{1}\".", substr, result);
    }
}

/* This code example produces the following output:

System.String Substring(Int32, Int32) returned "World".
 */
//</Snippet1>
