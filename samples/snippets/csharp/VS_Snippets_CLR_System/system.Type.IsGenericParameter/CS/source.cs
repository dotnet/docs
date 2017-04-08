//<Snippet1>
using System;
using System.Reflection;
using System.Collections.Generic;

public class Test
{
    private static void DisplayGenericTypeInfo(Type t)
    {
        Console.WriteLine("\r\n{0}", t);

        Console.WriteLine("\tIs this a generic type definition? {0}", 
            t.IsGenericTypeDefinition);

        Console.WriteLine("\tIs it a generic type? {0}", 
            t.IsGenericType);

        //<Snippet2>
        if (t.IsGenericType)
        {
            // If this is a generic type, display the type arguments.
            //
            Type[] typeArguments = t.GetGenericArguments();

            Console.WriteLine("\tList type arguments ({0}):", 
                typeArguments.Length);

            foreach (Type tParam in typeArguments)
            {
                // If this is a type parameter, display its
                // position.
                //
                if (tParam.IsGenericParameter)
                {
                    Console.WriteLine("\t\t{0}\t(unassigned - parameter position {1})",
                        tParam,
                        tParam.GenericParameterPosition);
                }
                else
                {
                    Console.WriteLine("\t\t{0}", tParam);
                }
            }
        }
        //</Snippet2>
    }

    public static void Main()
    {
        Console.WriteLine("\r\n--- Display information about a constructed type, its");
        Console.WriteLine("    generic type definition, and an ordinary type.");

        // Create a Dictionary of Test objects, using strings for the
        // keys.       
        Dictionary<string, Test> d = new Dictionary<string, Test>();

        // Display information for the constructed type and its generic
        // type definition.
        DisplayGenericTypeInfo(d.GetType());
        DisplayGenericTypeInfo(d.GetType().GetGenericTypeDefinition());

        // Display information for an ordinary type.
        DisplayGenericTypeInfo(typeof(string));
    }
}

/* This example produces the following output:

--- Display information about a constructed type, its
    generic type definition, and an ordinary type.

System.Collections.Generic.Dictionary[System.String,Test]
        Is this a generic type definition? False
        Is it a generic type? True
        List type arguments (2):
                System.String
                Test

System.Collections.Generic.Dictionary[TKey,TValue]
        Is this a generic type definition? True
        Is it a generic type? True
        List type arguments (2):
                TKey    (unassigned - parameter position 0)
                TValue  (unassigned - parameter position 1)

System.String
        Is this a generic type definition? False
        Is it a generic type? False
 */
//</Snippet1>
