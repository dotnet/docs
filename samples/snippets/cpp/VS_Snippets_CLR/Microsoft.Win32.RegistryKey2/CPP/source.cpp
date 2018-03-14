
// <Snippet1>
using namespace System;
using namespace System::Security::Permissions;
using namespace Microsoft::Win32;

int main()
{
   // Create a subkey named Test9999 under HKEY_CURRENT_USER.
   RegistryKey ^ test9999 = Registry::CurrentUser->CreateSubKey( "Test9999" );

   // Create two subkeys under HKEY_CURRENT_USER\Test9999.
   test9999->CreateSubKey( "TestName" )->Close();
   RegistryKey ^ testSettings = test9999->CreateSubKey( "TestSettings" );

   // Create data for the TestSettings subkey.
   testSettings->SetValue( "Language", "French" );
   testSettings->SetValue( "Level", "Intermediate" );
   testSettings->SetValue( "ID", 123 );
   testSettings->Close();

   // <Snippet2>
   // Print the information from the Test9999 subkey.
   Console::WriteLine( "There are {0} subkeys under Test9999.", test9999->SubKeyCount.ToString() );
   array<String^>^subKeyNames = test9999->GetSubKeyNames();
   for ( int i = 0; i < subKeyNames->Length; i++ )
   {
      RegistryKey ^ tempKey = test9999->OpenSubKey( subKeyNames[ i ] );
      Console::WriteLine( "\nThere are {0} values for {1}.", tempKey->ValueCount.ToString(), tempKey->Name );
      array<String^>^valueNames = tempKey->GetValueNames();
      for ( int j = 0; j < valueNames->Length; j++ )
      {
         Console::WriteLine( "{0,-8}: {1}", valueNames[ j ], tempKey->GetValue( valueNames[ j ] )->ToString() );

      }
   }
   // </Snippet2>
   
   // <Snippet3>
   // Delete the ID value.
   testSettings = test9999->OpenSubKey( "TestSettings", true );
   testSettings->DeleteValue( "id" );

   // Verify the deletion.
   Console::WriteLine( dynamic_cast<String^>(testSettings->GetValue(  "id", "ID not found." )) );
   testSettings->Close();
   // </Snippet3>

   // <Snippet4>
   // Delete or close the new subkey.
   Console::Write( "\nDelete newly created registry key? (Y/N) " );
   if ( Char::ToUpper( Convert::ToChar( Console::Read() ) ) == 'Y' )
   {
      Registry::CurrentUser->DeleteSubKeyTree( "Test9999" );
      Console::WriteLine( "\nRegistry key {0} deleted.", test9999->Name );
   }
   else
   {
      Console::WriteLine( "\nRegistry key {0} closed.", test9999->ToString() );
      test9999->Close();
   }
   // </Snippet4>
}
// </Snippet1>
