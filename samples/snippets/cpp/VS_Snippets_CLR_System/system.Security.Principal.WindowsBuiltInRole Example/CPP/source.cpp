using namespace System;
using namespace System::Threading;
using namespace System::Security::Permissions;
using namespace System::Security::Principal;

class SecurityPrincipalDemo
{
   // <Snippet1>
public:
   static void DemonstrateWindowsBuiltInRoleEnum()
   {
      AppDomain^ myDomain = Thread::GetDomain();

      myDomain->SetPrincipalPolicy( PrincipalPolicy::WindowsPrincipal );
      WindowsPrincipal^ myPrincipal = dynamic_cast<WindowsPrincipal^>(Thread::CurrentPrincipal);

      Console::WriteLine( "{0} belongs to: ", myPrincipal->Identity->Name );

      Array^ wbirFields = Enum::GetValues( WindowsBuiltInRole::typeid );

      for each ( Object^ roleName in wbirFields )
      {
         try
         {
            Console::WriteLine( "{0}? {1}.", roleName,
               myPrincipal->IsInRole(  *dynamic_cast<WindowsBuiltInRole^>(roleName) ) );
         }
         catch ( Exception^ ) 
         {
            Console::WriteLine( "{0}: Could not obtain role for this RID.",
               roleName );
         }
      }
   }
   // </Snippet1>
};

int main()
{
   SecurityPrincipalDemo::DemonstrateWindowsBuiltInRoleEnum();
}
