// <snippet5>
// This program lists all the public constructors
// of the System.String class.
using System;
using System.Reflection;

class OtherSnippets
{
    public static void Main()
    {
         SnippetA();
         SnippetB();
    }

    public static void SnippetA()
    {
        // <snippet6>
        // Gets the mscorlib assembly in which the object is defined.
        Assembly a = typeof(object).Module.Assembly;
        // </snippet6>
    }

    public static void SnippetB()
    {
        // <snippet7>
        // Loads an assembly using its file name.
        Assembly a = Assembly.LoadFrom("MyExe.exe");
        // Gets the type names from the assembly.
        Type[] types2 = a.GetTypes();
        foreach (Type t in types2)
        {
            Console.WriteLine(t.FullName);
        }
        // </snippet7>
    }
}
// </snippet5>
