using namespace System;
using namespace System::Security::Principal;
void IntPtrConstructor( IntPtr logonToken );
void IntPtrStringConstructor( IntPtr logonToken );
void IntPrtStringTypeBoolConstructor( IntPtr logonToken );
void IntPtrStringTypeConstructor( IntPtr logonToken );
void UseProperties( IntPtr logonToken );
IntPtr LogonUser();
void GetAnonymousUser();
void ImpersonateIdentity( IntPtr logonToken );

[STAThread]
int main()
{
   
   // Retrieve the Windows account token for the current user.
   IntPtr logonToken = LogonUser();
   
   // Constructor implementations.
   IntPtrConstructor( logonToken );
   IntPtrStringConstructor( logonToken );
   IntPtrStringTypeConstructor( logonToken );
   IntPrtStringTypeBoolConstructor( logonToken );
   
   // Property implementations.
   UseProperties( logonToken );
   
   // Method implementations.
   GetAnonymousUser();
   ImpersonateIdentity( logonToken );
   Console::WriteLine( "This sample completed successfully; "
   "press Enter to exit." );
   Console::ReadLine();
}


// Create a WindowsIdentity object for the user represented by the
// specified Windows account token.
void IntPtrConstructor( IntPtr logonToken )
{
   
   // Construct a WindowsIdentity object using the input account token.
   WindowsIdentity^ windowsIdentity = gcnew WindowsIdentity( logonToken );
   
   Console::WriteLine( "Created a Windows identity object named {0}.", windowsIdentity->Name );
}

// Create a WindowsIdentity object for the user represented by the
// specified account token and authentication type.
void IntPtrStringConstructor( IntPtr logonToken )
{
   
   // Construct a WindowsIdentity object using the input account token 
   // and the specified authentication type.
   String^ authenticationType = "WindowsAuthentication";
   WindowsIdentity^ windowsIdentity = gcnew WindowsIdentity( logonToken,authenticationType );
   
   Console::WriteLine( "Created a Windows identity object named {0}.", windowsIdentity->Name );
}



// Create a WindowsIdentity object for the user represented by the
// specified account token, authentication type and Windows account
// type.
void IntPtrStringTypeConstructor( IntPtr logonToken )
{
   
   // Construct a WindowsIdentity object using the input account token,
   // and the specified authentication type and Windows account type.
   String^ authenticationType = "WindowsAuthentication";
   WindowsAccountType guestAccount = WindowsAccountType::Guest;
   WindowsIdentity^ windowsIdentity = gcnew WindowsIdentity( logonToken,authenticationType,guestAccount );
   
   Console::WriteLine( "Created a Windows identity object named {0}.", windowsIdentity->Name );
}

// Create a WindowsIdentity object for the user represented by the
// specified account token, authentication type, Windows account type and
// Boolean authentication flag.
void IntPrtStringTypeBoolConstructor( IntPtr logonToken )
{
   
   // Construct a WindowsIdentity object using the input account token,
   // and the specified authentication type, Windows account type, and
   // authentication flag.
   String^ authenticationType = "WindowsAuthentication";
   WindowsAccountType guestAccount = WindowsAccountType::Guest;
   bool isAuthenticated = true;
   WindowsIdentity^ windowsIdentity = gcnew WindowsIdentity( logonToken,authenticationType,guestAccount,isAuthenticated );
   
   Console::WriteLine( "Created a Windows identity object named {0}.", windowsIdentity->Name );
}

// Access the properties of a WindowsIdentity object.
void UseProperties( IntPtr logonToken )
{
   WindowsIdentity^ windowsIdentity = gcnew WindowsIdentity( logonToken );
   String^ propertyDescription = "The windows identity named ";
   
   // Retrieve the Windows logon name from the Windows identity object.
   propertyDescription = String::Concat( propertyDescription, windowsIdentity->Name );
   
   // Verify that the user account is not considered to be an Anonymous
   // account by the system.
   if (  !windowsIdentity->IsAnonymous )
   {
      propertyDescription = String::Concat( propertyDescription, ", is not an Anonymous account" );
   }

   
   // Verify that the user account has been authenticated by Windows.
   if ( windowsIdentity->IsAuthenticated )
   {
      propertyDescription = String::Concat( propertyDescription, ", is authenticated" );
   }
   
   // Verify that the user account is considered to be a System account
   // by the system.
   if ( windowsIdentity->IsSystem )
   {
      propertyDescription = String::Concat( propertyDescription, ", is a System account" );
   }
   
   // Verify that the user account is considered to be a Guest account
   // by the system.
   if ( windowsIdentity->IsGuest )
   {
      propertyDescription = String::Concat( propertyDescription, ", is a Guest account" );
   }
   
   // Retrieve the authentication type for the 
   String^ authenticationType = windowsIdentity->AuthenticationType;
   
   // Append the authenication type to the output message.
   if ( authenticationType != nullptr )
   {
      propertyDescription = String::Format( "{0} and uses {1} authentication type.", propertyDescription, authenticationType );
   }
   
   Console::WriteLine( propertyDescription );
}


// Retrieve the account token from the current WindowsIdentity object
// instead of calling the unmanaged LogonUser method in the advapi32.dll.
IntPtr LogonUser()
{
   
   IntPtr accountToken = WindowsIdentity::GetCurrent()->Token;
   
   return accountToken;
}


// Get the WindowsIdentity object for an Anonymous user.
void GetAnonymousUser()
{
   
   // Retrieve a WindowsIdentity object that represents an anonymous
   // Windows user.
   WindowsIdentity^ windowsIdentity = WindowsIdentity::GetAnonymous();
   
}


// Impersonate a Windows identity.
void ImpersonateIdentity( IntPtr logonToken )
{
   
   // Retrieve the Windows identity using the specified token.
   WindowsIdentity^ windowsIdentity = gcnew WindowsIdentity( logonToken );
   
   // Create a WindowsImpersonationContext object by impersonating the
   // Windows identity.
   WindowsImpersonationContext^ impersonationContext = windowsIdentity->Impersonate();
   Console::WriteLine( "Name of the identity after impersonation: {0}.", WindowsIdentity::GetCurrent()->Name );
   
   // Stop impersonating the user.
   impersonationContext->Undo();
   
   // Check the identity name.
   Console::Write( "Name of the identity after performing an Undo on the" );
   Console::WriteLine( " impersonation: {0}", WindowsIdentity::GetCurrent()->Name );
}
