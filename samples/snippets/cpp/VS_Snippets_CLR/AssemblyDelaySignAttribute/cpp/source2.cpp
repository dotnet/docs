//<snippet2>
using namespace System;
using namespace System::Reflection;

//<snippet3>
// Set version number for the assembly.
[assembly:AssemblyVersionAttribute("4.3.2.1")];
// Set culture as German.
[assembly:AssemblyCultureAttribute("de")];
//</snippet3>

//<snippet4>
[assembly:AssemblyKeyFileAttribute("myKey.snk")];
[assembly:AssemblyDelaySignAttribute(true)];
//</snippet4>

namespace DummySpace
{
    public ref class DummyClass
    {
    public:
        static void Main()
        {
            Console::WriteLine("DummySpace.DummyClass.Main()");
        }
    };
}

int main()
{
    DummySpace::DummyClass::Main();
}
//</snippet2>
