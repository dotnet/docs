//<Snippet1>
using System;
using System.Reflection;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {
        Console.WriteLine("\r\n--- Get the generic type that defines a constructed type.");

        // Create a Dictionary of Test objects, using strings for the
        // keys.       
        Dictionary<string, Test> d = new Dictionary<string, Test>();

        // Get a Type object representing the constructed type.
        //
        Type constructed = d.GetType();
        DisplayTypeInfo(constructed);

        Type generic = constructed.GetGenericTypeDefinition();
        DisplayTypeInfo(generic);
    }

    private static void DisplayTypeInfo(Type t)
    {
        Console.WriteLine("\r\n{0}", t);
        Console.WriteLine("\tIs this a generic type definition? {0}", 
            t.IsGenericTypeDefinition);
        Console.WriteLine("\tIs it a generic type? {0}", 
            t.IsGenericType);
        Type[] typeArguments = t.GetGenericArguments();
        Console.WriteLine("\tList type arguments ({0}):", typeArguments.Length);
        foreach (Type tParam in typeArguments)
        {
            Console.WriteLine("\t\t{0}", tParam);
        }
    }
}

/* This example produces the following output:

--- Get the generic type that defines a constructed type.

System.Collections.Generic.Dictionary`2[System.String,Test]
        Is this a generic type definition? False
        Is it a generic type? True
        List type arguments (2):
                System.String
                Test

System.Collections.Generic.Dictionary`2[TKey,TValue]
        Is this a generic type definition? True
        Is it a generic type? True
        List type arguments (2):
                TKey
                TValue
 */
//</Snippet1>
