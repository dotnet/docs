
// <Snippet1>
using namespace System;
using namespace System::Text;
using namespace System::Collections;

void ShowArray(array<Byte>^ bytes)
{
   for each (Byte b in bytes)
      Console::Write( "{0:X2} ", b);

   Console::WriteLine();
}

int main()
{
   // The default constructor does not provide a preamble.
   UTF8Encoding^ UTF8NoPreamble = gcnew UTF8Encoding;
   UTF8Encoding^ UTF8WithPreamble = gcnew UTF8Encoding( true );
   array<Byte>^preamble;
   preamble = UTF8NoPreamble->GetPreamble();
   Console::WriteLine( "UTF8NoPreamble" );
   Console::WriteLine( " preamble length: {0}", preamble->Length );
   Console::Write( " preamble: " );
   ShowArray( preamble );
   Console::WriteLine();
   
   preamble = UTF8WithPreamble->GetPreamble();
   Console::WriteLine( "UTF8WithPreamble" );
   Console::WriteLine( " preamble length: {0}", preamble->Length );
   Console::Write( " preamble: " );
   ShowArray( preamble );
}
// The example displays the following output:
//       UTF8NoPreamble
//        preamble length: 0
//        preamble:
//
//       UTF8WithPreamble
//        preamble length: 3
//        preamble: EF BB BF
// </Snippet1>
