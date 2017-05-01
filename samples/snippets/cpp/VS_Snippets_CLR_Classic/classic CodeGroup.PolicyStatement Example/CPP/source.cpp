using namespace System;
using namespace System::Security;
using namespace System::Security::Policy;
using namespace System::Security::Permissions;

public ref class Sample
{
private:
   void Method()
   {
      FirstMatchCodeGroup^ codeGroup = gcnew FirstMatchCodeGroup( nullptr,gcnew PolicyStatement( gcnew PermissionSet( PermissionState::None ) ) );
      // <Snippet1>
      codeGroup->PolicyStatement = gcnew PolicyStatement( gcnew NamedPermissionSet( "MyPermissionSet" ) );
      // </Snippet1>
   }
};
