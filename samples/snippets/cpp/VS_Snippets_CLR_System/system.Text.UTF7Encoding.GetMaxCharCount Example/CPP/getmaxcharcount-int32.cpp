
// <Snippet1>
using namespace System;
using namespace System::Text;
int main()
{
   UTF7Encoding^ utf7 = gcnew UTF7Encoding;
   int byteCount = 8;
   int maxCharCount = utf7->GetMaxCharCount( byteCount );
   Console::WriteLine( "Maximum of {0} characters needed to decode {1} bytes.", maxCharCount, byteCount );
}

// </Snippet1>
