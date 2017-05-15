
// <Snippet1>
using namespace System;
using namespace System::Text;
int main()
{
   
   // Unicode characters.
   
   // Pi
   // Sigma
   array<Char>^chars = {L'\u03a0',L'\u03a3',L'\u03a6',L'\u03a9'};
   Encoder^ uniEncoder = Encoding::Unicode->GetEncoder();
   int byteCount = uniEncoder->GetByteCount( chars, 0, chars->Length, true );
   Console::WriteLine( "{0} bytes needed to encode characters.", byteCount );
}

/* This code example produces the following output. 

8 bytes needed to encode characters.

*/

// </Snippet1>
