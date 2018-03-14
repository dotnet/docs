
// <Snippet1>
using namespace System;
using namespace System::Text;
int main()
{
   UTF8Encoding^ utf8 = gcnew UTF8Encoding;
   int byteCount = 8;
   int maxCharCount = utf8->GetMaxCharCount( byteCount );
   Console::WriteLine( "Maximum of {0} characters needed to decode {1} bytes.", maxCharCount, byteCount );
}

// </Snippet1>
