
// <Snippet1>
using namespace System;
using namespace Microsoft::Win32;
int main()
{
   
   // Delete and recreate the test key.
   Registry::CurrentUser->DeleteSubKey( "RegistrySetValueExample", false );
   RegistryKey ^ rk = Registry::CurrentUser->CreateSubKey( "RegistrySetValueExample" );
   
   // Create name/value pairs.
   // Numeric values that cannot be interpreted as DWord (int) values
   // are stored as strings.
   rk->SetValue( "LargeNumberValue1", (long)42 );
   rk->SetValue( "LargeNumberValue2", 42000000000 );
   rk->SetValue( "DWordValue", 42 );
   array<String^>^temp0 = {"One","Two","Three"};
   rk->SetValue( "MultipleStringValue", temp0 );
   array<Byte>^temp1 = {10,43,44,45,14,255};
   rk->SetValue( "BinaryValue", temp1 );
   
   // This overload of SetValue does not support expanding strings. Use
   // the overload that allows you to specify RegistryValueKind.
   rk->SetValue( "StringValue", "The path is %PATH%" );
   
   // Display all the name/value pairs stored in the test key, with
   // the registry data type in parentheses.
   //
   array<String^>^valueNames = rk->GetValueNames();
   System::Collections::IEnumerator^ myEnum = valueNames->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      String^ s = safe_cast<String^>(myEnum->Current);
      RegistryValueKind rvk = rk->GetValueKind( s );
      switch ( rvk )
      {
         case RegistryValueKind::MultiString:
         {
            array<String^>^values = (array<String^>^)rk->GetValue( s );
            Console::Write( "\r\n {0} ({1}) = \"{2}\"", s, rvk, values[ 0 ] );
            for ( int i = 1; i < values->Length; i++ )
            {
               Console::Write( ", \"{0}\"", values[ i ] );

            }
            Console::WriteLine();
            break;
         }
         case RegistryValueKind::Binary:
         {
            array<Byte>^bytes = (array<Byte>^)rk->GetValue( s );
            Console::Write( "\r\n {0} ({1}) = {2:X2}", s, rvk, bytes[ 0 ] );
            for ( int i = 1; i < bytes->Length; i++ )
            {
               
               // Display each byte as two hexadecimal digits.
               Console::Write( " {0:X2}", bytes[ i ] );

            }
            Console::WriteLine();
            break;
         }
         default:
            Console::WriteLine( "\r\n {0} ({1}) = {2}", s, rvk, rk->GetValue( s ) );
            break;
      }
   }
}

// </Snippet1>
