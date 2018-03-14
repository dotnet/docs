
// <Snippet1>
using namespace System;
using namespace System::Text;
int main()
{
   ASCIIEncoding^ ascii = gcnew ASCIIEncoding;
   int charCount = 2;
   int maxByteCount = ascii->GetMaxByteCount( charCount );
   Console::WriteLine( "Maximum of {0} bytes needed to encode {1} characters.", maxByteCount, charCount );
}

// </Snippet1>
