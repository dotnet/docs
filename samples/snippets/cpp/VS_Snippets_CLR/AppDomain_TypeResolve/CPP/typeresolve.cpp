// REDMOND\glennha
// VSWhidbey 445288
// <Snippet1>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

ref class Test
{
private:
    static Assembly^ HandleTypeResolve(Object^ sender, ResolveEventArgs^ args) 
    {
        Console::WriteLine("TypeResolve event handler.");

        // Save the dynamic assembly, and then load it using its
        // display name. Return the loaded assembly.
        //
        ab->Save(moduleName);
        return Assembly::Load(ab->FullName); 
    }

    // For this code example, the following information needs to be
    // available to both Demo and the HandleTypeResolve event
    // handler:
    static AssemblyBuilder^ ab;
    static String^ moduleName;

public:
    static void Demo() 
    {
        AppDomain^ currDom = AppDomain::CurrentDomain;

        // Create a dynamic assembly with one module, to be saved to 
        // disk (AssemblyBuilderAccess::Save).
        // 
        AssemblyName^ aName = gcnew AssemblyName();
        aName->Name = "Transient";
        moduleName = aName->Name + ".dll";
        ab = currDom->DefineDynamicAssembly(aName,
            AssemblyBuilderAccess::Save);
        ModuleBuilder^ mb = ab->DefineDynamicModule(aName->Name, moduleName);

        // The dynamic assembly has just one dummy type, to demonstrate
        // type resolution.
        TypeBuilder^ tb = mb->DefineType("Example");
        tb->CreateType();


        // First, try to load the type without saving the dynamic 
        // assembly and without hooking up the TypeResolve event. The
        // type cannot be loaded.
        try
        {
            Type^ temp = Type::GetType("Example", true);
            Console::WriteLine("Loaded type {0}.", temp);
        }
        catch (TypeLoadException^)
        {
            Console::WriteLine("Loader could not resolve the type.");
        }

        // Hook up the TypeResolve event.
        //      
        currDom->TypeResolve += 
            gcnew ResolveEventHandler(HandleTypeResolve);

        // Now try to load the type again. The TypeResolve event is 
        // raised, the dynamic assembly is saved, and the dummy type is
        // loaded successfully. Display it to the console, and create
        // an instance.
        Type^ t = Type::GetType("Example", true);
        Console::WriteLine("Loaded type \"{0}\".", t);
        Object^ o = Activator::CreateInstance(t);
    }
};

void main()
{
    Test::Demo();
}

/* This code example produces the following output:

Loader could not resolve the type.
TypeResolve event handler.
Loaded type "Example".
 */
// </Snippet1>
