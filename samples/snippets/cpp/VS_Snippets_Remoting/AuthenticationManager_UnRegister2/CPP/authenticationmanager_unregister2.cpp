// System.Net.AuthenticationManager.UnRegister(String).
// System.Net.AuthenticationManager.Register.
// Grouping Clause : 1,3 AND 2,3.

/*This program demonstrates the 'UnRegister(String)' and 'Register' methods of 
'AuthenticationManager' class. It gets all the authentication modules registered with the system into an 
IEnumerator instance ,unregisters the first authentication module and displays to show that it was 
unregistered. Then registers the same module back again and displays all the modules again.*/

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Collections;

// <Snippet3>
void DisplayAllModules()
{
   IEnumerator^ registeredModules = AuthenticationManager::RegisteredModules;
   Console::WriteLine(  "\n\tThe following modules are now registered with the system:" );
   while ( registeredModules->MoveNext() )
   {
      Console::WriteLine(  "\n\t\tModule : {0}", registeredModules->Current );
      IAuthenticationModule^ currentAuthenticationModule = dynamic_cast<IAuthenticationModule^>(registeredModules->Current);
      Console::WriteLine(  "\t\t\t CanPreAuthenticate : {0}", currentAuthenticationModule->CanPreAuthenticate );
   }
}
// </Snippet3>

int main()
{
   try
   {
// <Snippet1>
// <Snippet2>
      IEnumerator^ registeredModules = AuthenticationManager::RegisteredModules;
      // Display all the modules that are already registered with the system.
      DisplayAllModules();
      registeredModules->Reset();
      registeredModules->MoveNext();
      // Get the first Authentication module registered with the system.
      IAuthenticationModule^ authenticationModule1 = dynamic_cast<IAuthenticationModule^>(registeredModules->Current);
      // Call the UnRegister() method to unregister the first authentication module from the system.
      String^ authenticationScheme = authenticationModule1->AuthenticationType;
      AuthenticationManager::Unregister( authenticationScheme );
      Console::WriteLine(  "\nSuccessfully unregistered '{0}'.", authenticationModule1 );
      // Display all modules to see that the module was unregistered.
      DisplayAllModules();
// </Snippet2>
      // Calling 'Register()' method to register 'authenticationModule1'  module back again.
      AuthenticationManager::Register( authenticationModule1 );
      Console::WriteLine(  "\nSuccessfully re-registered '{0}'.", authenticationModule1 );
      // Display the modules to verify that 'authenticationModule1' has been registered back again.
      DisplayAllModules();
// </Snippet1>
      Console::WriteLine(  "Press any key to continue" );
      Console::ReadLine();
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine(  "\n The following Exception was raised : {0}", e->Message );
   }
}
