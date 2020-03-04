
// <Snippet1>
using namespace System;
using namespace System::Text;
int main()
{
   
   // A Decoder is obtained from an Encoding.
   UnicodeEncoding^ uni = gcnew UnicodeEncoding;
   Decoder^ dec1 = uni->GetDecoder();
   
   // A more direct technique.
   Decoder^ dec2 = Encoding::Unicode->GetDecoder();
   
   // dec1 and dec2 seem to be the same.
   Console::WriteLine( dec1 );
   Console::WriteLine( dec2 );
   
   // Note that their hash codes differ.
   Console::WriteLine( dec1->GetHashCode() );
   Console::WriteLine( dec2->GetHashCode() );
}

/* This code example produces the following output.

System.Text.UnicodeEncoding+Decoder
System.Text.UnicodeEncoding+Decoder
54267293
18643596

*/
// </Snippet1>
