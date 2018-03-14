
// This sample demonstrates how to call each member of the GenericIdentity
// class.
//<Snippet1>
using namespace System;
using namespace System::Security::Principal;
void ShowIdentityPreferences( GenericIdentity^ genericIdentity );
GenericIdentity^ GetGenericIdentity();

[STAThread]
int main()
{
   // Create a GenericIdentity object with no authentication type 
   // specified.
   //<Snippet2>
   GenericIdentity^ defaultIdentity = gcnew GenericIdentity( "DefaultUser" );
   //</Snippet2>

   // Retrieve a GenericIdentity created from current WindowsIdentity
   // values.
   GenericIdentity^ currentIdentity = GetGenericIdentity();
   ShowIdentityPreferences( gcnew GenericIdentity( "" ) );
   ShowIdentityPreferences( defaultIdentity );
   ShowIdentityPreferences( currentIdentity );
   Console::WriteLine( "The sample completed successfully; "
   "press Enter to continue." );
   Console::ReadLine();
}

// Print identity preferences to the console window.
void ShowIdentityPreferences( GenericIdentity^ genericIdentity )
{
   // Retrieve the name of the generic identity object.
   //<Snippet4>
   String^ identityName = genericIdentity->Name;
   //</Snippet4>

   // Retrieve the authentication type of the generic identity object.
   //<Snippet5>
   String^ identityAuthenticationType = genericIdentity->AuthenticationType;
   //</Snippet5>

   Console::WriteLine( "Name: {0}", identityName );
   Console::WriteLine( "Type: {0}", identityAuthenticationType );

   // Verify that the user's identity has been authenticated
   // (was created with a valid name).
   //<Snippet6>
   if ( genericIdentity->IsAuthenticated )
   //</Snippet6>
   {
      Console::WriteLine( "The user's identity has been authenticated." );
   }
   else
   {
      Console::WriteLine( "The user's identity has not been "
      "authenticated." );
   }

   Console::WriteLine( "~~~~~~~~~~~~~~~~~~~~~~~~~" );
}


// Create generic identity based on values from the current
// WindowsIdentity.
GenericIdentity^ GetGenericIdentity()
{
   // Get values from the current WindowsIdentity.
   //<Snippet3>
   WindowsIdentity^ windowsIdentity = WindowsIdentity::GetCurrent();

   // Construct a GenericIdentity object based on the current Windows
   // identity name and authentication type.
   String^ authenticationType = windowsIdentity->AuthenticationType;
   String^ userName = windowsIdentity->Name;
   GenericIdentity^ authenticatedGenericIdentity = gcnew GenericIdentity( userName,authenticationType );
   //</Snippet3>

   return authenticatedGenericIdentity;
}
//</Snippet1>
