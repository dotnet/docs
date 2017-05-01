
// <Snippet1>
using namespace System;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Security::Principal;
using namespace System::Threading;

int main()
{
   array<String^>^rolesArray = {"managers","executives"};
   try
   {
      
      // Set the principal to a new generic principal.
      Thread::CurrentPrincipal = gcnew GenericPrincipal( gcnew GenericIdentity( "Bob","Passport" ),rolesArray );
   }
   catch ( SecurityException^ secureException ) 
   {
      Console::WriteLine( "{0}: Permission to set Principal "
      "is denied.", secureException->GetType()->Name );
   }

   IPrincipal^ threadPrincipal = Thread::CurrentPrincipal;
   Console::WriteLine( "Name: {0}\nIsAuthenticated: {1}"
   "\nAuthenticationType: {2}", threadPrincipal->Identity->Name, threadPrincipal->Identity->IsAuthenticated.ToString(), threadPrincipal->Identity->AuthenticationType );
}

// </Snippet1>
