using System;
using System.Collections.Generic;
using System.Reflection;

class Example
{
    static void Main()
    {
        MethodInfo method = typeof(string).GetMethod("Copy");
        Type t = method.ReturnType.GetInterface(typeof(IEnumerable<>).Name);
        if (t != null)
            Console.WriteLine(t);
        else
            Console.WriteLine("The return type is not IEnumerable<T>.");
        /*
        Output:
        System.Collections.Generic.IEnumerable`1[System.Char]
        */
    }
}
