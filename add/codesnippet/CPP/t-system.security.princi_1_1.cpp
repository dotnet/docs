using namespace System;
using namespace System::Security::Principal;
void ShowIdentityPreferences( GenericIdentity^ genericIdentity );
GenericIdentity^ GetGenericIdentity();

[STAThread]
int main()
{
   // Create a GenericIdentity object with no authentication type 
   // specified.
   GenericIdentity^ defaultIdentity = gcnew GenericIdentity( "DefaultUser" );

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
   String^ identityName = genericIdentity->Name;

   // Retrieve the authentication type of the generic identity object.
   String^ identityAuthenticationType = genericIdentity->AuthenticationType;

   Console::WriteLine( "Name: {0}", identityName );
   Console::WriteLine( "Type: {0}", identityAuthenticationType );

   // Verify that the user's identity has been authenticated
   // (was created with a valid name).
   if ( genericIdentity->IsAuthenticated )
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
   WindowsIdentity^ windowsIdentity = WindowsIdentity::GetCurrent();

   // Construct a GenericIdentity object based on the current Windows
   // identity name and authentication type.
   String^ authenticationType = windowsIdentity->AuthenticationType;
   String^ userName = windowsIdentity->Name;
   GenericIdentity^ authenticatedGenericIdentity = gcnew GenericIdentity( userName,authenticationType );

   return authenticatedGenericIdentity;
}