// <snippet1>
using System;
using System.Reflection;

[assembly:AssemblyDescriptionAttribute("My Utility")]
public class Test {

    public static void Main() 
    {
        //  Get the assembly.
        Assembly asm = Assembly.GetCallingAssembly();

        //  Verify that the description is applied.
        Type aType = typeof(AssemblyDescriptionAttribute);
        Console.WriteLine("Description applied: {0}", 
            asm.IsDefined(aType, false));
    }
}
//  The output is:
//  Description Applied: True
// </snippet1>
