//<Snippet1>
using System;
using System.Reflection;
using System.Collections.Generic;

public class Test
{
    public static void Main()
    {
        Console.WriteLine("\r\n--- Create a constructed type from the generic Dictionary type.");

        // Create a type object representing the generic Dictionary 
        // type, by omitting the type arguments (but keeping the 
        // comma that separates them, so the compiler can infer the
        // number of type parameters).      
        Type generic = typeof(Dictionary<,>);
        DisplayTypeInfo(generic);

        // Create an array of types to substitute for the type
        // parameters of Dictionary. The key is of type string, and
        // the type to be contained in the Dictionary is Test.
        Type[] typeArgs = { typeof(string), typeof(Test) };

        // Create a Type object representing the constructed generic
        // type.
        Type constructed = generic.MakeGenericType(typeArgs);
        DisplayTypeInfo(constructed);

        // Compare the type objects obtained above to type objects
        // obtained using typeof() and GetGenericTypeDefinition().
        Console.WriteLine("\r\n--- Compare types obtained by different methods:");

        Type t = typeof(Dictionary<String, Test>);
        Console.WriteLine("\tAre the constructed types equal? {0}", t == constructed);
        Console.WriteLine("\tAre the generic types equal? {0}", 
            t.GetGenericTypeDefinition() == generic);
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

--- Create a constructed type from the generic Dictionary type.

System.Collections.Generic.Dictionary`2[TKey,TValue]
        Is this a generic type definition? True
        Is it a generic type? True
        List type arguments (2):
                TKey
                TValue

System.Collections.Generic.Dictionary`2[System.String, Test]
        Is this a generic type definition? False
        Is it a generic type? True
        List type arguments (2):
                System.String
                Test

--- Compare types obtained by different methods:
        Are the constructed types equal? True
        Are the generic types equal? True
 */
//</Snippet1>
