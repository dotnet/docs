
// <Snippet1>
using namespace System;
using namespace System::Text;
int main()
{
   UnicodeEncoding^ Unicode = gcnew UnicodeEncoding;
   int charCount = 2;
   int maxByteCount = Unicode->GetMaxByteCount( charCount );
   Console::WriteLine( "Maximum of {0} bytes needed to encode {1} characters.", maxByteCount, charCount );
}

// </Snippet1>
