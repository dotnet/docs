
// This sample demonstrates how to use each member of the WindowsIdentity
// class.
//<Snippet1>
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
   //<Snippet2>
void IntPtrConstructor( IntPtr logonToken )
{
   
   // Construct a WindowsIdentity object using the input account token.
   WindowsIdentity^ windowsIdentity = gcnew WindowsIdentity( logonToken );
   
   Console::WriteLine( "Created a Windows identity object named {0}.", windowsIdentity->Name );
}
   //</Snippet2>

// Create a WindowsIdentity object for the user represented by the
// specified account token and authentication type.
   //<Snippet4>
void IntPtrStringConstructor( IntPtr logonToken )
{
   
   // Construct a WindowsIdentity object using the input account token 
   // and the specified authentication type.
   String^ authenticationType = "WindowsAuthentication";
   WindowsIdentity^ windowsIdentity = gcnew WindowsIdentity( logonToken,authenticationType );
   
   Console::WriteLine( "Created a Windows identity object named {0}.", windowsIdentity->Name );
}

   //</Snippet4>


// Create a WindowsIdentity object for the user represented by the
// specified account token, authentication type and Windows account
// type.
   //<Snippet7>
void IntPtrStringTypeConstructor( IntPtr logonToken )
{
   
   // Construct a WindowsIdentity object using the input account token,
   // and the specified authentication type and Windows account type.
   String^ authenticationType = "WindowsAuthentication";
   WindowsAccountType guestAccount = WindowsAccountType::Guest;
   WindowsIdentity^ windowsIdentity = gcnew WindowsIdentity( logonToken,authenticationType,guestAccount );
   
   Console::WriteLine( "Created a Windows identity object named {0}.", windowsIdentity->Name );
}
   //</Snippet7>

// Create a WindowsIdentity object for the user represented by the
// specified account token, authentication type, Windows account type and
// Boolean authentication flag.
   //<Snippet17>
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
   //</Snippet17>

// Access the properties of a WindowsIdentity object.
void UseProperties( IntPtr logonToken )
{
   WindowsIdentity^ windowsIdentity = gcnew WindowsIdentity( logonToken );
   String^ propertyDescription = "The windows identity named ";
   
   // Retrieve the Windows logon name from the Windows identity object.
   //<Snippet8>
   propertyDescription = String::Concat( propertyDescription, windowsIdentity->Name );
   
   //</Snippet8>
   // Verify that the user account is not considered to be an Anonymous
   // account by the system.
   //<Snippet9>
   if (  !windowsIdentity->IsAnonymous )
   {
      propertyDescription = String::Concat( propertyDescription, ", is not an Anonymous account" );
   }
      //</Snippet9>

   
   // Verify that the user account has been authenticated by Windows.
   //<Snippet10>
   if ( windowsIdentity->IsAuthenticated )
   {
      propertyDescription = String::Concat( propertyDescription, ", is authenticated" );
   }
   //</Snippet10>
   
   // Verify that the user account is considered to be a System account
   // by the system.
   //<Snippet11>
   if ( windowsIdentity->IsSystem )
   {
      propertyDescription = String::Concat( propertyDescription, ", is a System account" );
   }
   //</Snippet11>
   
   // Verify that the user account is considered to be a Guest account
   // by the system.
   //<Snippet12>
   if ( windowsIdentity->IsGuest )
   {
      propertyDescription = String::Concat( propertyDescription, ", is a Guest account" );
   }
   //</Snippet12>
   
   // Retrieve the authentication type for the 
   //<Snippet18>
   String^ authenticationType = windowsIdentity->AuthenticationType;
   
   // Append the authenication type to the output message.
   if ( authenticationType != nullptr )
   {
      propertyDescription = String::Format( "{0} and uses {1} authentication type.", propertyDescription, authenticationType );
   }
   //</Snippet18>
   
   Console::WriteLine( propertyDescription );
}


// Retrieve the account token from the current WindowsIdentity object
// instead of calling the unmanaged LogonUser method in the advapi32.dll.
IntPtr LogonUser()
{
   
   //<Snippet13>
   //<Snippet14>
   IntPtr accountToken = WindowsIdentity::GetCurrent()->Token;
   
   //</Snippet14>
   //</Snippet13>
   return accountToken;
}


// Get the WindowsIdentity object for an Anonymous user.
void GetAnonymousUser()
{
   
   // Retrieve a WindowsIdentity object that represents an anonymous
   // Windows user.
   //<Snippet15>
   WindowsIdentity^ windowsIdentity = WindowsIdentity::GetAnonymous();
   
   //</Snippet15>
}


// Impersonate a Windows identity.
//<Snippet16>
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

//</Snippet16>
//</Snippet1>

