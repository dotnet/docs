
using namespace System;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Security::Policy;

public ref class PrincipalPermTest
{
public:
    void Dummy1()
    {
        // <Snippet1>
        PrincipalPermission^ ppBob = gcnew PrincipalPermission("Bob", "Administrator");
        PrincipalPermission^ ppLouise = gcnew PrincipalPermission("Louise", "Administrator");
        IPermission^ pp1 = ppBob->Intersect(ppLouise);
        // </Snippet1>
    }

    void Dummy2()
    {
        // <Snippet2>
        IPermission^ pp1 = gcnew PrincipalPermission("", "Administrator");
        // </Snippet2>
    }

    void Dummy3()
    {
        // <Snippet3>
        PrincipalPermission^ ppBob = gcnew PrincipalPermission("Bob", "Administrator");
        PrincipalPermission^ ppLouise = gcnew PrincipalPermission("Louise", "Administrator");
        // </Snippet3>
    }
};


int main()
{

}
