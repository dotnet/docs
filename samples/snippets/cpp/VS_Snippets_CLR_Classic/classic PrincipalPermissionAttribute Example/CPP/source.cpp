//<Snippet1>
using namespace System;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Security::Policy;
using namespace System::Security::Principal;

[PrincipalPermission(SecurityAction::Demand, Role = "Administrators")]
void CheckAdministrator()
{
	Console::WriteLine("User is an administrator.");
}
int main(array<System::String ^> ^args)
{
	try
	{
		// Must set PrincipalPolicy to WindowsPrincipal
		AppDomain::CurrentDomain->SetPrincipalPolicy(PrincipalPolicy::WindowsPrincipal);
		// Check using declarative security.
		CheckAdministrator();
		// Check using Imperative security.
		System::String^ null;
		PrincipalPermission^ principalPerm = gcnew PrincipalPermission(null, "Administrators" );
		principalPerm->Demand();
		Console::WriteLine("Demand succeeded");
	}
	catch (Exception ^e)
	{
		Console::WriteLine(e->Message);
	}
	return 0;
}


//</Snippet1>
