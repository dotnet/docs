

//<Snippet1>
// This sample demonstrates the use of the WindowsIdentity class to impersonate a user.
// IMPORTANT NOTES: 
// This sample requests the user to enter a password on the console screen.
// Because the console window does not support methods allowing the password to be masked,
// it will be visible to anyone viewing the screen.
// On Windows Vista and later this sample must be run as an administrator. 

#using <System.dll>

using namespace System;
using namespace System::Runtime::InteropServices;
using namespace System::Security::Principal;
using namespace System::Security::Permissions;


[DllImport("advapi32.dll",SetLastError=true)]
bool LogonUser( String^ lpszUsername, String^ lpszDomain, String^ lpszPassword, int dwLogonType, int dwLogonProvider, IntPtr * phToken );

[DllImport("kernel32.dll",CharSet=CharSet::Auto)]
bool CloseHandle( IntPtr handle );

// Test harness.
// If you incorporate this code into a DLL, be sure to demand FullTrust.

[PermissionSetAttribute(SecurityAction::Demand,Name="FullTrust")]
int main()
{
   IntPtr tokenHandle = IntPtr(0);

   try
   {
      String^ userName;
      String^ domainName;
      
      // Get the user token for the specified user, domain, and password using the 
      // unmanaged LogonUser method.  
      // The local machine name can be used for the domain name to impersonate a user on this machine.
      Console::Write( "Enter the name of the domain on which to log on: " );
      domainName = Console::ReadLine();
      Console::Write( "Enter the login of a user on {0} that you wish to impersonate: ", domainName );
      userName = Console::ReadLine();
      Console::Write( "Enter the password for {0}: ", userName );
      const int LOGON32_PROVIDER_DEFAULT = 0;
      
      //This parameter causes LogonUser to create a primary token.
      const int LOGON32_LOGON_INTERACTIVE = 2;
      const int SecurityImpersonation = 2;
      tokenHandle = IntPtr::Zero;
      
      // Call LogonUser to obtain a handle to an access token.
      bool returnValue = LogonUser( userName, domainName, Console::ReadLine(), LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT,  &tokenHandle );
      Console::WriteLine( "LogonUser called." );
      if ( false == returnValue )
      {
         int ret = Marshal::GetLastWin32Error();
         Console::WriteLine( "LogonUser failed with error code : {0}", ret );
         throw gcnew System::ComponentModel::Win32Exception( ret );
      }
      Console::WriteLine( "Did LogonUser Succeed? {0}", (returnValue ? (String^)"Yes" : "No") );
      Console::WriteLine( "Value of Windows NT token: {0}", tokenHandle );
      
      // Check the identity.
      Console::WriteLine( "Before impersonation: {0}", WindowsIdentity::GetCurrent()->Name );
      
      // The token that is passed to the following constructor must 
      // be a primary token in order to use it for impersonation.
      WindowsIdentity^ newId = gcnew WindowsIdentity( tokenHandle );
      WindowsImpersonationContext^ impersonatedUser = newId->Impersonate();
      
      // Check the identity.
      Console::WriteLine( "After impersonation: {0}", WindowsIdentity::GetCurrent()->Name );
      
      // Stop impersonating the user.
      impersonatedUser->Undo();
      
      // Check the identity.
      Console::WriteLine( "After Undo: {0}", WindowsIdentity::GetCurrent()->Name );
      
      // Free the tokens.
      if ( tokenHandle != IntPtr::Zero )
            CloseHandle( tokenHandle );
   }
   catch ( Exception^ ex ) 
   {
      Console::WriteLine( "Exception occurred. {0}", ex->Message );
   }

}

//</Snippet1>
