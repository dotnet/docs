// <snippet5>
// This program lists all the public constructors
// of the System.String class.
using namespace System;
using namespace System::Reflection;

public ref class OtherSnippets
{
public:
    static void Main()
    {
         SnippetA();
         SnippetB();
    }

    static void SnippetA()
    {
        // <snippet6>
        // Gets the mscorlib assembly in which the object is defined.
        Assembly^ a = Object::typeid->Module->Assembly;
        // </snippet6>
    }

    static void SnippetB()
    {
        // <snippet7>
        // Loads an assembly using its file name.
        Assembly^ a = Assembly::LoadFrom("MyExe.exe");
        // Gets the type names from the assembly.
        array<Type^>^ types2 = a->GetTypes();
        for each (Type^ t in types2)
        {
            Console::WriteLine(t->FullName);
        }
        // </snippet7>
    }
};

int main()
{
    OtherSnippets::Main();
}
// </snippet5>
