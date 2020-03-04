
// <Snippet1>
using namespace System;
using namespace System::Text;
int main()
{
   ASCIIEncoding^ ascii = gcnew ASCIIEncoding;
   int byteCount = 8;
   int maxCharCount = ascii->GetMaxCharCount( byteCount );
   Console::WriteLine( "Maximum of {0} characters needed to decode {1} bytes.", maxCharCount, byteCount );
}

// </Snippet1>
