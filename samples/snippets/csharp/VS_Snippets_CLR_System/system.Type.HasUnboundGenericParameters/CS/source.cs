//<Snippet1>
using System;
using System.Reflection;
using System.Collections.Generic;

// Define a base class with two type parameters.
public class Base<T, U> { }

// Define a derived class. The derived class inherits from a constructed
// class that meets the following criteria:
//   (1) Its generic type definition is Base<T, U>.
//   (2) It specifies int for the first type parameter.
//   (3) For the second type parameter, it uses the same type that is used
//       for the type parameter of the derived class.
// Thus, the derived class is a generic type with one type parameter, but
// its base class is an open constructed type with one type argument and
// one type parameter.
public class Derived<V> : Base<int, V> { }

public class Test
{
    public static void Main()
    {
        Console.WriteLine(
            "\r\n--- Display a generic type and the open constructed");
        Console.WriteLine("    type from which it is derived.");

        // Create a Type object representing the generic type definition 
        // for the Derived type, by omitting the type argument. (For
        // types with multiple type parameters, supply the commas but
        // omit the type arguments.) 
        //
        Type derivedType = typeof(Derived<>);
        DisplayGenericTypeInfo(derivedType);

        // Display its open constructed base type.
        DisplayGenericTypeInfo(derivedType.BaseType);
    }

    private static void DisplayGenericTypeInfo(Type t)
    {
        Console.WriteLine("\r\n{0}", t);

        Console.WriteLine("\tIs this a generic type definition? {0}", 
            t.IsGenericTypeDefinition);

        Console.WriteLine("\tIs it a generic type? {0}", 
            t.IsGenericType);

        Console.WriteLine("\tDoes it have unassigned generic parameters? {0}", 
            t.ContainsGenericParameters);

        if (t.IsGenericType)
        {
            // If this is a generic type, display the type arguments.
            //
            Type[] typeArguments = t.GetGenericArguments();

            Console.WriteLine("\tList type arguments ({0}):", 
                typeArguments.Length);

            foreach (Type tParam in typeArguments)
            {
                // IsGenericParameter is true only for generic type
                // parameters.
                //
                if (tParam.IsGenericParameter)
                {
                    Console.WriteLine(
                        "\t\t{0}  (unassigned - parameter position {1})",
                        tParam,
                        tParam.GenericParameterPosition);
                }
                else
                {
                    Console.WriteLine("\t\t{0}", tParam);
                }
            }
        }
    }
}

/* This example produces the following output:

--- Display a generic type and the open constructed
    type from which it is derived.

Derived`1[V]
        Is this a generic type definition? True
        Is it a generic type? True
        Does it have unassigned generic parameters? True
        List type arguments (1):
                V  (unassigned - parameter position 0)

Base`2[System.Int32,V]
        Is this a generic type definition? False
        Is it a generic type? True
        Does it have unassigned generic parameters? True
        List type arguments (2):
                System.Int32
                V  (unassigned - parameter position 0)
 */
//</Snippet1>
