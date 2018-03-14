// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Reflection;
using namespace System::CodeDom::Compiler;

ref class Example
{
public:
    static void Main()
    {
        // VB source for example. Not all versions of CS and CPP compilers
        // support optional arguments.
        String^ codeLines =
            "Imports System\n\n" +
            "Public Class OptionalArg\n" +
            "  Public Sub MyMethod(ByVal a As Integer, _\n" +
            "    Optional ByVal b As Double = 1.2, _\n" +
            "    Optional ByVal c As Integer = 1)\n\n" +
            "    Console.WriteLine(\"a = \" & a & \" b = \" & b & \" c = \" & c)\n" +
            "  End Sub\n" +
            "End Class\n";

        // Generate a OptionalArg instance from the source above.
        Object^ o = GenerateObjectFromSource("OptionalArg", codeLines, "VisualBasic");
        Type^ t;

        t = o->GetType();
        BindingFlags bf = BindingFlags::Public | BindingFlags::Instance |
            BindingFlags::InvokeMethod | BindingFlags::OptionalParamBinding;

        t->InvokeMember("MyMethod", bf, nullptr, o, gcnew array<Object^> {10, 55.3, 12});
        t->InvokeMember("MyMethod", bf, nullptr, o, gcnew array<Object^> {10, 1.3, Type::Missing});
        t->InvokeMember("MyMethod", bf, nullptr, o, gcnew array<Object^> {10, Type::Missing, Type::Missing});
    }

private:
    static Object^ GenerateObjectFromSource(String^ objectName,
        String^ sourceLines, String^ providerName)
    {
        Object^ genObject = nullptr;
        CodeDomProvider^ codeProvider = CodeDomProvider::CreateProvider(providerName);
        CompilerParameters^ cp = gcnew CompilerParameters();

        cp->GenerateExecutable = false;
        cp->GenerateInMemory = true;

        CompilerResults^ results =
            codeProvider->CompileAssemblyFromSource(cp, sourceLines);
        if (results->Errors->Count == 0)
        {
            genObject = results->CompiledAssembly->CreateInstance(objectName);
        }

        return genObject;
    }
};

int main()
{
    Example::Main();
}
// </Snippet1>