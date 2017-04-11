
using System;
using System.Reflection;

class ParmInfoTest
{
    public static void Main()
    {
        object obj = new ParmInfoTest();

        // <Snippet1>
        // Create an array containing the arguments.
        object[] args = {"Argument 1", "Argument 2", "Argument 3" };

        // Initialize a ParameterModifier with the number of parameters.
        ParameterModifier p = new ParameterModifier(3);

        // Pass the first and third parameters by reference.
        p[0] = true;
        p[2] = true;

        // The ParameterModifier must be passed as the single element
        // of an array.
        ParameterModifier[] mods = { p };

        // Invoke the method late bound.
        obj.GetType().InvokeMember("MethodName", BindingFlags.InvokeMethod,
             null, obj, args, mods, null, null);
        // </Snippet1>
    }

    public void MethodName(ref string str1, string str2, ref string str3)
    {
        Console.WriteLine("Called 'MethodName'");
    }
}





