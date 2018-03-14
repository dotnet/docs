
// <Snippet1>
using namespace System;
using namespace System::Text;
int main()
{
   UnicodeEncoding^ Unicode = gcnew UnicodeEncoding;
   int byteCount = 8;
   int maxCharCount = Unicode->GetMaxCharCount( byteCount );
   Console::WriteLine( "Maximum of {0} characters needed to decode {1} bytes.", maxCharCount, byteCount );
}

// </Snippet1>
