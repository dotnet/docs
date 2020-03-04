
// <Snippet1>
using namespace System;
using namespace System::Text;
int main()
{
   UTF8Encoding^ utf8 = gcnew UTF8Encoding;
   String^ encodingName = utf8->EncodingName;
   Console::WriteLine( "Encoding name: {0}", encodingName );
}

// </Snippet1>
