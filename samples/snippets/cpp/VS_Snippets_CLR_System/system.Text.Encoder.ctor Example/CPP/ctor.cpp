
// <Snippet1>
using namespace System;
using namespace System::Text;
int main()
{
   
   // An Encoder is obtained from an Encoding.
   UnicodeEncoding^ uni = gcnew UnicodeEncoding;
   Encoder^ enc1 = uni->GetEncoder();
   
   // A more direct technique.
   Encoder^ enc2 = Encoding::Unicode->GetEncoder();
   
   // enc1 and enc2 seem to be the same.
   Console::WriteLine( enc1 );
   Console::WriteLine( enc2 );
   
   // Note that their hash codes differ.
   Console::WriteLine( enc1->GetHashCode() );
   Console::WriteLine( enc2->GetHashCode() );
}

/* This code example produces the following output.

System.Text.EncoderNLS
System.Text.EncoderNLS
54267293
18643596

*/

// </Snippet1>
