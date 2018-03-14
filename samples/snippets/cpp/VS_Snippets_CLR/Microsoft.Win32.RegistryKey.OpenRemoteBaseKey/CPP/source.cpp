
// <Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Security::Permissions;
using namespace Microsoft::Win32;


int main( int argc, char *argv[] )
{
   RegistryKey ^ environmentKey;
   
   // Check that an argument was specified when the 
   // program was invoked.
   if ( argc == 1 )
   {
      Console::WriteLine( "Error: The name of the remote computer "
      "must be specified as input on the command line." );
      return  -1;
   }

   try
   {
      
      // Open HKEY_CURRENT_USER\Environment on a remote computer.
      environmentKey = RegistryKey::OpenRemoteBaseKey( RegistryHive::CurrentUser, gcnew String(argv[ 1 ]) )->OpenSubKey( "Environment" );
   }
   catch ( IOException^ e ) 
   {
      Console::WriteLine(  "{0}: {1}", e->GetType()->Name, e->Message );
      return  -1;
   }

   
   // Print the values.
   Console::WriteLine( "\nThere are {0} values for {1}.", environmentKey->ValueCount.ToString(), environmentKey->Name );
   array<String^>^valueNames = environmentKey->GetValueNames();
   for ( int i = 0; i < environmentKey->ValueCount; i++ )
   {
      Console::WriteLine(  "{0,-20}: {1}", valueNames[ i ], environmentKey->GetValue( valueNames[ i ] )->ToString() );

   }
   
   // Close the registry key.
   environmentKey->Close();
}

// </Snippet1>
