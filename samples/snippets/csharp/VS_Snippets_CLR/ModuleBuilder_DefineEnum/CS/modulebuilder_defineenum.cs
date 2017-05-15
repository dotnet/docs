// Simplified 1/17/06 GlennHa
// System.Reflection.Emit.ModuleBuilder.DefineEnum

// <Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;

class Example
{
    public static void Main()
    {
        // Get the current application domain for the current thread.
        AppDomain currentDomain = AppDomain.CurrentDomain;
      
        // Create a dynamic assembly in the current application domain, 
        // and allow it to be executed and saved to disk.
        AssemblyName aName = new AssemblyName("TempAssembly");
        AssemblyBuilder ab = currentDomain.DefineDynamicAssembly(
            aName, AssemblyBuilderAccess.RunAndSave);
      
        // Define a dynamic module in "TempAssembly" assembly. For a single-
        // module assembly, the module has the same name as the assembly.
        ModuleBuilder mb = ab.DefineDynamicModule(aName.Name, aName.Name + ".dll");
      
        // Define a public enumeration with the name "Elevation" and an 
        // underlying type of Integer.
        EnumBuilder eb = mb.DefineEnum("Elevation", TypeAttributes.Public, typeof(int));
      
        // Define two members, "High" and "Low".
        eb.DefineLiteral("Low", 0);
        eb.DefineLiteral("High", 1);

        // Create the type and save the assembly.
        Type finished = eb.CreateType();
        ab.Save(aName.Name + ".dll");

        foreach( object o in Enum.GetValues(finished) )
        {
            Console.WriteLine("{0}.{1} = {2}", finished, o, ((int) o));
        }
    }
}

/* This code example produces the following output:

Elevation.Low = 0
Elevation.High = 1 
 */
// </Snippet1>


