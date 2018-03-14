
// <Snippet1>
using namespace System;
using namespace System::Text;
int main()
{
   array<Byte>^bytes = {85,0,110,0,105,0,99,0,111,0,100,0,101,0};
   UnicodeEncoding^ Unicode = gcnew UnicodeEncoding;
   int charCount = Unicode->GetCharCount( bytes, 2, 8 );
   Console::WriteLine( "{0} characters needed to decode bytes.", charCount );
}

// </Snippet1>
