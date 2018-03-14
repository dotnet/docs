
// <Snippet1>
using namespace System;
using namespace System::Text;
int main()
{
   UTF8Encoding^ utf8 = gcnew UTF8Encoding;
   int charCount = 2;
   int maxByteCount = utf8->GetMaxByteCount( charCount );
   Console::WriteLine( "Maximum of {0} bytes needed to encode {1} characters.", maxByteCount, charCount );
}

// </Snippet1>
