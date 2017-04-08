// <Snippet1>
using System.Reflection;
using System;
public class Program {

    public static void Main() {
        Class1 c1 = new Class1();
        //  Show the current module.
        Module m = c1.GetType().Module;
        Console.WriteLine("The current module is {0}.", m.Name);

        //  List all modules in the assembly.
        Assembly curAssembly = typeof(Program).Assembly;
        Console.WriteLine("The current executing assembly is {0}.", curAssembly);

        Module[] mods = curAssembly.GetModules();
        foreach (Module md in mods) {
            Console.WriteLine("This assembly contains the {0} module", md.Name);
        }
        Console.ReadLine();
    }
}
class Class1 {
}
// </Snippet1>
