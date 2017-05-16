
// <Snippet1>
using namespace System;
using namespace System::Text;
int main()
{
   UTF7Encoding^ utf7 = gcnew UTF7Encoding;
   int charCount = 2;
   int maxByteCount = utf7->GetMaxByteCount( charCount );
   Console::WriteLine( "Maximum of {0} bytes needed to encode {1} characters.", maxByteCount, charCount );
}

// </Snippet1>
