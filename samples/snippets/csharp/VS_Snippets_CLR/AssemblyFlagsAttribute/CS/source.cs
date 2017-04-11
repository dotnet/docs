//<Snippet1>
using System;
using System.Reflection;

// Specify a combination of AssemblyNameFlags for this 
// assembly.
[assembly:AssemblyFlagsAttribute(
    AssemblyNameFlags.EnableJITcompileOptimizer |
    AssemblyNameFlags.Retargetable)]

public class Example
{
    public static void Main()
    {
        // Get this assembly.
        Assembly thisAsm = typeof(Example).Assembly;

        // Get the AssemblyName for this assembly.
        AssemblyName thisAsmName = thisAsm.GetName(false);

        // Display the flags that were set for this assembly.
        ListFlags(thisAsmName.Flags);

        // Create an instance of AssemblyFlagsAttribute with the
        // same combination of flags that was specified for this
        // assembly. Note that PublicKey is included automatically
        // for the assembly, but not for this instance of
        // AssemblyFlagsAttribute.
        AssemblyFlagsAttribute afa = new AssemblyFlagsAttribute(
            AssemblyNameFlags.EnableJITcompileOptimizer |
            AssemblyNameFlags.Retargetable);

        // Get the flags. The property returns an integer, so
        // the return value must be cast to AssemblyNameFlags.
        AssemblyNameFlags anf = (AssemblyNameFlags) afa.AssemblyFlags;

        // Display the flags.
        Console.WriteLine();
        ListFlags(anf);
    }

    private static void ListFlags(AssemblyNameFlags anf)
    {
        if (anf == AssemblyNameFlags.None)
        {
            Console.WriteLine("AssemblyNameFlags.None");
        }
        else
        {
            if (0!=(anf & AssemblyNameFlags.Retargetable)) 
                Console.WriteLine("AssemblyNameFlags.Retargetable");
            if (0!=(anf & AssemblyNameFlags.PublicKey)) 
                Console.WriteLine("AssemblyNameFlags.PublicKey");
            if (0!=(anf & AssemblyNameFlags.EnableJITcompileOptimizer)) 
                Console.WriteLine("AssemblyNameFlags.EnableJITcompileOptimizer");
            if (0!=(anf & AssemblyNameFlags.EnableJITcompileTracking)) 
                Console.WriteLine("AssemblyNameFlags.EnableJITcompileTracking");
        }
    }
}

/* This code example produces the following output:

AssemblyNameFlags.Retargetable
AssemblyNameFlags.PublicKey
AssemblyNameFlags.EnableJITcompileOptimizer

AssemblyNameFlags.Retargetable
AssemblyNameFlags.EnableJITcompileOptimizer
*/
//</Snippet1>


