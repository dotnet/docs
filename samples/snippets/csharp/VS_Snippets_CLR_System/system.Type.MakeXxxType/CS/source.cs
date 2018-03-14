//<Snippet1>
using System;
using System.Reflection;

public class Example
{
    public static void Main()
    {
        // Create a Type object that represents a one-dimensional
        // array of Example objects.
        Type t = typeof(Example).MakeArrayType();
        Console.WriteLine("\r\nArray of Example: {0}", t);

        // Create a Type object that represents a two-dimensional
        // array of Example objects.
        t = typeof(Example).MakeArrayType(2);
        Console.WriteLine("\r\nTwo-dimensional array of Example: {0}", t);

        // Demonstrate an exception when an invalid array rank is
        // specified.
        try
        {
            t = typeof(Example).MakeArrayType(-1);
        }
        catch(Exception ex)
        {
            Console.WriteLine("\r\n{0}", ex);
        }

        // Create a Type object that represents a ByRef parameter
        // of type Example.
        t = typeof(Example).MakeByRefType();
        Console.WriteLine("\r\nByRef Example: {0}", t);

        // Get a Type object representing the Example class, a
        // MethodInfo representing the "Test" method, a ParameterInfo
        // representing the parameter of type Example, and finally
        // a Type object representing the type of this ByRef parameter.
        // Compare this Type object with the Type object created using
        // MakeByRefType.
        Type t2 = typeof(Example);
        MethodInfo mi = t2.GetMethod("Test");
        ParameterInfo pi = mi.GetParameters()[0];
        Type pt = pi.ParameterType;
        Console.WriteLine("Are the ByRef types equal? {0}", (t == pt));

        // Create a Type object that represents a pointer to an
        // Example object.
        t = typeof(Example).MakePointerType();
        Console.WriteLine("\r\nPointer to Example: {0}", t);
    }

    // A sample method with a ByRef parameter.
    //
    public void Test(ref Example e)
    {
    }
}

/* This example produces output similar to the following:

Array of Example: Example[]

Two-dimensional array of Example: Example[,]

System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at System.RuntimeType.MakeArrayType(Int32 rank) in c:\vbl\ndp\clr\src\BCL\System\RtType.cs:line 2999
   at Example.Main()

ByRef Example: Example&
Are the ByRef types equal? True

Pointer to Example: Example*

 */
//</Snippet1>
