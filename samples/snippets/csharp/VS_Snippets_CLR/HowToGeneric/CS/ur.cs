// Example code for How to: Discover and Manipulate Generic Types
//<Snippet1>
using System;
using System.Reflection;
using System.Collections.Generic;

// Define an example interface.
public interface ITestArgument {}

// Define an example base class.
public class TestBase {}

// Define a generic class with one parameter. The parameter
// has three constraints: It must inherit TestBase, it must
// implement ITestArgument, and it must have a parameterless
// constructor.
public class Test<T> where T : TestBase, ITestArgument, new() {}

// Define a class that meets the constraints on the type
// parameter of class Test.
public class TestArgument : TestBase, ITestArgument
{
    public TestArgument() {}
}

public class Example
{
    // The following method displays information about a generic
    // type.
    private static void DisplayGenericType(Type t)
    {
        Console.WriteLine("\r\n {0}", t);
        //<Snippet3>
        Console.WriteLine("   Is this a generic type? {0}",
            t.IsGenericType);
        Console.WriteLine("   Is this a generic type definition? {0}",
            t.IsGenericTypeDefinition);
        //</Snippet3>

        // Get the generic type parameters or type arguments.
        //<Snippet4>
        Type[] typeParameters = t.GetGenericArguments();
        //</Snippet4>

        //<Snippet5>
        Console.WriteLine("   List {0} type arguments:",
            typeParameters.Length);
        foreach( Type tParam in typeParameters )
        {
            if (tParam.IsGenericParameter)
            {
                DisplayGenericParameter(tParam);
            }
            else
            {
                Console.WriteLine("      Type argument: {0}",
                    tParam);
            }
        }
        //</Snippet5>
    }

    // The following method displays information about a generic
    // type parameter. Generic type parameters are represented by
    // instances of System.Type, just like ordinary types.
    //<Snippet6>
    private static void DisplayGenericParameter(Type tp)
    {
        Console.WriteLine("      Type parameter: {0} position {1}",
            tp.Name, tp.GenericParameterPosition);
        //</Snippet6>

        //<Snippet7>
        Type classConstraint = null;

        foreach(Type iConstraint in tp.GetGenericParameterConstraints())
        {
            if (iConstraint.IsInterface)
            {
                Console.WriteLine("         Interface constraint: {0}",
                    iConstraint);
            }
        }

        if (classConstraint != null)
        {
            Console.WriteLine("         Base type constraint: {0}",
                tp.BaseType);
        }
        else
        {
            Console.WriteLine("         Base type constraint: None");
        }
        //</Snippet7>

        //<Snippet8>
        GenericParameterAttributes sConstraints =
            tp.GenericParameterAttributes &
            GenericParameterAttributes.SpecialConstraintMask;
        //</Snippet8>

        //<Snippet9>
        if (sConstraints == GenericParameterAttributes.None)
        {
            Console.WriteLine("         No special constraints.");
        }
        else
        {
            if (GenericParameterAttributes.None != (sConstraints &
                GenericParameterAttributes.DefaultConstructorConstraint))
            {
                Console.WriteLine("         Must have a parameterless constructor.");
            }
            if (GenericParameterAttributes.None != (sConstraints &
                GenericParameterAttributes.ReferenceTypeConstraint))
            {
                Console.WriteLine("         Must be a reference type.");
            }
            if (GenericParameterAttributes.None != (sConstraints &
                GenericParameterAttributes.NotNullableValueTypeConstraint))
            {
                Console.WriteLine("         Must be a non-nullable value type.");
            }
        }
        //</Snippet9>
    }

    public static void Main()
    {
        // Two ways to get a Type object that represents the generic
        // type definition of the Dictionary class.
        //
        //<Snippet10>
        // Use the typeof operator to create the generic type
        // definition directly. To specify the generic type definition,
        // omit the type arguments but retain the comma that separates
        // them.
        //<Snippet2>
        Type d1 = typeof(Dictionary<,>);
        //</Snippet2>

        // You can also obtain the generic type definition from a
        // constructed class. In this case, the constructed class
        // is a dictionary of Example objects, with String keys.
        Dictionary<string, Example> d2 = new Dictionary<string, Example>();
        // Get a Type object that represents the constructed type,
        // and from that get the generic type definition. The
        // variables d1 and d4 contain the same type.
        Type d3 = d2.GetType();
        Type d4 = d3.GetGenericTypeDefinition();
        //</Snippet10>

        // Display information for the generic type definition, and
        // for the constructed type Dictionary<String, Example>.
        DisplayGenericType(d1);
        DisplayGenericType(d2.GetType());

        // Construct an array of type arguments to substitute for
        // the type parameters of the generic Dictionary class.
        // The array must contain the correct number of types, in
        // the same order that they appear in the type parameter
        // list of Dictionary. The key (first type parameter)
        // is of type string, and the type to be contained in the
        // dictionary is Example.
        //<Snippet11>
        Type[] typeArgs = {typeof(string), typeof(Example)};
        //</Snippet11>

        // Construct the type Dictionary<String, Example>.
        //<Snippet12>
        Type constructed = d1.MakeGenericType(typeArgs);
        //</Snippet12>

        DisplayGenericType(constructed);

        //<Snippet13>
        object o = Activator.CreateInstance(constructed);
        //</Snippet13>

        Console.WriteLine("\r\nCompare types obtained by different methods:");
        Console.WriteLine("   Are the constructed types equal? {0}",
            (d2.GetType()==constructed));
        Console.WriteLine("   Are the generic definitions equal? {0}",
            (d1==constructed.GetGenericTypeDefinition()));

        // Demonstrate the DisplayGenericType and
        // DisplayGenericParameter methods with the Test class
        // defined above. This shows base, interface, and special
        // constraints.
        DisplayGenericType(typeof(Test<>));
    }
}
//</Snippet1>
