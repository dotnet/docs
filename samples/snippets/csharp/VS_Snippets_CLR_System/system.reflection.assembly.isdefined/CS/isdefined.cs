// <snippet1>
using System;
using System.Reflection;

// Set an assembly attribute.
[assembly:AssemblyTitleAttribute("A title example")]


// Note that the suffix "Attribute" can be omitted:
// [assembly:AssemblyTitle("A title example")]


public class Test {

    public static void Main() {

        // Get the assembly that is executing this method.
        Assembly asm = Assembly.GetCallingAssembly();

        // Get the attribute type just defined.
        Type aType = typeof(AssemblyTitleAttribute);
        Console.WriteLine(asm.IsDefined(aType, false));

        // Try an attribute not defined.
        aType = typeof(AssemblyVersionAttribute);
        Console.WriteLine(asm.IsDefined(aType, false));
    }
}
//
//  This code example produces the following output:
//  True
//  False
//
// </snippet1>
