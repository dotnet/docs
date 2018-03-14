// REDMOND\glennha
// VSWhidbey 445288
// <Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;

class Test 
{
    // For this code example, the following information needs to be
    // available to both Main and the HandleTypeResolve event
    // handler:
    private static AssemblyBuilder ab;
    private static string moduleName;

    public static void Main() 
    {
        AppDomain currDom = AppDomain.CurrentDomain;

        // Create a dynamic assembly with one module, to be saved to 
        // disk (AssemblyBuilderAccess.Save).
        // 
        AssemblyName aName = new AssemblyName();
        aName.Name = "Transient";
        moduleName = aName.Name + ".dll";
        ab = currDom.DefineDynamicAssembly(aName,
            AssemblyBuilderAccess.Save);
        ModuleBuilder mb = ab.DefineDynamicModule(aName.Name, moduleName);

        // The dynamic assembly has just one dummy type, to demonstrate
        // type resolution.
        TypeBuilder tb = mb.DefineType("Example");
        tb.CreateType();


        // First, try to load the type without saving the dynamic 
        // assembly and without hooking up the TypeResolve event. The
        // type cannot be loaded.
        try
        {
            Type temp = Type.GetType("Example", true);
            Console.WriteLine("Loaded type {0}.", temp);
        }
        catch (TypeLoadException)
        {
            Console.WriteLine("Loader could not resolve the type.");
        }

        // Hook up the TypeResolve event.
        //      
        currDom.TypeResolve += 
            new ResolveEventHandler(HandleTypeResolve);

        // Now try to load the type again. The TypeResolve event is 
        // raised, the dynamic assembly is saved, and the dummy type is
        // loaded successfully. Display it to the console, and create
        // an instance.
        Type t = Type.GetType("Example", true);
        Console.WriteLine("Loaded type \"{0}\".", t);
        Object o = Activator.CreateInstance(t);
    }

    static Assembly HandleTypeResolve(object sender, ResolveEventArgs args) 
    {
        Console.WriteLine("TypeResolve event handler.");

        // Save the dynamic assembly, and then load it using its
        // display name. Return the loaded assembly.
        //
        ab.Save(moduleName);
        return Assembly.Load(ab.FullName); 
    }
}

/* This code example produces the following output:

Loader could not resolve the type.
TypeResolve event handler.
Loaded type "Example".
 */
// </Snippet1>