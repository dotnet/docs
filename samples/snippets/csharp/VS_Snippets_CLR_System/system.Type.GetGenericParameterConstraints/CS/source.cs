//<Snippet1>
using System;
using System.Reflection;

// Define a sample interface to use as an interface constraint.
public interface ITest {}

// Define a base type to use as a base class constraint.
public class Base {}

// Define the generic type to examine. The first generic type parameter,
// T, derives from the class Base and implements ITest. This demonstrates
// a base class constraint and an interface constraint. The second generic 
// type parameter, U, must be a reference type (class) and must have a 
// default constructor (new()). This demonstrates special constraints.
//
public class Test<T,U> 
    where T : Base, ITest 
    where U : class, new() {}

// Define a type that derives from Base and implements ITest. This type
// satisfies the constraints on T in class Test.
public class Derived : Base, ITest {}

public class Example
{
    public static void Main()
    {
        // To get the generic type definition, omit the type
        // arguments but retain the comma to indicate the number
        // of type arguments. 
        //
        Type def = typeof(Test<,>);
        Console.WriteLine("\r\nExamining generic type {0}", def);

        // Get the type parameters of the generic type definition,
        // and display them.
        //
        Type[] defparams = def.GetGenericArguments();
        foreach (Type tp in defparams)
        {
            Console.WriteLine("\r\nType parameter: {0}", tp.Name);
            Console.WriteLine("\t{0}", 
                ListGenericParameterAttributes(tp));

            // List the base class and interface constraints. The
            // constraints are returned in no particular order. If 
            // there are no class or interface constraints, an empty
            // array is returned.
            //
            Type[] tpConstraints = tp.GetGenericParameterConstraints();
            foreach (Type tpc in tpConstraints)
            {
                Console.WriteLine("\t{0}", tpc);
            }
        }
    }

    // List the variance and special constraint flags. 
    //
    private static string ListGenericParameterAttributes(Type t)
    {
        string retval;
        GenericParameterAttributes gpa = t.GenericParameterAttributes;
        GenericParameterAttributes variance = gpa & 
            GenericParameterAttributes.VarianceMask;

        // Select the variance flags.
        if (variance == GenericParameterAttributes.None)
            retval = "No variance flag;";
        else
        {
            if ((variance & GenericParameterAttributes.Covariant) != 0)
                retval = "Covariant;";
            else
                retval = "Contravariant;";
        }

        // Select 
        GenericParameterAttributes constraints = gpa & 
            GenericParameterAttributes.SpecialConstraintMask;

        if (constraints == GenericParameterAttributes.None)
            retval += " No special constraints";
        else
        {
            if ((constraints & GenericParameterAttributes.ReferenceTypeConstraint) != 0)
                retval += " ReferenceTypeConstraint";
            if ((constraints & GenericParameterAttributes.NotNullableValueTypeConstraint) != 0)
                retval += " NotNullableValueTypeConstraint";
            if ((constraints & GenericParameterAttributes.DefaultConstructorConstraint) != 0)
                retval += " DefaultConstructorConstraint";
        }

        return retval;
    }
}
/* This example produces the following output:

Examining generic type Test`2[T,U]

Type parameter: T
        No variance flag; no special constraints.
        Base
        ITest

Type parameter: U
        No variance flag; ReferenceTypeConstraint DefaultConstructorConstraint
 */
//</Snippet1>
