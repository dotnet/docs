//<Snippet1>
using namespace System;
using namespace System::Security::Permissions;

namespace SecurityLibrary
{
    [EnvironmentPermission(SecurityAction::LinkDemand, Read = "PATH")]
    public ref class TypesWithLinkDemands
    {
    protected:
        virtual void UnsecuredMethod() {}

        [EnvironmentPermission(SecurityAction::InheritanceDemand, 
           Read = "PATH")]
        virtual void SecuredMethod() {}
    };
}
//</Snippet1>
