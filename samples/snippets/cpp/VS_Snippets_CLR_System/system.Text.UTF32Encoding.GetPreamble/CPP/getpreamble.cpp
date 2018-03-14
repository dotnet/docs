
// The following code example retrieves and displays the byte order mark for different UTF32Encoding instances.
// <Snippet1>
using namespace System;
using namespace System::Text;

void PrintHexBytes( array<Byte>^bytes );

int main()
{
   
   // Create instances of UTF32Encoding, with the byte order mark and without.
   UTF32Encoding ^ u32LeNone = gcnew UTF32Encoding;
   UTF32Encoding ^ u32BeNone = gcnew UTF32Encoding( true,false );
   UTF32Encoding ^ u32LeBom = gcnew UTF32Encoding( false,true );
   UTF32Encoding ^ u32BeBom = gcnew UTF32Encoding( true,true );
   
   // Display the preamble for each instance.
   PrintHexBytes( u32LeNone->GetPreamble() );
   PrintHexBytes( u32BeNone->GetPreamble() );
   PrintHexBytes( u32LeBom->GetPreamble() );
   PrintHexBytes( u32BeBom->GetPreamble() );
}

void PrintHexBytes( array<Byte>^bytes )
{
   if ( (bytes == nullptr) || (bytes->Length == 0) )
      Console::WriteLine( "<none>" );
   else
   {
      for ( int i = 0; i < bytes->Length; i++ )
         Console::Write( "{0:X2} ", bytes[ i ] );
      Console::WriteLine();
   }
}

/* 
This example displays the following output:
      FF FE 00 00
      <none>
      FF FE 00 00
      00 00 FE FF
*/
// </Snippet1>
