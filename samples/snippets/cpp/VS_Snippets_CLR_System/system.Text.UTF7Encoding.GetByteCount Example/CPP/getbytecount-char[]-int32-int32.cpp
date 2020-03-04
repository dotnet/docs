
// <Snippet1>
using namespace System;
using namespace System::Text;
int main()
{
   
   // Unicode characters.
   
   // Pi
   // Sigma
   array<Char>^chars = {L'\u03a0',L'\u03a3',L'\u03a6',L'\u03a9'};
   UTF7Encoding^ utf7 = gcnew UTF7Encoding;
   int byteCount = utf7->GetByteCount( chars, 1, 2 );
   Console::WriteLine( "{0} bytes needed to encode characters.", byteCount );
}

// </Snippet1>
