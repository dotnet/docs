// GlennHa 1/23/06
//<Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Security::Permissions;

[assembly:AssemblyVersionAttribute("1.0.2000.0")];

public ref class Example
{
private: 
    int factor;

public:
    Example(int f)
    {
        factor = f;
    }

    int SampleMethod(int x) 
    { 
        Console::WriteLine("\nExample->SampleMethod({0}) executes.", x);
        return x * factor;
    }
};

void main()
{
    Assembly^ assem = Example::typeid->Assembly;

    Console::WriteLine("Assembly Full Name:");
    Console::WriteLine(assem->FullName);

    // The AssemblyName type can be used to parse the full name.
    AssemblyName^ assemName = assem->GetName();
    Console::WriteLine("\nName: {0}", assemName->Name);
    Console::WriteLine("Version: {0}.{1}", 
        assemName->Version->Major, assemName->Version->Minor);

    Console::WriteLine("\nAssembly CodeBase:");
    Console::WriteLine(assem->CodeBase);

    // Create an object from the assembly, passing in the correct number and
    // type of arguments for the constructor.
    Object^ o = assem->CreateInstance("Example", false, 
        BindingFlags::ExactBinding, 
        nullptr, gcnew array<Object^> { 2 }, nullptr, nullptr);

    // Make a late-bound call to an instance method of the object.    
    MethodInfo^ m = assem->GetType("Example")->GetMethod("SampleMethod");
    Object^ ret = m->Invoke(o, gcnew array<Object^> { 42 });
    Console::WriteLine("SampleMethod returned {0}.", ret);

    Console::WriteLine("\nAssembly entry point:");
    Console::WriteLine(assem->EntryPoint);
}

/* This code example produces output similar to the following:

Assembly Full Name:
source, Version=1.0.2000.0, Culture=neutral, PublicKeyToken=null

Name: source
Version: 1.0

Assembly CodeBase:
file:///C:/sdtree/AssemblyClass/cpp/source.exe

Example->SampleMethod(42) executes.
SampleMethod returned 84.

Assembly entry point:
UInt32 _mainCRTStartup()
 */
//</Snippet1>

