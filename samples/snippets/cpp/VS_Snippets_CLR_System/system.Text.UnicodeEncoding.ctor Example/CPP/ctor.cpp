
// <Snippet1>
using namespace System;
using namespace System::Text;
int main()
{
   UnicodeEncoding^ unicode = gcnew UnicodeEncoding;
   String^ encodingName = unicode->EncodingName;
   Console::WriteLine( "Encoding name: {0}", encodingName );
}

// </Snippet1>
