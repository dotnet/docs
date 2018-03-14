
// <Snippet1>
using namespace System;
using namespace Microsoft::Win32;
void PrintKeys( RegistryKey ^ rkey )
{
   
   // Retrieve all the subkeys for the specified key.
   array<String^>^names = rkey->GetSubKeyNames();
   int icount = 0;
   Console::WriteLine( "Subkeys of {0}", rkey->Name );
   Console::WriteLine( "-----------------------------------------------" );
   
   // Print the contents of the array to the console.
   System::Collections::IEnumerator^ enum0 = names->GetEnumerator();
   while ( enum0->MoveNext() )
   {
      String^ s = safe_cast<String^>(enum0->Current);
      Console::WriteLine( s );
      
      // The following code puts a limit on the number
      // of keys displayed.  Comment it out to print the
      // complete list.
      icount++;
      if ( icount >= 10 )
            break;
   }
}

int main()
{
   
   // Create a RegistryKey, which will access the HKEY_PERFORMANCE_DATA
   // key in the registry of this machine.
   RegistryKey ^ rk = Registry::PerformanceData;
   
   // Print out the keys.
   PrintKeys( rk );
}

// </Snippet1>
