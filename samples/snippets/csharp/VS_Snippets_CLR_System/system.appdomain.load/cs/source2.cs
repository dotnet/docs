//<snippet2>
using System;
using System.Reflection;

public class Asmload0
{
    public static void Main()
    {
        // Use the file name to load the assembly into the current
        // application domain.
        Assembly a = Assembly.Load("example");
        // Get the type to use.
        Type myType = a.GetType("Example");
        // Get the method to call.
        MethodInfo myMethod = myType.GetMethod("MethodA");
        // Create an instance.
        object obj = Activator.CreateInstance(myType);
        // Execute the method.
        myMethod.Invoke(obj, null);
    }
}
//</snippet2>
