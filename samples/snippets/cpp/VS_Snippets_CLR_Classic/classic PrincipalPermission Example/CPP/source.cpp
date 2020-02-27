//<Snippet1>
using namespace System;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Security::Policy;
using namespace System::Security::Principal;

int main(array<System::String ^> ^args)
{
	System::String^ null;
	AppDomain::CurrentDomain->SetPrincipalPolicy(PrincipalPolicy::WindowsPrincipal);
	PrincipalPermission^ principalPerm = gcnew PrincipalPermission(null, "Administrators" );
      principalPerm->Demand();
	  Console::WriteLine("Demand succeeded");
    return 0;
}
//</Snippet1>