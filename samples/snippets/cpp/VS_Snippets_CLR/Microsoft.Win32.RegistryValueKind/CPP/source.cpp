
//<Snippet1>
using namespace System;
using namespace Microsoft::Win32;
int main()
{
   
   // Delete and recreate the test key.
   Registry::CurrentUser->DeleteSubKey( "RegistryValueKindExample", false );
   RegistryKey ^ rk = Registry::CurrentUser->CreateSubKey( "RegistryValueKindExample" );
   
   // Create name/value pairs.
   // This overload supports QWord (long) values. 
   rk->SetValue( "QuadWordValue", 42, RegistryValueKind::QWord );
   
   // The following SetValue calls have the same effect as using the
   // SetValue overload that does not specify RegistryValueKind.
   //
   rk->SetValue( "DWordValue", 42, RegistryValueKind::DWord );
   rk->SetValue( "MultipleStringValue", gcnew array<String^>{
      "One","Two","Three"
   }, RegistryValueKind::MultiString );
   rk->SetValue( "BinaryValue", gcnew array<Byte>{
      10,43,44,45,14,255
   }, RegistryValueKind::Binary );
   rk->SetValue( "StringValue", "The path is %PATH%", RegistryValueKind::String );
   
   // This overload supports setting expandable string values. Compare
   // the output from this value with the previous string value.
   rk->SetValue( "ExpandedStringValue", "The path is %PATH%", RegistryValueKind::ExpandString );
   
   // Display all the name/value pairs stored in the test key, with the
   // registry data type in parentheses.
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
            Console::Write( "\r\n {0} ({1}) =", s, rvk );
            for ( int i = 0; i < values->Length; i++ )
            {
               if (i != 0) Console::Write(",");
               Console::Write( " \"{0}\"", values[ i ] );

            }
            Console::WriteLine();
            break;
         }
         case RegistryValueKind::Binary:
         {
            array<Byte>^bytes = (array<Byte>^)rk->GetValue( s );
            Console::Write( "\r\n {0} ({1}) =", s, rvk );
            for ( int i = 0; i < bytes->Length; i++ )
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
/*

This code example produces the following output:
 QuadWordValue (QWord) = 42

 DWordValue (DWord) = 42

 MultipleStringValue (MultiString) =, "One", "Two", "Three"

 BinaryValue (Binary) = 0A 2B 2C 2D 0E FF

 StringValue (String) = The path is %PATH%

 ExpandedStringValue (ExpandString) = The path is C:\Program Files\Microsoft.NET\SDK\v2.0\Bin;
 [***The remainder of this output is omitted.***]

*/
//</Snippet1>
