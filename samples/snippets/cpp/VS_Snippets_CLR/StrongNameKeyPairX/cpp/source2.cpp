// <snippet2>
using namespace System;
using namespace System::IO;
using namespace System::Threading;
using namespace System::Reflection;
using namespace System::Reflection::Emit;

ref class SNKToAssembly
{
public:
    static void Main()
    {
        // <snippet3>
        FileStream^ fs = gcnew FileStream("SomeKeyPair.snk", FileMode::Open);
        StrongNameKeyPair^ kp = gcnew StrongNameKeyPair(fs);
        fs->Close();
        AssemblyName^ an = gcnew AssemblyName();
        an->KeyPair = kp;
        AppDomain^ appDomain = Thread::GetDomain();
        AssemblyBuilder^ ab = appDomain->DefineDynamicAssembly(an, AssemblyBuilderAccess::RunAndSave);
        // </snippet3>
    }
};

int main()
{
   SNKToAssembly::Main();
}
// </snippet2>
