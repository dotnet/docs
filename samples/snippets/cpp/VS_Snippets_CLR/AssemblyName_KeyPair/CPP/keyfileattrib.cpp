//<snippet20>
using namespace System;
using namespace System::Reflection;

//<snippet21>
[assembly:AssemblyKeyFileAttribute("keyfile.snk")];
//</snippet21>
namespace KeyFileAttrib
{
    public ref class Dummy
    {
    public:
        static void Main()
        {
            Console::WriteLine("KeyFileAttrib.Dummy.Main()");
        }
    };
}

int main()
{
    KeyFileAttrib::Dummy::Main();
}
//</snippet20>
