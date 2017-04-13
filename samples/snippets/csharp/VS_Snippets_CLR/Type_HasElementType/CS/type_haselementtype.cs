// <Snippet1>
// This code must be compiled with the /unsafe switch:
//   csc /unsafe source.cs
using System;
using System.Reflection;

public class Example
{
    // This method is for demonstration purposes.
    unsafe public void Test(ref int x, out int y, int* z) 
    { 
        *z = x = y = 0; 
    }

    public static void Main()
    {
        // All of the following display 'True'.

        // Define an array, get its type, and display HasElementType. 
        int[] nums = {1, 1, 2, 3, 5, 8, 13};
        Type t = nums.GetType();
        Console.WriteLine("HasElementType is '{0}' for array types.", t.HasElementType);

        // Test an array type without defining an array.
        t = typeof(Example[]);
        Console.WriteLine("HasElementType is '{0}' for array types.", t.HasElementType);

        // When you use Reflection Emit to emit dynamic methods and
        // assemblies, you can create array types using MakeArrayType.
        // The following creates the type 'array of Example'.
        t = typeof(Example).MakeArrayType();
        Console.WriteLine("HasElementType is '{0}' for array types.", t.HasElementType);

        // When you reflect over methods, HasElementType is true for
        // ref, out, and pointer parameter types. The following 
        // gets the Test method, defined above, and examines its
        // parameters.
        MethodInfo mi = typeof(Example).GetMethod("Test");
        ParameterInfo[] parms = mi.GetParameters();
        t = parms[0].ParameterType;
        Console.WriteLine("HasElementType is '{0}' for ref parameter types.", t.HasElementType);
        t = parms[1].ParameterType;
        Console.WriteLine("HasElementType is '{0}' for out parameter types.", t.HasElementType);
        t = parms[2].ParameterType;
        Console.WriteLine("HasElementType is '{0}' for pointer parameter types.", t.HasElementType);

        // When you use Reflection Emit to emit dynamic methods and
        // assemblies, you can create pointer and ByRef types to use
        // when you define method parameters.
        t = typeof(Example).MakePointerType();
        Console.WriteLine("HasElementType is '{0}' for pointer types.", t.HasElementType);
        t = typeof(Example).MakeByRefType();
        Console.WriteLine("HasElementType is '{0}' for ByRef types.", t.HasElementType);
    }
}
// </Snippet1>