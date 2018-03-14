//<Snippet2>
using System.Runtime.CompilerServices;
using System;

[assembly: InternalsVisibleTo("AssemblyB")]

// The class is internal by default.
class FriendClass
{
    public void Test()
    {
        Console.WriteLine("Sample Class");
    }
}

// Public class that has an internal method.
public class ClassWithFriendMethod
{
    internal void Test()
    {
        Console.WriteLine("Sample Method");
    }

}
//</Snippet2>

namespace CsCsrefProgrammingAssemblies
{
    //<Snippet1>
    class TestAssembly
    {
        static void Main()
        {

            try
            {
                System.Reflection.AssemblyName testAssembly =
                    System.Reflection.AssemblyName.GetAssemblyName(@"C:\Windows\Microsoft.NET\Framework\v3.5\System.Net.dll");

                System.Console.WriteLine("Yes, the file is an assembly.");
            }

            catch (System.IO.FileNotFoundException)
            {
                System.Console.WriteLine("The file cannot be found.");
            }

            catch (System.BadImageFormatException)
            {
                System.Console.WriteLine("The file is not an assembly.");
            }

            catch (System.IO.FileLoadException)
            {
                System.Console.WriteLine("The assembly has already been loaded.");
            }
        }
    }
    /* Output (with .NET Framework 3.5 installed):
        Yes, the file is an assembly.
    */
    //</Snippet1>

}