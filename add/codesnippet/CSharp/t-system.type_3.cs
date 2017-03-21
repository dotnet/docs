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